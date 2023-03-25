using System;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    public static class LoginHelper
    {
        #region 登录相关

        public static async ETTask<IResponse> Login(Scene clientScene, string account, string password)
        {
            try
            {
                // 创建一个ETModel层的Session
                //clientScene.RemoveComponent<RouterAddressComponent>();
                // 获取路由跟realmDispatcher地址
                RouterAddressComponent routerAddressComponent = clientScene.GetComponent<RouterAddressComponent>();
                if (routerAddressComponent == null)
                {
                    routerAddressComponent =
                            clientScene.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
                    await routerAddressComponent.Init();

                    clientScene.AddComponent<NetClientComponent, AddressFamily>(routerAddressComponent.RouterManagerIPAddress.AddressFamily);
                }

                //IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);
                IPEndPoint accountAddress = new(IPAddress.Parse(ConstValue.AccountHost), ConstValue.AccountPort);

                Session session = await RouterHelper.CreateRouterSession(clientScene, accountAddress);
                A2C_LoginAccount response = await session.Call(new C2A_LoginAccount()
                {
                    AccountName = account, Password = MD5Helper.StringMD5(password), //密码使用加密传输
                }) as A2C_LoginAccount;

                if (response.Error != ErrorCode.ERR_Success)
                {
                    session?.Dispose();
                    return response;
                }

                clientScene.AddComponent<SessionComponent>().Session = session;
                //clientScene.GetComponent<SessionComponent>().Session.AddComponent<PingComponent>();

                clientScene.GetComponent<AccountInfoComponent>().AccountId = response.AccountId;
                clientScene.GetComponent<AccountInfoComponent>().Token = response.Token;
                return response;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return new ErrorMessage(-1, "账号登录出错");
            }
        }

        public static async ETTask<IResponse> Register(Scene clientScene, string account, string password)
        {
            try
            {
                // 创建一个ETModel层的Session
                //clientScene.RemoveComponent<RouterAddressComponent>();
                // 获取路由跟realmDispatcher地址
                RouterAddressComponent routerAddressComponent = clientScene.GetComponent<RouterAddressComponent>();
                if (routerAddressComponent == null)
                {
                    routerAddressComponent =
                            clientScene.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
                    await routerAddressComponent.Init();
                    clientScene.AddComponent<NetClientComponent, AddressFamily>(routerAddressComponent.RouterManagerIPAddress.AddressFamily);
                }

                //IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);
                IPEndPoint accountAddress = new(IPAddress.Parse(ConstValue.AccountHost), ConstValue.AccountPort);

                using Session session = await RouterHelper.CreateRouterSession(clientScene, accountAddress);
                A2C_RegisterAccount response = await session.Call(new C2A_RegisterAccount()
                {
                    AccountName = account, Password = MD5Helper.StringMD5(password), //密码使用加密传输
                }) as A2C_RegisterAccount;

                if (response.Error != ErrorCode.ERR_Success)
                {
                    session?.Dispose();
                }

                return response;
                //clientScene.AddComponent<SessionComponent>().Session = session;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return new ErrorMessage(-1, "账号注册出错");
            }
        }

        /// <summary>
        ///     获取服务器列表
        /// </summary>
        /// <param name="zoneScene"> </param>
        /// <returns> 状态码 </returns>
        public static async ETTask<IResponse> GetServerInfos(Scene zoneScene)
        {
            A2C_GetServerInfos response;
            try
            {
                response = await zoneScene.GetSession().Call(new C2A_GetServerInfos()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                }) as A2C_GetServerInfos;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return new ErrorMessage(ErrorCode.ERR_NetWorkError, "网络异常");
            }

            if (response.Error == ErrorCode.ERR_Success)
            {
                //记录服务器列表信息
                ServerInfosComponent serverInfoComponent = zoneScene.GetComponent<ServerInfosComponent>();
                foreach (NServerInfo nServerInfo in response.NServerInfos)
                {
                    ServerInfo serverInfo = serverInfoComponent.AddChild<ServerInfo>();
                    serverInfo.FromNServerInfo(nServerInfo);
                    serverInfoComponent.Add(serverInfo);
                }
            }

            return response;
        }

        /// <summary>
        ///     向 Account账号服务器 申请网关负载均衡服务器 的token
        /// </summary>
        /// <param name="zoneScene"> </param>
        /// <returns> </returns>
        public static async ETTask<int> GetRealmKey(Scene zoneScene)
        {
            AccountInfoComponent accountInfoComponent = zoneScene.GetComponent<AccountInfoComponent>();
            A2C_GetRealmKey response;
            try
            {
                response = await zoneScene.GetSession().Call(new C2A_GetRealmKey()
                {
                    Token = accountInfoComponent.Token,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurServerId,
                    AccountId = accountInfoComponent.AccountId,
                }) as A2C_GetRealmKey;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
            }

            if (response.Error != ErrorCode.ERR_Success)
            {
                return response.Error;
            }

            accountInfoComponent.RealmToken = response.RealmToken;
            accountInfoComponent.RealmAddress = response.RealmAddress;
            zoneScene.GetComponent<SessionComponent>().Session.Dispose();
            return ErrorCode.ERR_Success;
        }

        #endregion 登录相关
    }
}