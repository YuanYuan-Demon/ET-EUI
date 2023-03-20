﻿using System;

namespace ET.Server
{
    [FriendOf(typeof(AdventureCheckComponent))]
    [FriendOf(typeof(Unit))]
    public static class AdventureCheckComponentSystem
    {
        #region 生命周期

        public class AdventureCheckComponentDestorySyste : DestroySystem<AdventureCheckComponent>
        {
            protected override void Destroy(AdventureCheckComponent self)
            {
                //销毁缓存的Unit
                foreach (var monsterId in self.CacheEnemyIdList)
                {
                    self.DomainScene().GetComponent<UnitComponent>().Remove(monsterId);
                }
                self.CacheEnemyIdList.Clear();
                self.EnemyIdList.Clear();
                self.AnimationTotalTime = 0;
                self.Random = null;
            }
        }

        #endregion 生命周期

        /// <summary>
        /// 重置冒险关卡信息
        /// </summary>
        /// <param name="self"></param>
        public static void ResetAdventureInfo(this AdventureCheckComponent self)
        {
            self.AnimationTotalTime = 0;
            NumericComponent numericComponent = self.GetParent<Unit>().GetComponent<NumericComponent>();
            numericComponent.SetNoEvent(NumericType.Hp, numericComponent.GetAsInt(NumericType.MaxHp));
            numericComponent.SetNoEvent(NumericType.IsAlive, 1);
        }

        /// <summary>
        /// 核验战斗结果
        /// </summary>
        /// <param name="self"></param>
        /// <param name="battleRound"></param>
        /// <returns></returns>
        public static bool CheckBattleWinResult(this AdventureCheckComponent self, int battleRound)
        {
            try
            {
                self.ResetAdventureInfo();
                self.SetBattleRandomSeed();
                self.CreateBattleMonsterUnit();

                //模拟对战
                bool isSimulationNormal = self.SimulationBattle(battleRound);
                if (!isSimulationNormal)
                {
                    Log.Error("模拟对战失败");
                    return false;
                }

                if (!self.GetParent<Unit>().IsAlive())
                {
                    Log.Error("玩家未存活");
                    return false;
                }

                //判定所有怪物是否被击杀
                if (self.GetFirstAliveEnemy() != null)
                {
                    Log.Error("还有怪物存活");
                    return false;
                }

                //判定战斗动画时间是否正常
                NumericComponent numericComponent = self.GetParent<Unit>().GetComponent<NumericComponent>();
                long playAnimationTime = TimeHelper.ServerNow() - numericComponent.GetAsLong(NumericType.AdventureStartTime);
                if (playAnimationTime < self.AnimationTotalTime)
                {
                    Log.Error($"动画时间不足");
                    return false;
                }
                return true;
            }
            finally
            {
                self.ResetAdventureInfo();
            }
        }

        /// <summary>
        /// 设置战斗随机数
        /// </summary>
        /// <param name="self"></param>
        public static void SetBattleRandomSeed(this AdventureCheckComponent self)
        {
            uint seed = (uint)self.GetParent<Unit>().GetComponent<NumericComponent>().GetAsInt(NumericType.BattleRandomSeed);
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
        /// 生成服务端怪物
        /// </summary>
        /// <param name="self"></param>
        public static void CreateBattleMonsterUnit(this AdventureCheckComponent self)
        {
            int levelId = self.GetParent<Unit>().GetComponent<NumericComponent>().GetAsInt(NumericType.AdventureStatus);
            //生成最大怪物数量
            BattleLevelConfig battleLevelConfig = BattleLevelConfigCategory.Instance.Get(levelId);
            int monsterCount = battleLevelConfig.MonsterIds.Length - self.CacheEnemyIdList.Count;
            for (int i = 0; i < monsterCount; i++)
            {
                Unit monsterUnit = UnitFactory.CreateMonster(self.DomainScene(), 1002);
                self.CacheEnemyIdList.Add(monsterUnit.Id);
            }

            //复用怪物Unit
            self.EnemyIdList.Clear();
            for (int i = 0; i < battleLevelConfig.MonsterIds.Length; i++)
            {
                Unit monsterUnit = self.DomainScene().GetComponent<UnitComponent>().Get(self.CacheEnemyIdList[i]);
                UnitConfig unitConfig = UnitConfigCategory.Instance.Get(battleLevelConfig.MonsterIds[i]);
                monsterUnit.ConfigId = unitConfig.Id;

                NumericComponent numericComponent = monsterUnit.GetComponent<NumericComponent>();
                numericComponent.SetNoEvent(NumericType.MaxHp, monsterUnit.Config.MaxHP);
                numericComponent.SetNoEvent(NumericType.Hp, monsterUnit.Config.MaxHP);
                numericComponent.SetNoEvent(NumericType.DamageValue, monsterUnit.Config.DamageValue);
                numericComponent.SetNoEvent(NumericType.IsAlive, 1);
                self.EnemyIdList.Add(monsterUnit.Id);
            }
        }

        /// <summary>
        /// 模拟对战
        /// </summary>
        /// <param name="self"></param>
        /// <param name="battleRound"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool SimulationBattle(this AdventureCheckComponent self, int battleRound)
        {
            //开始模拟对战
            Unit playerUnit = self.GetParent<Unit>();
            for (int i = 0; i < battleRound; i++)
            {
                //玩家回合
                if (i % 2 == 0)
                {
                    Unit monsterUnit = self.GetFirstAliveEnemy();
                    if (monsterUnit == null)
                    {
                        Log.Debug("获取到怪物为空");
                        return false;
                    }
                    self.AnimationTotalTime += 1000;
                    self.CalcuateDamageHpValue(playerUnit, monsterUnit);
                }
                //敌人回合
                else
                {
                    if (!playerUnit.IsAlive())
                    {
                        return false;
                    }
                    for (int j = 0; j < self.EnemyIdList.Count; j++)
                    {
                        Unit monsterUnit = self.DomainScene().GetComponent<UnitComponent>().Get(self.EnemyIdList[j]);
                        if (!monsterUnit.IsAlive())
                        {
                            continue;
                        }
                        self.AnimationTotalTime += 1000;
                        self.CalcuateDamageHpValue(monsterUnit, playerUnit);
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 获取第一个存活的怪物
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Unit GetFirstAliveEnemy(this AdventureCheckComponent self)
        {
            for (int i = 0; i < self.EnemyIdList.Count; i++)
            {
                Unit monsterUnit = self.DomainScene().GetComponent<UnitComponent>().Get(self.EnemyIdList[i]);
                if (monsterUnit.IsAlive())
                {
                    return monsterUnit;
                }
            }
            return null;
        }

        /// <summary>
        /// 计算伤害
        /// </summary>
        /// <param name="self"></param>
        /// <param name="attackUnit">攻击方</param>
        /// <param name="targeUnit">被攻击方</param>
        public static void CalcuateDamageHpValue(this AdventureCheckComponent self, Unit attackUnit, Unit targeUnit)
        {
            int hp = targeUnit.GetComponent<NumericComponent>().GetAsInt(NumericType.Hp);
            hp -= DamageCalcuateHelper.CalcuateDamageValue(attackUnit, targeUnit, ref self.Random);
            if (hp <= 0)
            {
                hp = 0;
                targeUnit.GetComponent<NumericComponent>().SetNoEvent(NumericType.IsAlive, 0);
            }
            targeUnit.GetComponent<NumericComponent>().SetNoEvent(NumericType.Hp, hp);
        }
    }
}