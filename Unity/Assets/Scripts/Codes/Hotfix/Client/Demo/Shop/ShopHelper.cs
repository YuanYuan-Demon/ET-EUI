using System;

namespace ET.Client
{
    public static class ShopHelper
    {
        public static async ETTask<IResponse> BuyItem(Scene clientScene, int configId, int count)
        {
            var request = new C2M_BuyItem { ConfigId = configId, Count = count };
            M2C_BuyItem response;
            try
            {
                response = await clientScene.Call(request) as M2C_BuyItem;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return null;
            }
            return response;
        }
    }
}