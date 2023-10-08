using System;

namespace ET.Client
{
    [ObjectSystem]
    public class RouterCheckComponentAwakeSystem: AwakeSystem<RouterCheckComponent>
    {
        protected override void Awake(RouterCheckComponent self) => CheckAsync(self).Coroutine();

        private static async ETTask CheckAsync(RouterCheckComponent self)
        {
            var session = self.GetParent<Session>();
            var instanceId = self.InstanceId;

            while (true)
            {
                if (self.InstanceId != instanceId)
                    return;

                await TimerComponent.Instance.WaitAsync(1000);

                if (self.InstanceId != instanceId)
                    return;

                var time = TimeHelper.ClientFrameTime();

                if (time - session.LastRecvTime < 7 * 1000)
                    continue;

                try
                {
                    var sessionId = session.Id;

                    (var localConn, var remoteConn) = await NetServices.Instance.GetChannelConn(session.ServiceId, sessionId);

                    var realAddress = self.GetParent<Session>().RemoteAddress;
                    Log.Info($"get recvLocalConn start: {self.ClientScene().Id} {realAddress} {localConn} {remoteConn}");

                    (var recvLocalConn, var routerAddress)
                            = await RouterHelper.GetRouterAddress(self.ClientScene(), realAddress, localConn, remoteConn);
                    if (recvLocalConn == 0)
                    {
                        Log.Error($"get recvLocalConn fail: {self.ClientScene().Id} {routerAddress} {realAddress} {localConn} {remoteConn}");
                        continue;
                    }

                    Log.Info($"get recvLocalConn ok: {self.ClientScene().Id} {routerAddress} {realAddress} {recvLocalConn} {localConn} {remoteConn}");

                    session.LastRecvTime = TimeHelper.ClientNow();

                    NetServices.Instance.ChangeAddress(session.ServiceId, sessionId, routerAddress);
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }
        }
    }
}