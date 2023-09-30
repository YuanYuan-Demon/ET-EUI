using System;

namespace ET.Server
{
    public static class AccountCheckOutTimeComponentSystem
    {
        public static void DeleteSession(this AccountCheckOutTimeComponent self)
        {
            var session = self.GetParent<Session>();
            var accountSessionsComponent = session.DomainScene().GetComponent<AccountSessionsComponent>();

            long instanceId = accountSessionsComponent.Get(self.AccountId);
            if (session.InstanceId == instanceId)
            {
                accountSessionsComponent.Remove(self.AccountId);
            }

            session.Send(new A2C_Disconnect() { Error = 1 });
            session.Disconnect();
        }

#region 定时任务

        [Invoke(TimerInvokeType.AccountSessionCheckOutTime)]
        public class AccountSessionCheckOutTimer: ATimer<AccountCheckOutTimeComponent>
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

#region 生命周期

        public class AccountCheckOutTimeComponentAwakeSystem: AwakeSystem<AccountCheckOutTimeComponent, long>
        {
            protected override void Awake(AccountCheckOutTimeComponent self, long name)
            {
                self.AccountId = name;
                TimerComponent.Instance.Remove(ref self.Timer);
                self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 10 * TimeHelper.Minute,
                    TimerInvokeType.AccountSessionCheckOutTime, self);
            }
        }

        public class AccountCheckOutTimeComponentDestroySystem: DestroySystem<AccountCheckOutTimeComponent>
        {
            protected override void Destroy(AccountCheckOutTimeComponent self)
            {
                self.AccountId = 0;
                TimerComponent.Instance.Remove(ref self.Timer);
            }
        }

#endregion 生命周期
    }
}