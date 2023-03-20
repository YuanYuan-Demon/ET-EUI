using ET.Client.EventType;
using Unity.Mathematics;

namespace ET.Client
{
    [FriendOf(typeof(AdventureComponent))]
    public static class AdventureComponentSystem
    {
        public static void SetBattleRandomSeed(this AdventureComponent self)
        {
            uint seed = (uint)self.ClientScene().GetMyNumericComponent().GetAsInt(NumericType.BattleRandomSeed);
            if (self.Random == null)
            {
                self.Random = new SRandom(seed);
            }
            else
            {
                self.Random.SetRandomSeed(seed);
            }
        }

        /// <summary>
        /// 重置冒险
        /// </summary>
        /// <param name="self"></param>
        public static void ResetAdventure(this AdventureComponent self)
        {
            for (int i = 0; i < self.EnemyIdList.Count; i++)
            {
                self.ClientScene().GetUnitComponent().Remove(self.EnemyIdList[i]);
            }
            TimerComponent.Instance?.Remove(ref self.BattleTimer);
            self.BattleTimer = 0;
            self.Round = 0;
            self.EnemyIdList.Clear();
            self.AliveEnemyIdList.Clear();

            Unit unit = self.GetMyUnit();
            var nc = unit.GetComponent<NumericComponent>();

            self.SetBattleRandomSeed();
            nc.Set(NumericType.Hp, nc.GetAsInt(NumericType.MaxHp));
            nc.Set(NumericType.IsAlive, 1);

            EventSystem.Instance.Publish(self.ClientScene(), new AdventureRoundReset());
        }

        /// <summary>
        /// 开始冒险
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static async ETTask StartAdventure(this AdventureComponent self)
        {
            self.ResetAdventure();
            await self.CreateAdventureEnemy();
            self.ShowAdventureHpBarInfo(true);
            self.BattleTimer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 500, TimerInvokeType.BattleRound, self);
        }

        /// <summary>
        /// 创建关卡敌人
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static async ETTask CreateAdventureEnemy(this AdventureComponent self)
        {
            //获取玩家所在关卡配置
            Unit unit = self.GetMyUnit();
            int levelId = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.AdventureStatus);
            var battleLevelData = BattleLevelConfigCategory.Instance.Get(levelId);

