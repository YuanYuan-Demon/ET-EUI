using System.Text.RegularExpressions;

namespace ET.Server
{
    [MessageHandler(SceneType.Account)]
    public class C2A_LoginAccountHandler : AMRpcHandler<C2A_LoginAccount, A2C_LoginAccount>
    {
        protected override async ETTask Run(Session session, C2A_LoginAccount request, A2C_LoginAccount response)
        {
            Scene scene = session.DomainScene();

            #region 校验

            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            //避免重复请求
            if (session.GetComponent<SessionLoginComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                session.Disconnect();
                response.Message = $"你的登录请求太过频繁,请稍后再试";
                return;
            }
            //校验账号信息
            if (string.IsNullOrEmpty(request.AccountName) || string.IsNullOrEmpty(request.Password))
            {
                response.Error = ErrorCode.ERR_AccountInfoIsNull;
                response.Message = $"账号或密码不能为空";
                session.Disconnect();
                return;
            }

            if (!Regex.IsMatch(request.AccountName.Trim(), @"^[a-zA-Z0-9_-]{4,20}$"))
            {
                response.Error = ErrorCode.ERR_AccountNameFormError;
                response.Message = $"账号格式错误";
                session.Disconnect();
                return;
            }

            #endregion 校验

            #region 登录/创建帐号

            using (session.AddComponent<SessionLoginComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.AccountName.Trim().GetHashCode()))
                {
                    var accountResult = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                        .Query<Account>(d => d.AccountName.Equals(request.AccountName.Trim()));
                    Account account = null;
                    //数据库中存在  --> 登录
                    if (accountResult?.Count > 0)
                    {
                        account = accountResult[0];
                        session.AddChild(account);
                        if (account.AccountType == (int)AccountType.BlackList)
                        {
                            response.Error = ErrorCode.ERR_AccountStatusAbnormal;
                            response.Message = $"当前账号状态异常";
                            session.Disconnect();
                            return;
                        }
                        if (account.Password != request.Password)
                        {
                            response.Error = ErrorCode.ERR_AccountInfoError;
                            response.Message = $"账号或密码错误";
                            session.Disconnect();
                            return;
                        }
                    }
                    //数据库中不存在 --> 创建
                    else
                    {
                        account = session.AddChild<Account>();
                        account.AccountName = request.AccountName;
                        account.Password = request.Password;
                        account.CreateTime = TimeHelper.ServerNow();
                        account.AccountType = (int)AccountType.General;
                        await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save(account);
                    }

                    //通知登录中心
                    long loginCenterInstanceId = StartSceneConfigCategory.Instance.LoginCenterConfig.InstanceId;
                    var loginAccountResponse = await MessageHelper.CallActor(loginCenterInstanceId,
                        new A2L_LoginAccountRequest()
                        {
                            AccountId = account.Id
                        }) as L2A_LoginAccountResponse;
                    if (loginAccountResponse?.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = loginAccountResponse.Error;
                        response.Message = loginAccountResponse?.Message;
                        session?.Disconnect();
                        account?.Dispose();
                        return;
                    }

                    //获取当前帐号登陆情况并强制下线
                    long accountSessionInstanceId = scene.GetComponent<AccountSessionsComponent>().Get(account.Id);
                    var otherSession = Root.Instance.Get(accountSessionInstanceId) as Session;
                    otherSession?.Send(new A2C_Disconnect() { Error = 0 });
                    otherSession?.Disconnect();
                    //账号服务器添加记录
                    scene.GetComponent<AccountSessionsComponent>().Add(account.Id, session.InstanceId);

                    //添加超时检测组件
                    session.AddComponent<AccountCheckOutTimeComponent, long>(account.Id);

                    //发放登陆令牌
                    string token = TimeHelper.ServerNow().ToString() + RandomGenerator.RandomNumber(int.MinValue, int.MinValue).ToString();
                    //scene.GetComponent<TokenComponent>().Remove(account.Id);
                    scene.GetComponent<TokenComponent>().AddOrModify(account.Id, token);

                    response.AccountId = account.Id;
                    response.Token = token;

                    account?.Dispose();
                }
            }

            #endregion 登录/创建帐号
        }
    }
}