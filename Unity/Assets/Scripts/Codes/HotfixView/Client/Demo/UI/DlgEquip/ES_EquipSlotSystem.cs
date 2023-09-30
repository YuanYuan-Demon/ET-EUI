namespace ET.Client
{
    [FriendOfAttribute(typeof (ET.Client.ES_EquipSlot))]
    public static class ES_EquipSlotSystem
    {
        public static void Init(this ES_EquipSlot self, EquipPosition equipPosition)
        {
            self.EquipPosition = equipPosition;
            self.RefreshEquip();
        }

        public static void RefreshEquip(this ES_EquipSlot self)
        {
            var ec = self.ClientScene().GetComponent<EquipmentsComponent>();
            Item equip = ec.GetItemByPosition(self.EquipPosition);
            if (equip != null)
            {
                self.EI_Icon_Image.enabled = true;
                self.EI_Icon_Image.overrideSprite = IconHelper.LoadIconSprite("Items", equip.Config.Icon);
            }
            else
            {
                self.EI_Icon_Image.enabled = false;
            }
        }
    }
}