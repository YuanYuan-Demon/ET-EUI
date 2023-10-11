﻿namespace ET.Server
{
    [FriendOf(typeof (RoleInfo))]
    [MessageHandler(SceneType.Account)]
    public class C2A_CreateRoleHandler: AMRpcHandler<C2A_CreateRole, A2C_CreateRole>
    {
        protected override async ETTask Run(Session session, C2A_CreateRole request, A2C_CreateRole response)
        {
            var scene = session.DomainScene();

#region 校验

            //重复请求校验
            if (session.GetComponent<SessionLoginComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                session.Disconnect();
                return;
            }

            //令牌校验
            var token = scene.GetComponent<TokenComponent>().Get(request.AccountId);
            ;

            if (token is null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                session.Disconnect();
                return;
            }

            //角色名校验
            if (string.IsNullOrEmpty(request.Name))
            {
                response.Error = ErrorCode.ERR_RoleNameIsNull;
                session.Disconnect();
                return;
            }

#endregion 校验

#region 创建角色

            using (session.AddComponent<SessionLoginComponent>()) //创建角色时不能进行查询
            {
                //创建角色
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRole, request.AccountId))
                {
                    //角色名查重
                    var roleInfos = await session.QueryDB<RoleInfo>(r => r.ServerId == request.ServerId && r.Name == request.Name);
                    if (roleInfos?.Count > 0)
                    {
                        response.Error = ErrorCode.ERR_RoleNameSame;
                        return;
                    }

                    var config = UnitConfigCategory.Instance.Get(request.ConfigId);
                    //保存数据库
                    var roleInfo = session.AddChildWithId<RoleInfo>(IdGenerater.Instance.GenerateUnitId(request.ServerId));
                    roleInfo.Name = request.Name;
                    roleInfo.ServerId = request.ServerId;
                    roleInfo.Status = (int)RoleInfoStatus.Normal;
                    roleInfo.AccountId = request.AccountId;
                    roleInfo.CreateTime = TimeHelper.ServerNow();
                    roleInfo.Level = 1;
                    roleInfo.RoleClass = config.Class;
                    roleInfo.LastLoginTime = 0;
                    roleInfo.ConfigId = request.ConfigId;
                    // await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save(roleInfo);
                    roleInfo.AddOrUpdateUnitCache();
                    //发送响应
                    response.NRoleInfo = roleInfo.ToNRoleInfo();
                    roleInfo?.Dispose();
                }
            }

#endregion 创建角色
        }
    }
}