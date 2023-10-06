using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOfAttribute(typeof (ES_Chat))]
    [FriendOfAttribute(typeof (ChatMessage))]
    [FriendOfAttribute(typeof (CChatComponent))]
    [FriendOfAttribute(typeof (Scroll_Item_Chat))]
    public static class ES_ChatSystem
    {
        public static void Init(this ES_Chat self)
        {
            self.EInput_TMP_InputField.onSubmit.AddListener(content => self.OnClickSend().Coroutine());
            self.EB_Send_Button.AddListenerAsync(self.OnClickSend);
            self.EToggle_Close_Toggle.AddListener(self.ShowPanel);
            self.EL_ChatContent_LoopVList.AddItemRefreshListener(self.OnRefreshChatItem);
            self.ED_SendChannel_TMP_Dropdown.onValueChanged.AddListener(channel =>
            {
                self.SendChannel = (ChatChannel)Math.Pow(2, channel);
                self.RefreshPrivateTarget();
            });
            self.GenerateTab();
        }

        private static void GenerateTab(this ES_Chat self)
        {
            var prefab = "EToggle_";
            ResourcesComponent.Instance.LoadBundle(prefab.StringToAB());
            var prefabGo = ResourcesComponent.Instance.GetAsset(prefab.StringToAB(), prefab) as GameObject;
            var toggleGroup = self.EG_Channels_RectTransform.GetComponent<ToggleGroup>();
            foreach (var e in Enum.GetValues(typeof (ChatChannel)))
            {
                var channel = (ChatChannel)e;
                if (channel == ChatChannel.System)
                    continue;

                var channelName = channel.GetDisplayName();
                var go = UnityEngine.Object.Instantiate(prefabGo, self.EG_Channels_RectTransform);
                if (channel == ChatChannel.All)
                    go.transform.SetSiblingIndex(0);
                go.name = channelName;
                go.transform.GetChild(2).GetComponent<TextMeshProUGUI>().SetText(channelName);
                var toggle = go.GetComponent<Toggle>();
                toggle.group = toggleGroup;
                toggle.AddListener(isOn =>
                {
                    if (isOn && self.DisplayChannel != channel)
                    {
                        self.DisplayChannel = channel;
                        self.Refresh();
                    }
                });
            }
        }

        public static void ShowPanel(this ES_Chat self, bool isOn)
        {
            self.EG_Channels_RectTransform.SetVisible(isOn);
            self.EG_InputForm_RectTransform.SetVisible(isOn);
            var rect = self.uiTransform as RectTransform;
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, isOn? 500 : 80);
            self.EToggle_Close_Toggle.targetGraphic.transform.DOLocalRotate(Vector3.forward, isOn? 180 : -180);
            self.Refresh();
        }

        public static void Refresh(this ES_Chat self)
        {
            var cc = self.ClientScene().GetComponent<CChatComponent>();

            self.Messages.Clear();
            self.Messages.AddRange(cc.AllMessages[self.DisplayChannel]);
            self.AddUIScrollItems(ref self.ScrollItemChats, self.Messages.Count);
            self.EL_ChatContent_LoopVList.SetVisible(true, self.Messages.Count);
            // self.EL_ChatContent_LoopVList.RefillCellsFromEnd();
            self.RefreshPrivateTarget();
        }

        private static void RefreshPrivateTarget(this ES_Chat self)
        {
            if (self.SendChannel == ChatChannel.Private)
            {
                self.ET_Target_TextMeshProUGUI.SetVisible(true);
                self.ET_Target_TextMeshProUGUI.text = self.ToId != 0
                        ? $"{self.ToName}:"
                        : $"<无>:";
            }
            else
            {
                self.ET_Target_TextMeshProUGUI.gameObject.SetActive(false);
            }
        }

        public static void AddItemShow(this ES_Chat self, ItemConfig config)
        {
            self.EInput_TMP_InputField.text += self.FormatItemMessage(config);
            self.EInput_TMP_InputField.ActivateInputField();
        }

        public static string FormatItemMessage(this ES_Chat self, ItemConfig config)
            => $"<link=\"Item:{config.Id}:{config.Name}\"><color=green>[{config.Name}<sprite name={config.Icon}>]</color></link>";

        public static void OnRefreshChatItem(this ES_Chat self, Transform transform, int index)
        {
            var scrollItemChat = self.ScrollItemChats[index].BindTrans(transform);
            transform.gameObject.name = $"[{index.ToString()}] [{self.Messages[index].Message}]";
            scrollItemChat.Init(self.Messages[index]);
        }

        public static async ETTask OnClickSend(this ES_Chat self)
        {
            try
            {
                var errorCode = await ChatHelper.SendMessage(self.ClientScene(), self.EInput_TMP_InputField.text, self.SendChannel, self.ToId);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.EInput_TMP_InputField.text = "";
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}