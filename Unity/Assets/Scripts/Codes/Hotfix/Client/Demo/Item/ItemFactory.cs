namespace ET.Client
{
    public static class ItemFactory
    {
        public static Item Create(Scene self, NItem nItem)
        {
            var item = self.AddChild<Item, int>(nItem.ItemConfigId);
            item.FromMessage(nItem);
            return item;
        }

        public static Item Create(this BagComponent self, NItem nItem)
        {
            var item = self.AddChild<Item, int>(nItem.ItemConfigId);
            item.FromMessage(nItem);
            return item;
        }
    }
}