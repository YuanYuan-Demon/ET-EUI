using System;
using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    public static class LoginHelper
    {
        #region 登录相关

        public static async ETTask<int> Login(Scene clientScene, string account, string password)
        {
            try
            {
                // 创建一个ETModel层的Session
                clientScene.RemoveComponent<RouterAddressComponent>();
                // 获取路由跟realmDispatcher地址
                RouterAddressComponent routerAddressComponent = clientScene.GetComponent<RouterAddressComponent>();
                if (routerAddressComponent == null)
                {
                    routerAddressComponent = clientScene.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
                    await routerAddressComponent.Init();

                    clientScene.AddComponent<NetClientComponent, AddressFamily>(routerAddressComponent.RouterManagerIPAddress.AddressFamily);
                }
                IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);

                Session session = await RouterHelper.CreateRouterSession(clientScene, realmAddress);
                var response = await session.Call(
                    new C2A_LoginAccount()
                    {
                        AccountName = account,
                        Password = password
                    }) as A2C_LoginAccount;

                if (response.Error != ErrorCode.ERR_Success)
                {
                    session?.Dispose();
                    return response.Error;
                }
                clientScene.AddComponent<SessionComponent>().Session = session;
                //clientScene.GetComponent<SessionComponent>().Session.AddComponent<PingComponent>();

                clientScene.GetComponent<AccountInfoComponent>().AccountId = response.AccountId;
                clientScene.GetComponent<AccountInfoComponent>().Token = response.Token;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return ErrorCode.ERR_Success;
        }

        public static async ETTask LoginExample(Scene clientScene, string account, string password)
        {
            try
            {
                // 创建一个ETModel层的Session
                clientScene.RemoveComponent<RouterAddressComponent>();
                // 获取路由跟realmDispatcher地址
                RouterAddressComponent routerAddressComponent = clientScene.GetComponent<RouterAddressComponent>();
                if (routerAddressComponent == null)
                {
                    routerAddressComponent = clientScene.AddComponent<RouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
                    await routerAddressComponent.Init();

                    clientScene.AddComponent<NetClientComponent, AddressFamily>(routerAddressComponent.RouterManagerIPAddress.AddressFamily);
                }
                IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);

                R2C_Login r2CLogin;
                using (Session session = await RouterHelper.CreateRouterSession(clientScene, realmAddress))
                {
                    r2CLogin = await session.Call(
                        new C2R_Login()
                        {
                            Account = account,
                            Password = password
                        }) as R2C_Login;
                }

                // 创建一个gate Session,并且保存到SessionComponent中
                Session gateSession = await RouterHelper.CreateRouterSession(clientScene, NetworkHelper.ToIPEndPoint(r2CLogin.Address));
                clientScene.AddComponent<SessionComponent>().Session = gateSession;

                G2C_LoginGate g2CLoginGate = await gateSession.Call(
                    new C2G_LoginGate()
                    {
                        Key = r2CLogin.Key,
                        GateId = r2CLogin.GateId
                    }) as G2C_LoginGate;

                Log.Debug("登陆gate成功!");

                await EventSystem.Instance.PublishAsync(clientScene, new EventType.LoginFinish());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        /// <summary>
        /// 获取服务器列表
        /// </summary>
        /// <param name="zoneScene"> </param>
        /// <returns> 状态码 </returns>
        public static async ETTask<int> GetServerInfos(Scene zoneScene)
        {
            A2C_GetServerInfos response;
            try
            {
                response = await zoneScene.GetSession().Call(new C2A_GetServerInfos()
                {
                    AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
                    Token = zoneScene.GetComponent<AccountInfoComponent>().Token
                }) as A2C_GetServerInfos;
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
            //记录服务器列表信息
            var serverInfoComponent = zoneScene.GetComponent<ServerInfosComponent>();
            foreach (var nServerInfo in response.NServerInfos)
            {
                var serverInfo = serverInfoComponent.AddChild<ServerInfo>();
                serverInfo.FromNServerInfo(nServerInfo);
                serverInfoComponent.Add(serverInfo);
            }
            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 向 Account账号服务器 申请网关负载均衡服务器 的token
        /// </summary>
        /// <param name="zoneScene"> </param>
        /// <returns> </returns>
        public static async ETTask<int> GetRealmKey(Scene zoneScene)
        {
            A2C_GetRealmKey response = null;
            AccountInfoComponent accountInfoComponent = zoneScene.GetComponent<AccountInfoComponent>();
            try
            {
                response = await zoneScene.GetSession().Call(new C2A_GetRealmKey()
                {
                    Token = accountInfoComponent.Token,
                    ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurServerId,
                    AccountId = accountInfoComponent.AccountId
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

        //#region 角色

        ///// <summary>
        ///// 获取当前服务器(区)角色列表
        ///// </summary>
        ///// <param name="zoneScene"> </param>
        ///// <returns> </returns>
        //public static async ETTask<int> GetRoles(Scene zoneScene)
        //{
        //    A2C_GetRoles response = null;
        //    try
        //    {
        //        response = await zoneScene.GetSession().Call(new C2A_GetRoles()
        //        {
        //            Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
        //            ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurServerId,
        //            AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
        //        }) as A2C_GetRoles;
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Error(e);
        //        return ErrorCode.ERR_NetWorkError;
        //    }

        //    if (response.Error != ErrorCode.ERR_Success)
        //    {
        //        return response.Error;
        //    }

        //    zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Clear();//UNDONE: 孩子节点并未清除
        //    for (int i = 0; i < response.NRoleInfos.Count; i++)
        //    {
        //        var roleInfo = zoneScene.GetComponent<RoleInfosComponent>().AddChild<RoleInfo>();
        //        roleInfo.FromNServerInfo(response.NRoleInfos[i]);
        //        zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Add(roleInfo);
        //    }

        //    return ErrorCode.ERR_Success;
        //}

        ///// <summary>
        ///// 创建角色
        ///// </summary>
        ///// <param name="zoneScene"> </param>
        ///// <param name="roleName"> 角色名 </param>
        ///// <returns> 状态码 </returns>
        //public static async ETTask<int> CreateRole(Scene zoneScene, string roleName)
        //{
        //    A2C_CreateRole response = null;
        //    try
        //    {
        //        response = await zoneScene.GetSession().Call(new C2A_CreateRole()
        //        {
        //            AccountId = zoneScene.GetComponent<AccountInfoComponent>().AccountId,
        //            Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
        //            Name = roleName,
        //            ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurServerId,
        //        }) as A2C_CreateRole;
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Error(e);
        //        return ErrorCode.ERR_NetWorkError;
        //    }

        //    if (response.Error != ErrorCode.ERR_Success)
        //    {
        //        return response.Error;
        //    }

        //    var newRoleInfo = zoneScene.GetComponent<RoleInfosComponent>().AddChild<RoleInfo>();
        //    newRoleInfo.FromNServerInfo(response.NRoleInfo);
        //    zoneScene.GetComponent<RoleInfosComponent>().RoleInfos.Add(newRoleInfo);
        //    return ErrorCode.ERR_Success;
        //}

        //public static async ETTask<int> DeleteRole(Scene zoneScene, long roleId)
        //{
        //    A2C_DelteRole response = null;
        //    try
        //    {
        //        response = await zoneScene.GetSession().Call(new C2A_DelteRole()
        //        {
        //            Token = zoneScene.GetComponent<AccountInfoComponent>().Token,
        //            ServerId = zoneScene.GetComponent<ServerInfosComponent>().CurServerId,
        //            RoleId = roleId
        //        }) as A2C_DelteRole;
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Error(e);
        //        return ErrorCode.ERR_NetWorkError;
        //    }

        //    if (response.Error != ErrorCode.ERR_Success)
        //    {
        //        return response.Error;
        //    }

        //    //删除本地数据
        //    var roleInfos = zoneScene.GetComponent<RoleInfosComponent>().RoleInfos;
        //    int index = roleInfos.FindIndex(role => role.Id == response.RoleId);
        //    roleInfos.RemoveAt(index);
        //    return ErrorCode.ERR_Success;
        //}

        //#endregion 角色

        /// <summary>
        /// 连接网关负载均衡服务器, 请求进入游戏
        /// </summary>
        /// <param name="zoneScene"> </param>
        /// <returns> </returns>
        //public static async Task<int> EnterGame(Scene zoneScene)
        //{
        //    string realmAddress = zoneScene.GetComponent<AccountInfoComponent>().RealmAddress;
        //    Session gateSession;

        //    #region 连接Realm服务器,获取分配的Gate服务器

        //    gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(realmAddress));

        //    R2C_LoginRealm realmResponse = null;
        //    AccountInfoComponent accountInfoComponent = zoneScene.GetComponent<AccountInfoComponent>();
        //    try
        //    {
        //        realmResponse = await gateSession.Call(new C2R_LoginRealm()
        //        {
        //            RealmToken = accountInfoComponent.RealmToken,
        //            AccountId = accountInfoComponent.AccountId,
        //        }) as R2C_LoginRealm;
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Error(e);
        //        gateSession?.Dispose();
        //        return ErrorCode.ERR_NetWorkError;
        //    }
        //    gateSession?.Dispose();

        //    if (realmResponse.Error != ErrorCode.ERR_Success)
        //    {
        //        return realmResponse.Error;
        //    }
        //    Log.Warning($"GateAddress: {realmResponse.GateAddress}");

        //    #endregion 连接Realm服务器,获取分配的Gate服务器

        //    #region 连接Gate网关服务器

        //    gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(realmResponse.GateAddress));
        //    gateSession.AddComponent<PingComponent>();
        //    zoneScene.GetComponent<SessionComponent>().Session = gateSession;
        //    G2C_LoginGameGate gateResponse;
        //    try
        //    {
        //        gateResponse = await gateSession.Call(new C2G_LoginGameGate()
        //        {
        //            AccountId = accountInfoComponent.AccountId,
        //            Key = realmResponse.GateSessionToken,
        //            RoleId = zoneScene.GetComponent<RoleInfosComponent>().CurRoleId
        //        }) as G2C_LoginGameGate;
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Error(e);
        //        gateSession?.Dispose();
        //        return ErrorCode.ERR_NetWorkError;
        //    }

        //    if (gateResponse.Error != ErrorCode.ERR_Success)
        //    {
        //        gateSession?.Dispose();
        //        return gateResponse.Error;
        //    }
        //    Log.Debug("登录Gate服务器成功");

        //    #endregion 连接Gate网关服务器

        //    #region 角色正式请求进入游戏逻辑服

        //    G2C_EnterGame g2cEnterGameResponse;
        //    var requestTask = gateSession.Call(new C2G_EnterGame());
        //    try
        //    {
        //        g2cEnterGameResponse = await requestTask as G2C_EnterGame;
        //    }
        //    catch (Exception e)
        //    {
        //        Log.Error(e);
        //        gateSession?.Dispose();
        //        return ErrorCode.ERR_NetWorkError;
        //    }

        //    if (g2cEnterGameResponse.Error != ErrorCode.ERR_Success)
        //    {
        //        return g2cEnterGameResponse.Error;
        //    }

        //    zoneScene.GetComponent<PlayerComponent>().MyId = g2cEnterGameResponse.UnitId;

        //    await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_SceneChangeFinish>();
        //    Log.Debug("角色进入游戏成功");

        //    #endregion 角色正式请求进入游戏逻辑服

        //    return ErrorCode.ERR_Success;
        //}
    }
}