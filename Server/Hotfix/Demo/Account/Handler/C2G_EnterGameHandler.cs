﻿using System;

namespace ET
{
    [FriendClass(typeof(SessionPlayerComponent))]
    [FriendClass(typeof(SessionStatusComponent))]
    [FriendClassAttribute(typeof(ET.RoleInfo))]
    [FriendClassAttribute(typeof(ET.UnitGateComponent))]
    public class C2G_EnterGameHandler : AMRpcHandler<C2G_EnterGame, G2C_EnterGame>
    {
        private static async ETTask<long> EnterWorldChatServer(Unit unit)
        {
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "ChatInfo");
            Chat2G_EnterChat response = await MessageHelper.CallActor(startSceneConfig.InstanceId, new G2Chat_EnterChat()
            {
                UnitId = unit.Id,
                Name = unit.GetComponent<RoleInfo>().Name,
                GateSessionActorId = unit.GetComponent<UnitGateComponent>().GateSessionActorId
            }) as Chat2G_EnterChat;

            return response.ChatInfoUnitInstanceId;
        }

        protected override async ETTask Run(Session session, C2G_EnterGame request, G2C_EnterGame response, Action reply)
        {
            Scene scene = session.DomainScene();

            #region 校验

            //服务器类型校验
            if (scene.SceneType != SceneType.Gate)
            {
                Log.Error($"请求的Scene错误,当前Scene为:{scene.SceneType}");
                response.Error = ErrorCode.ERR_RequestSceneTypeError;
                reply();
                session.Disconnect();
                return;
            }

            //避免重复请求
            if (session.GetComponent<SessionLoginComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                return;
            }

            //检测是否存在Session到Player的映射
            SessionPlayerComponent sessionPlayerComponent = session.GetComponent<SessionPlayerComponent>();
            if (sessionPlayerComponent is null)
            {
                response.Error = ErrorCode.ERR_SessionPlayerError;
                reply();
                return;
            }

            //校验Player是否在线
            Player player = Game.EventSystem.Get(sessionPlayerComponent.PlayerInstanceId) as Player;
            if (player is null || player.IsDisposed)
            {
                response.Error = ErrorCode.ERR_NonePlayerError;
                reply();
                return;
            }

            #endregion 校验

            long instanceId = session.InstanceId;
            using (session.AddComponent<SessionLoginComponent>())
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, player.AccountId))
            {
                if (instanceId != session.InstanceId || player.IsDisposed)
                {
                    response.Error = ErrorCode.ERR_SessionPlayerError;
                    reply();
                    return;
                }

                var sessionStatusComponent = session.GetComponent<SessionStatusComponent>();
                if (sessionStatusComponent?.Status == SessionStatus.Game)
                {
                    response.Error = ErrorCode.ERR_SessionStatusError;
                    reply();
                    return;
                }

                //当前帐号已有角色在线
                if (player.PlayerState == PlayerState.Game)
                {
                    try
                    {
                        var reqEnter = await MessageHelper.CallLocationActor(player.UnitId, new G2M_RequestEnterGameStatus());
                        if (reqEnter.Error == ErrorCode.ERR_Success)
                        {
                            reply();
                            return;
                        }

                        Log.Error($"二次登陆失败: {reqEnter.Error} | {reqEnter.Message}");
                        response.Error = reqEnter.Error;
                        await DisconnectHelper.KickPlayer(player, true);
                        reply();
                        session.Disconnect();
                    }
                    catch (Exception e)
                    {
                        Log.Error($"二次登陆失败: {e}");
                        response.Error = ErrorCode.ERR_ReEnterGameError2;
                        await DisconnectHelper.KickPlayer(player, true);
                        reply();
                        session.Disconnect();
                    }
                    return;
                }

                //正常登录角色
                try
                {
                    //添加网关到游戏逻辑服的映射
                    //player.AddComponent<GateMapComponent>();
                    //gateMapComponent.Scene = await SceneFactory.Create(gateMapComponent, "GateMap", SceneType.Map);

                    //从数据库或缓存中加载出Unit实体及其相关组件
                    (bool isNewPlayer, Unit unit) = await UnitHelper.LoadUnit(player);
                    //unit.AddComponent<UnitGateComponent, long>(session.InstanceId);
                    unit.AddComponent<UnitGateComponent, long>(player.InstanceId);

                    player.ChatInfoInstanceId = await EnterWorldChatServer(unit); //登录聊天服

                    //玩家Unit上线后的初始化操作
                    await UnitHelper.InitUnit(unit, isNewPlayer);
                    response.UnitId = unit.Id;
                    reply();
                    //创建游戏对象(unit.Id = player.Id = roleId)
                    //Unit unit = UnitFactory.Create(gateMapComponent.Scene, player.Id, UnitType.Player);
                    //unit.AddComponent<UnitGateComponent, long>(session.InstanceId);

                    //将游戏对象传送至游戏逻辑服
                    long unitId = unit.Id;
                    StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Game");
                    await TransferHelper.Transfer(unit, startSceneConfig.InstanceId, startSceneConfig.Name);

                    player.UnitId = unitId;
                    //response.UnitId = unitId;
                    //reply();

                    //添加当前会话状态组件-更改当前会话状态
                    sessionStatusComponent = session.GetComponent<SessionStatusComponent>();
                    sessionStatusComponent ??= session.AddComponent<SessionStatusComponent>();
                    sessionStatusComponent.Status = SessionStatus.Game;
                    player.PlayerState = PlayerState.Game;
                }
                catch (Exception e)
                {
                    Log.Error($"角色进入游戏逻辑服出错: 帐号ID:{player.AccountId} 角色ID:{player.Id} 异常: {e}");
                    response.Error = ErrorCode.ERR_EnterGameError;
                    reply();
                    await DisconnectHelper.KickPlayer(player, true);
                    session.Disconnect();
                    return;
                }
            }
        }
    }
}