using System;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.EquipInfoComponent))]
    public static class ItemApplyHelper
    {
        #region 装备

        /// <summary>
        /// 穿戴装备
        /// </summary>
        /// <param name="ZoneScene"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static async ETTask<int> EquipItem(Scene ZoneScene, long itemId)
        {
            Item item = ItemHelper.GetItem(ZoneScene, itemId, ItemContainerType.Bag);

            if (item == null)
            {
                return ErrorCode.ERR_ItemNotExist;
            }

            M2C_EquipItem m2CEquipItem = null;

            try
            {
                m2CEquipItem = (M2C_EquipItem)await ZoneScene.Call(new C2M_EquipItem() { ItemUid = itemId });
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            return m2CEquipItem.Error;
        }

        /// <summary>
        /// 卸下装备
        /// </summary>
        /// <param name="ZoneScene"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static async ETTask<int> UnloadEquipItem(Scene ZoneScene, long itemId)
        {
            Item item = ItemHelper.GetItem(ZoneScene, itemId, ItemContainerType.RoleInfo);
            if (item == null)
            {
                return ErrorCode.ERR_ItemNotExist;
            }

            M2C_UnloadEquipItem response = null;

            try
            {
                response = await ZoneScene.GetComponent<SessionComponent>().Session.Call(
                    new C2M_UnloadEquipItem()
                    {
                        EquipPosition = item.GetComponent<EquipInfoComponent>().Config.EquipPosition
                    })
                    as M2C_UnloadEquipItem;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            return response.Error;
        }

        #endregion 装备

        #region 背包

        /// <summary>
        /// 售卖背包物品
        /// </summary>
        /// <param name="clientScene"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public static async ETTask<int> SellBagItem(Scene clientScene, long itemId)
        {
            Item item = ItemHelper.GetItem(clientScene, itemId, ItemContainerType.Bag);

            if (item == null)
            {
                return ErrorCode.ERR_ItemNotExist;
            }

            M2C_SellItem m2cSellItem;
            try
            {
                m2cSellItem = await clientScene.GetComponent<SessionComponent>().Session.Call(new C2M_SellItem() { ItemUid = itemId }) as M2C_SellItem;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }
            return m2cSellItem.Error;
        }

        #endregion 背包
    }
}