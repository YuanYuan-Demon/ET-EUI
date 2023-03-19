using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class AdventureComponent : Entity, IAwake, IDestroy
    {
        public long BattleTimer = 0;
        public int Round = 0;
        public List<long> EnemyIdList = new();
        public List<long> AliveEnemyIdList = new();
        public SRandom Random;
    }
}