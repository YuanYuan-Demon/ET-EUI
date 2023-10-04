namespace ET.Client
{
    [FriendOfAttribute(typeof (Item))]
    public static class Scroll_Item_TaskRewardItemSystem
    {
        public static void Refresh(this Scroll_Item_TaskRewardItem self, TaskReward reward)
        {
            var config = ItemConfigCategory.Instance.Get(reward.ItemId);
            self.EI_Icon_Image.overrideSprite = IconHelper.LoadIconSprite("Items", config.Icon);
            self.ET_Count_Text.text = reward.Count.ToString();
        }
    }
}