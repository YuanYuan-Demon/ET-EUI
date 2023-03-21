﻿namespace ET
{
    [ChildOf]
    public class RankInfo : Entity, IAwake, IDestroy
    {
        public long UnitId;
        public string Name;
        public int Level;
    }
}