﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class AdventureCheckComponent : Entity, IAwake, IDestroy
    {
        public int AnimationTotalTime = 0;
        public List<long> EnemyIdList = new List<long>();
        public List<long> CacheEnemyIdList = new List<long>();
        public SRandom Random = null;
    }
}