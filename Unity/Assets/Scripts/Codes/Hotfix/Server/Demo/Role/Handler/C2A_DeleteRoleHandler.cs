using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof (RoleInfo))]
    [MessageHandler(SceneType.Account)]
    public class C2A_DeleteRoleHandler: AMRpcHandler<C2A_DelteRole, A2C_DelteRole>
    {
        protected override async ETTask Run(Session session, C2A_DelteRole request, A2C_DelteRole response)
        {
            Scene scene = session.DomainScene();

#region 校验

            //重复请求校验
            if (session.GetComponent<SessionLoginComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                session.Disconnect();
                return;
            }

            //令牌校验
            string token = scene.GetComponent<TokenComponent>().Get(request.AccountId);
            ;

            if (token is null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                session.Disconnect();
                return;
            }

#endregion 校验

#region 删除角色

            using (session.AddComponent<SessionLoginComponent>()) //创建角色时不能进行查询
            {
                //删除角色
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.DeleteRole, request.AccountId))
                {
                    List<RoleInfo> roleInfos = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                            .Query<RoleInfo>(r => r.Id == request.RoleId && r.ServerId == request.ServerId);
                    if (roleInfos?.Count < 0)
                    {
                        response.Error = ErrorCode.ERR_RoleNotExist;
                        return;
                    }

                    //保存数据库
                    roleInfos[0].Status = RoleInfoStatus.Freeze;
                    await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save(roleInfos[0]);
                    //发送响应
                    response.RoleId = roleInfos[0].Id;
                }
            }

#endregion 删除角色
        }
    }
}