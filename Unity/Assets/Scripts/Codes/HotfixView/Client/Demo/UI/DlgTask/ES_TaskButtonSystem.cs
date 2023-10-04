using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace ET.Client
{
    [FriendOfAttribute(typeof (ES_TaskButton))]
    public static class ES_TaskButtonSystem
    {
        public static void Init(this ES_TaskButton self, UnityAction<bool> callback = default) => self.ET_On_Toggle.onValueChanged.AddListener(isOn =>
        {
            self.EI_Arrow_Image.transform.DORotate(new Vector3(0, 0, isOn? 0 : -90), 0.3f).SetEase(Ease.OutCubic);
            callback?.Invoke(isOn);
        });
    }
}