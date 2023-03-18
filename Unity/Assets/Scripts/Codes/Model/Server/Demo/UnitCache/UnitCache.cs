using System.Collections.Generic;

namespace ET.Server
{
    [ChildOf(typeof(UnitCacheComponent))]
    public class UnitCache : Entity, IAwake, IDestroy
    {
        /// <summary>
        /// <para> AttributeType: UnitId </para>
        /// <para> AttributeValue: Entity </para>
        /// </summary>
        public Dictionary<long, Entity> CacheComponents = new Dictionary<long, Entity>();

        public string EntityName;
    }
}