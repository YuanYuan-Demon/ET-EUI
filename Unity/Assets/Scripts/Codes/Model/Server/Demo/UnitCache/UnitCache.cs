using System;
using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf(typeof (UnitCacheComponent))]
    public class UnitCache: Entity, IAwake, IDestroy
    {
        /// <summary>
        ///     <para> Key: UnitId </para>
        ///     <para> Value: Component </para>
        /// </summary>
        public Dictionary<long, Entity> CacheComponents = new();

        public Type ComponentType;
    }
}