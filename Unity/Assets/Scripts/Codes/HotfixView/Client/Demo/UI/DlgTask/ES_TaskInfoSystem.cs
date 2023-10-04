using UnityEngine;

namespace ET.Client
{
    [FriendOfAttribute(typeof (ES_TaskInfo))]
    public static class ES_TaskInfoSystem
    {
        public static void Refresh(this ES_TaskInfo self, TaskInfo taskInfo)
        {
            var indent = new string(' ', 4);
            self.TaskInfo = taskInfo;
            var config = taskInfo.Config;
            self.ET_TaskName_TextMeshProUGUI.text = $"{indent}{config.Name}";
            self.ET_Desc_TextMeshProUGUI.text = $"{indent}{config.Overview}";
            self.ET_Target_TextMeshProUGUI.text = $"{indent}{taskInfo.GetTargetString()}";
            self.ET_RewardBase_TextMeshProUGUI.text = $"{indent}金币: {config.RewardGold,-8}{indent}经验: {config.RewardExp,-8}";
            self.EL_RewardItems_LoopHList.AddItemRefreshListener(self.OnRefreshRewardItem);
            self.AddUIScrollItems(ref self.RewardItems, config.RewardItems.Count);
        }

        private static void OnRefreshRewardItem(this ES_TaskInfo self, Transform transform, int index)
        {
            var itemTask = self.RewardItems[index].BindTrans(transform);
            itemTask.Refresh(self.TaskInfo.Config.RewardItems[index]);
        }
    }
}