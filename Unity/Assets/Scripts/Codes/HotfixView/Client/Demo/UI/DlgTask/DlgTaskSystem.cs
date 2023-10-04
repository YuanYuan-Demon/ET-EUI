using DG.Tweening;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgTask))]
    [FriendOfAttribute(typeof (ES_TaskButton))]
    [FriendOfAttribute(typeof (DlgTaskViewComponent))]
    public static class DlgTaskSystem
    {
        public static void RegisterUIEvent(this DlgTask self)
        {
            var view = self.View;
            self.RegisterCloseEvent<DlgTask>(self.View.EB_Close_Button);
            view.ES_MainTask.Init(isOn =>
            {
                self.ShowMainTasks = isOn;
                view.EL_MainTask_LoopVList.SetVisible(isOn, self.MainTasks.Count);
            });
            view.ES_BranchTask.Init(isOn =>
            {
                self.ShowBranchTasks = isOn;
                view.EL_BranchTask_LoopVList.SetVisible(isOn, self.BranchTasks.Count);
            });
            view.EL_MainTask_LoopVList.AddItemRefreshListener(self.OnRefreshMainTaskItem);
            view.EL_BranchTask_LoopVList.AddItemRefreshListener(self.OnRefreshBranchTaskItem);
        }

        public static void ShowWindow(this DlgTask self, ShowWindowData windowData = null)
        {
            self.View.uiTransform.transform.localScale = Vector3.zero;
            self.View.uiTransform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutElastic);
            self.Refresh();
        }

        public static void Refresh(this DlgTask self)
        {
            var tc = self.ClientScene().GetComponent<CTasksComponent>();

            self.MainTasks = tc.GetMainTasks();
            self.BranchTasks = tc.GetBranchTasks();

            self.AddUIScrollItems(ref self.ItemMainTasks, self.MainTasks.Count);
            self.AddUIScrollItems(ref self.ItemBranchTasks, self.BranchTasks.Count);

            self.View.EL_MainTask_LoopVList.gameObject.SetActive(self.ShowMainTasks);
            self.View.EL_BranchTask_Image.gameObject.SetActive(self.ShowBranchTasks);

            self.View.ES_MainTask.ET_On_Toggle.IsSelected(self.ShowMainTasks);
            self.View.ES_BranchTask.ET_On_Toggle.IsSelected(self.ShowBranchTasks);
        }

        private static void OnRefreshMainTaskItem(this DlgTask self, Transform transform, int index)
        {
            var itemMainTask = self.ItemMainTasks[index].BindTrans(transform);
            itemMainTask.Init(self.MainTasks[index], self.View.ET_TaskList_ToggleGroup);
        }

        private static void OnRefreshBranchTaskItem(this DlgTask self, Transform transform, int index)
        {
            var itemBranchTask = self.ItemBranchTasks[index].BindTrans(transform);
            itemBranchTask.Init(self.BranchTasks[index], self.View.ET_TaskList_ToggleGroup);
        }
    }
}