            //根据关卡配置创建怪物
            int monsterCount = battleLevelData.MonsterIds.Length;
            for (int i = 0; i < monsterCount; i++)
            {
                Unit monsterUnit = await UnitFactory.CreateMonsterAsync(self.ClientScene().CurrentScene(), battleLevelData.MonsterIds[i]);
                monsterUnit.Position = new float3(2, -monsterCount - 1 + i * 2 + RandomHelper.RandomFloat(-0.5f, 0.5f), 0);
                self.EnemyIdList.Add(monsterUnit.Id);
            }
        }

        /// <summary>
        /// 开始战斗回合演算
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static async ETTask PlayOneBattleRound(this AdventureComponent self)
        {
            UnitComponent unitComponent = self.GetUnitComponent();
            Unit playerUnit = self.GetMyUnit();
            Unit monsterUnit;

            if (self.Round % 2 == 0)
            {
                //玩家回合
                monsterUnit = self.GetTargetMonsterUnit();
                EventSystem.Instance.PublishAsync(self.ClientScene(),
                    new AdventureBattleRoundView()
                    {
                        AttackUnit = playerUnit,
                        TargetUnit = monsterUnit
                    }).Coroutine();
                await EventSystem.Instance.PublishAsync(self.ClientScene(),
                    new AdventureBattleRound()
                    {
                        AttackUnit = playerUnit,
                        TargetUnit = monsterUnit
                    });
                await TimerComponent.Instance.WaitAsync(1000);
            }
            else
            {
                //敌人回合
                for (int i = 0; i < self.EnemyIdList.Count && playerUnit.IsAlive(); i++)
                {
                    monsterUnit = unitComponent.Get(self.EnemyIdList[i]);
                    if (!monsterUnit.IsAlive())
                    {
                        continue;
                    }
                    EventSystem.Instance.PublishAsync(self.ClientScene(),
                        new AdventureBattleRoundView()
                        {
                            AttackUnit = monsterUnit,
                            TargetUnit = playerUnit,
                        }).Coroutine();
                    await EventSystem.Instance.PublishAsync(self.ClientScene(),
                        new AdventureBattleRound()
                        {
                            AttackUnit = monsterUnit,
                            TargetUnit = playerUnit
                        });
                    await TimerComponent.Instance.WaitAsync(1000);
                }
            }

            self.BattleRoundOver();
        }

        /// <summary>
        /// 战斗回合结束
        /// </summary>
        /// <param name="self"></param>
        public static void BattleRoundOver(this AdventureComponent self)
        {
            ++self.Round;
            //计算战斗回合结果
            BattleRoundResult battleRoundResult = self.GetBattleRoundResult();
            Log.Debug($"当前回合结果:{battleRoundResult}");
            switch (battleRoundResult)
            {
                case BattleRoundResult.Keep:
                    self.BattleTimer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 500, TimerInvokeType.BattleRound, self);
                    break;

                case BattleRoundResult.Win:
                    Unit unit = self.GetMyUnit();
                    EventSystem.Instance.PublishAsync(self.ClientScene(), new AdventureBattleOver()
                    {
                        WinUnit = unit,
                    }).Coroutine();
                    break;

                case BattleRoundResult.Lose:
                    UnitComponent unitComponent = self.GetUnitComponent();
                    for (int i = 0; i < self.EnemyIdList.Count; i++)
                    {
                        Unit monsterUnit = unitComponent.Get(self.EnemyIdList[i]);
                        if (!monsterUnit.IsAlive())
                        {
                            continue;
                        }
                        EventSystem.Instance.PublishAsync(self.ClientScene(), new AdventureBattleOver()
                        {
                            WinUnit = monsterUnit,
                        }).Coroutine();
                    }
                    break;
            }

            //发送战报事件
            EventSystem.Instance.PublishAsync(self.ClientScene(),
                new EventType.AdventureBattleReport()
                {
                    Round = self.Round,
                    BattleRoundResult = battleRoundResult,
                }).Coroutine();
        }

        /// <summary>
        /// 获取回合结果
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static BattleRoundResult GetBattleRoundResult(this AdventureComponent self)
        {
            Unit unit = self.GetMyUnit();
            if (!unit.IsAlive())
            {
                return BattleRoundResult.Lose;
            }
            Unit monsterUnit = self.GetTargetMonsterUnit();
            if (monsterUnit == null)
            {
                return BattleRoundResult.Win;
            }
            return BattleRoundResult.Keep;
        }

        /// <summary>
        /// 获取可攻击敌人
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Unit GetTargetMonsterUnit(this AdventureComponent self)
        {
            self.AliveEnemyIdList.Clear();
            UnitComponent unitComponent = self.GetUnitComponent();
            for (int i = 0; i < self.EnemyIdList.Count; i++)
            {
                Unit monsterUnit = unitComponent.Get(self.EnemyIdList[i]);
                if (monsterUnit.IsAlive())
                {
                    self.AliveEnemyIdList.Add(monsterUnit.Id);
                }
            }
            return self.AliveEnemyIdList.Count > 0
                ? unitComponent.Get(self.AliveEnemyIdList[0])
                : null;
        }

        /// <summary>
        /// 显示血条UI
        /// </summary>
        /// <param name="self"></param>
        /// <param name="show"></param>
        public static void ShowAdventureHpBarInfo(this AdventureComponent self, bool show)
        {
            Unit myUnit = self.GetMyUnit();
            EventSystem.Instance.Publish(self.ClientScene(), new ShowAdventureHpBar()
            {
                Unit = myUnit,
                isShow = show
            });

            var unitComponent = self.GetUnitComponent();
            for (int i = 0; i < self.EnemyIdList.Count; i++)
            {
                Unit monsterUnit = unitComponent.Get(self.EnemyIdList[i]);
                EventSystem.Instance.Publish(self.ClientScene(), new ShowAdventureHpBar()
                {
                    Unit = monsterUnit,
                    isShow = show
                });
            }
        }
    }

    /// <summary>
    /// 战斗回合触发器
    /// </summary>
    [Invoke(TimerInvokeType.BattleRound)]
    public class AdventureBattleRoundTimer : ATimer<AdventureComponent>
    {
        protected override void Run(AdventureComponent t)
        {
            t?.PlayOneBattleRound().Coroutine();
        }
    }
}