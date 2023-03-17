using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class UnitCacheComponent : Entity, IAwake, IDestroy
    {
        public List<string> UnitCacheNames = new List<string>();
        public Dictionary<string, UnitCache> UnitCaches = new Dictionary<string, UnitCache>();
    }
}