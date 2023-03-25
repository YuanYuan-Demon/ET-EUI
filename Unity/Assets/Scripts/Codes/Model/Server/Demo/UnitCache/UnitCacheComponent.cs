using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class UnitCacheComponent : Entity, IAwake, IDestroy
    {
        /// <summary>
        /// 需要缓存的类型名
        /// </summary>
        public List<string> UnitCacheNames = new();

        /// <summary>
        /// <para>Key: 类型名</para>
        /// <para>Value: 该实体/组件的缓存[UnitCache]</para>
        /// </summary>

        public Dictionary<string, UnitCache> UnitCaches = new();
    }
}