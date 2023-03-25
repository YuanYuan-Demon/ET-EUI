using System;

namespace ET.Server
{
    public static class PlayerOfflineOutTimeComponentSystem
    {
        #region 生命周期

        public class PlayerOfflineOutTimeComponentAwakeSystem : AwakeSystem<PlayerOfflineOutTimeComponent>
        {
            protected override void Awake(PlayerOfflineOutTimeComponent self)
            {
                self.Timer = TimerComponent.Instance.NewOnceTimer(
                    TimeHelper.ServerNow() + 10 * TimeHelper.Second,
                    TimerInvokeType.PlayerOfflineOutTime,
                    self);
            }
        }

        public class PlayerOfflineOutTimeComponentDestroySystem : DestroySystem<PlayerOfflineOutTimeComponent>
        {
            protected override void Destroy(PlayerOfflineOutTimeComponent self)
            {
                TimerComponent.Instance.Remove(ref self.Timer);
            }
        }

        #endregion 生命周期

        #region 定时器

        [Invoke(TimerInvokeType.PlayerOfflineOutTime)]
        public class PlayerOfflineOutTime : ATimer<PlayerOfflineOutTimeComponent>
        {
            protected override void Run(PlayerOfflineOutTimeComponent self)
            {
                try
                {
                    self.KickPlayer();
                }
                catch (Exception e)
                {
                    Log.Error($"PlayerOffline timer error: {self.Id}\n{e}");
                }
            }
        }

        #endregion 定时器

        public static void KickPlayer(this PlayerOfflineOutTimeComponent self)
        {
            DisconnectHelper.KickPlayer(self.GetParent<Player>()).Coroutine();
        }
    }
}