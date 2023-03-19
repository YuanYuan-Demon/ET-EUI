using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class AdventureCheckComponent : Entity, IAwake, IDestroy
    {
        public int AnimationTotalTime = 0;
        public List<long> EnemyIdList = new();
        public List<long> CacheEnemyIdList = new();
        public SRandom Random = null;
    }
}