using System;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(DlgChat))]
    [FriendClassAttribute(typeof(ET.ChatInfo))]
    public static class DlgChatSystem
    {
        public static void RegisterUIEvent(this DlgChat self)
        {
            self.RegisterCloseEvent<DlgChat>(self.View.EB_CloseButton);
            self.View.EInput_InputMessageTMP_InputField.onSubmit.AddListener(content => self.OnClickSend().Coroutine());
            self.View.EB_SendButton.AddListenerAsync(self.OnClickSend);
            self.View.EL_ChatMessageLoopVerticalScrollRect.AddItemRefreshListener(self.OnChatItemLoopHandler);
        }

        public static void ShowWindow(this DlgChat self, Entity contextData = null)
        {
            self.Refresh();
        }

        public static void HideWindow(this DlgChat self)
        {
            self.RemoveUIScrollItems(ref self.ScrollItemChats);
        }

        public static void Refresh(this DlgChat self)
        {
            int count = self.ZoneScene().GetComponent<ChatComponent>().GetChatMessageCount();
            self.AddUIScrollItems(ref self.ScrollItemChats, count);
            self.View.EL_ChatMessageLoopVerticalScrollRect.SetVisible(true, count);
            self.View.EL_ChatMessageLoopVerticalScrollRect.RefillCellsFromEnd();
        }

        public static void OnChatItemLoopHandler(this DlgChat self, Transform transform, int index)
        {
            Scroll_Item_ChatMessage scrollItemChat = self.ScrollItemChats[index].BindTrans(transform);
            ChatInfo chatInfo = self.ZoneScene().GetComponent<ChatComponent>().GetChatMessageByIndex(index);

            scrollItemChat.ET_ChatMessageTextMeshProUGUI.SetText($"{chatInfo.Name} : {chatInfo.Message}");
        }

        public static async ETTask OnClickSend(this DlgChat self)
        {
            try
            {
                int errorCode = await ChatHelper.SendMessage(self.ZoneScene(), self.View.EInput_InputMessageTMP_InputField.text);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.View.EInput_InputMessageTMP_InputField.text = "";
                self.Refresh();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}