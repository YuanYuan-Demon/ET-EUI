using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [FriendOfAttribute(typeof (CRoleInfosComponent))]
    public static class LoginHelper
    {
        /// <summary>
        ///     连接网关负载均衡服务器, 请求进入游戏
        /// </summary>
        /// <param name="clientScene"> </param>
        /// <returns> </returns>
        public static async ETTask<int> EnterGame(Scene clientScene)
        {
            var roleInfosComponent = clientScene.GetComponent<CRoleInfosComponent>();
            var accountInfoComponent = clientScene.GetComponent<AccountInfoComponent>();
            var realmAddress = accountInfoComponent.RealmAddress;

#region 连接Realm服务器,获取分配的Gate服务器

            //realmSession = clientScene.GetComponent<NetClientComponent>().Create(NetworkHelper.ToIPEndPoint(realmAddress));

            R2C_LoginRealm r2c_LoginRealm;
            try
            {
                using var realmSession = await RouterHelper.CreateRouterSession(clientScene, NetworkHelper.ToIPEndPoint(realmAddress));
                r2c_LoginRealm = await realmSession.Call(new C2R_LoginRealm()
                        {
                            RealmToken = accountInfoComponent.RealmToken, AccountId = accountInfoComponent.AccountId,
                        }) as
                        R2C_LoginRealm;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
            }

            if (r2c_LoginRealm.Error != ErrorCode.ERR_Success)
                return r2c_LoginRealm.Error;

            Log.Warning($"GateAddress: {r2c_LoginRealm.GateAddress}");

#endregion 连接Realm服务器,获取分配的Gate服务器

#region 连接Gate网关服务器

            var gateSession = await RouterHelper.CreateRouterSession(clientScene, NetworkHelper.ToIPEndPoint(r2c_LoginRealm.GateAddress));
            clientScene.GetComponent<SessionComponent>().Session = gateSession;

            G2C_LoginGameGate g2c_LoginGameGate;
            try
            {
                g2c_LoginGameGate = await gateSession.Call(new C2G_LoginGameGate()
                {
                    AccountId = accountInfoComponent.AccountId, Key = r2c_LoginRealm.GateSessionToken, RoleId = roleInfosComponent.CurRoleId,
                }) as G2C_LoginGameGate;
            }
            catch (Exception e)
            {
                Log.Error(e);
                gateSession?.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }

            if (g2c_LoginGameGate.Error != ErrorCode.ERR_Success)
                return g2c_LoginGameGate.Error;

            Log.Debug("登录Gate服务器成功");

#endregion 连接Gate网关服务器

#region 角色正式请求进入游戏逻辑服

            G2C_EnterGame g2c_EnterGameResponse;
            var wait = clientScene.GetComponent<ObjectWait>().Wait<Wait_SceneChangeFinish>();
            try
            {
                g2c_EnterGameResponse = await gateSession.Call(new C2G_EnterGame()) as G2C_EnterGame;
            }
            catch (Exception e)
            {
                Log.Error(e);
                gateSession?.Dispose();
                return ErrorCode.ERR_NetWorkError;
            }

            if (g2c_EnterGameResponse.Error != ErrorCode.ERR_Success)
                return g2c_EnterGameResponse.Error;

            clientScene.GetComponent<PlayerComponent>().MyId = g2c_EnterGameResponse.UnitId;
            roleInfosComponent.CurrentRole = roleInfosComponent.RoleInfos.FirstOrDefault(r => r.Id == g2c_EnterGameResponse.UnitId);
            await wait;
            Log.Debug("角色进入游戏成功");

#endregion 角色正式请求进入游戏逻辑服

            return ErrorCode.ERR_Success;
        }

#region 登录相关

        public static async ETTask<IResponse> Login(Scene clientScene, string account, string password)
        {
            try
            {
                // 创建一个ETModel层的Session
                //clientScene.RemoveComponent<RouterAddressComponent>();
                // 获取路由跟realmDispatcher地址
                var routerAddressComponent = clientScene.GetComponent<RouterAddressComponent>();
                if (routerAddressComponent == null)
                {
                    routerAddressComponent =
                            clientScene.AddComponent<RouterAddressComponent, string, int>(TGlobalConfigCategory.Instance.RouterHttpHost,
                                TGlobalConfigCategory.Instance.RouterHttpPort);
                    await routerAddressComponent.Init();

                    clientScene.AddComponent<NetClientComponent, AddressFamily>(routerAddressComponent.RouterManagerIPAddress.AddressFamily);
                }

                //IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);
                IPEndPoint accountAddress = new(IPAddress.Parse(ConstValue.AccountHost), ConstValue.AccountPort);

                var session = await RouterHelper.CreateRouterSession(clientScene, accountAddress);
                var response = await session.Call(new C2A_LoginAccount()
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
                var routerAddressComponent = clientScene.GetComponent<RouterAddressComponent>();
                if (routerAddressComponent == null)
                {
                    routerAddressComponent =
                            clientScene.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
                    await routerAddressComponent.Init();
                    clientScene.AddComponent<NetClientComponent, AddressFamily>(routerAddressComponent.RouterManagerIPAddress.AddressFamily);
                }

                //IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);
                IPEndPoint accountAddress = new(IPAddress.Parse(ConstValue.AccountHost), ConstValue.AccountPort);

                using var session = await RouterHelper.CreateRouterSession(clientScene, accountAddress);
                var response = await session.Call(new C2A_RegisterAccount()
                {
                    AccountName = account, Password = MD5Helper.StringMD5(password), //密码使用加密传输
                }) as A2C_RegisterAccount;

                if (response.Error != ErrorCode.ERR_Success)
                    session?.Dispose();

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
                response = await zoneScene.Call(new C2A_GetServerInfos()
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
                var serverInfoComponent = zoneScene.GetComponent<ServerInfosComponent>();
                foreach (var nServerInfo in response.NServerInfos)
                {
                    var serverInfo = serverInfoComponent.AddChild<ServerInfo>();
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
            var accountInfoComponent = zoneScene.GetComponent<AccountInfoComponent>();
            A2C_GetRealmKey response;
            try
            {
                response = await zoneScene.Call(new C2A_GetRealmKey()
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
                return response.Error;

            accountInfoComponent.RealmToken = response.RealmToken;
            accountInfoComponent.RealmAddress = response.RealmAddress;
            zoneScene.GetComponent<SessionComponent>().Session.Dispose();
            return ErrorCode.ERR_Success;
        }

#endregion 登录相关

#region 角色

        /// <summary>
        ///     获取当前服务器(区)角色列表
        /// </summary>
        /// <param name="zoneScene"> </param>
        /// <returns> </returns>
        public static async ETTask<int> GetRoles(Scene zoneScene)
        {
            A2C_GetRoles response;
            try
            {
                response = await zoneScene.Call(new C2A_GetRoles()
                {
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurServerId,
                }) as A2C_GetRoles;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
            }

            if (response.Error != ErrorCode.ERR_Success)
                return response.Error;

            var roleInfosComponent = zoneScene.GetComponent<CRoleInfosComponent>();
            roleInfosComponent.Clear();
            roleInfosComponent.AddRange(response.NRoleInfos);

            return ErrorCode.ERR_Success;
        }

        /// <summary>
        ///     创建角色
        /// </summary>
        /// <param name="zoneScene"> </param>
        /// <param name="roleName"> 角色名 </param>
        /// <param name="roleClass"></param>
        /// <returns> 状态码 </returns>
        public static async ETTask<int> CreateRole(Scene zoneScene, string roleName, int configId)
        {
            A2C_CreateRole response;
            try
            {
                var config = UnitConfigCategory.Instance.Get(configId);
                response = await zoneScene.Call(new C2A_CreateRole()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    Name = roleName,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurServerId,
                    ConfigId = configId,
                }) as A2C_CreateRole;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
            }

            if (response.Error != ErrorCode.ERR_Success)
                return response.Error;

            zoneScene.GetComponent<CRoleInfosComponent>().Add(response.NRoleInfo);
            return ErrorCode.ERR_Success;
        }

        public static async ETTask<int> DeleteRole(Scene zoneScene, long roleId)
        {
            A2C_DelteRole response;
            try
            {
                response = await zoneScene.Call(new C2A_DelteRole()
                {
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurServerId,
                    RoleId = roleId,
                }) as A2C_DelteRole;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorCode.ERR_NetWorkError;
            }

            if (response.Error != ErrorCode.ERR_Success)
                return response.Error;

            //删除本地数据
            zoneScene.GetComponent<CRoleInfosComponent>().Remove(response.RoleId);
            return ErrorCode.ERR_Success;
        }

#endregion 角色
    }
}