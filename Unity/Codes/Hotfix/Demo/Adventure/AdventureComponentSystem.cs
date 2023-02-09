using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClassAttribute(typeof(ET.AdventureComponent))]
    public static class AdventureComponentSystem
    {
        public static void ResetAdventure(this AdventureComponent self)
        {
            for (int i = 0; i < self.EnemyIdList.Count; i++)
            {
                self.ZoneScene().CurrentScene().GetComponent<UnitComponent>().Remove(self.EnemyIdList[i]);
            }
            TimerComponent.Instance?.Remove(ref self.BattleTimer);
            self.BattleTimer = 0;
            self.Round = 0;
            self.EnemyIdList.Clear();
            self.AliveEnemyIdList.Clear();

            Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            int maxHp = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.MaxHp);
            unit.GetComponent<NumericComponent>().Set(NumericType.Hp, maxHp);
            unit.GetComponent<NumericComponent>().Set(NumericType.IsAlive, 1);

            Game.EventSystem.PublishAsync(new EventType.AdventureRoundReset() { ZoneScene = self.ZoneScene() }).Coroutine();
        }

        public static async ETTask StartAdventure(this AdventureComponent self)
        {
            self.ResetAdventure();
            await self.CreateAdventureEnemy();
            self.ShowAdventureHpBarInfo(true);
            self.BattleTimer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 500, TimerType.BattleRound, self);
        }

        public static async ETTask CreateAdventureEnemy(this AdventureComponent self)
        {
            //获取玩家所在关卡配置
            Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            int levelId = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.AdventureStatus);
            var battleLevelData = BattleLevelConfigCategory.Instance.Get(levelId);

            //根据关卡配置创建怪物
            for (int i = 0; i < battleLevelData.MonsterIds.Length; i++)
            {
                Unit monsterUnit = await UnitFactory.CreateMonsterAsync(self.ZoneScene().CurrentScene(), battleLevelData.MonsterIds[i]);
                monsterUnit.Position = new UnityEngine.Vector3(1.5f, -2 + i, 0);
                self.EnemyIdList.Add(monsterUnit.Id);
            }
        }

        public static async ETTask PlayOneBattleRound(this AdventureComponent self)
        {
            await ETTask.CompletedTask;
        }
    }

    [Timer(TimerType.BattleRound)]
    public class AdventureBattleRoundTimer : ATimer<AdventureComponent>
    {
        public override void Run(AdventureComponent t)
        {
            t?.PlayOneBattleRound().Coroutine();
        }
    }
}