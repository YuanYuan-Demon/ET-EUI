using System;

namespace ET.Server
{
    public static class AccountCheckOutTimeComponentSystem
    {
        #region 生命周期

        public class AccountCheckOutTimeComponentAwakeSystem : AwakeSystem<AccountCheckOutTimeComponent, long>
        {
            protected override void Awake(AccountCheckOutTimeComponent self, long acccountId)
            {
                self.AccountId = acccountId;
                TimerComponent.Instance.Remove(ref self.Timer);
                self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 10 * TimeHelper.Minute, TimerInvokeType.AccountSessionCheckOutTime, self);
            }
        }

        public class AccountCheckOutTimeComponentDestroySystem : DestroySystem<AccountCheckOutTimeComponent>
        {
            protected override void Destroy(AccountCheckOutTimeComponent self)
            {
                self.AccountId = 0;
                TimerComponent.Instance.Remove(ref self.Timer);
            }
        }

        #endregion 生命周期

        #region 定时任务

        [Invoke(TimerInvokeType.AccountSessionCheckOutTime)]
        public class AccountSessionCheckOutTimer : ATimer<AccountCheckOutTimeComponent>
        {
            protected override void Run(AccountCheckOutTimeComponent self)
            {
                try
                {
                    self.DeleteSession();
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }

        #endregion 定时任务

        public static void DeleteSession(this AccountCheckOutTimeComponent self)
        {
            Session session = self.GetParent<Session>();
            AccountSessionsComponent accountSessionsComponent = session.DomainScene().GetComponent<AccountSessionsComponent>();

            var instanceId = accountSessionsComponent.Get(self.AccountId);
            if (session.InstanceId == instanceId)
            {
                accountSessionsComponent.Remove(self.AccountId);
            }
            session.Send(new A2C_Disconnect() { Error = 1 });
            session.Disconnect();
        }
    }
}