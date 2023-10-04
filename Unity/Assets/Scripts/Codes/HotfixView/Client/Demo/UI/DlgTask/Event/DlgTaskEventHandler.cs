using DG.Tweening;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (UIBaseWindow))]
    [AUIEvent(WindowID.WindowID_Task)]
    public class DlgTaskEventHandler: IAUIEventHandler
    {
        public void OnInitWindowCoreData(UIBaseWindow uiBaseWindow) => uiBaseWindow.windowType = UIWindowType.Normal;

        public void OnInitComponent(UIBaseWindow uiBaseWindow) => uiBaseWindow.AddComponent<DlgTask>().AddComponent<DlgTaskViewComponent>();

        public void OnRegisterUIEvent(UIBaseWindow uiBaseWindow) => uiBaseWindow.GetComponent<DlgTask>().RegisterUIEvent();

        public void OnShowWindow(UIBaseWindow uiBaseWindow, ShowWindowData windowData = null) =>
                uiBaseWindow.GetComponent<DlgTask>().ShowWindow(windowData);

        public void OnHideWindow(UIBaseWindow uiBaseWindow) => uiBaseWindow.uiTransform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.OutElastic);

        public void BeforeUnload(UIBaseWindow uiBaseWindow)
        {
        }
    }
}