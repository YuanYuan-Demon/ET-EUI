using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class AdventureComponent : Entity, IAwake, IDestroy
    {
        public long BattleTimer = 0;
        public int Round = 0;
        public List<long> EnemyIdList = new();
        public List<long> AliveEnemyIdList = new();
    }
}