using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof(ChatInfoUnit))]
    [ComponentOf(typeof(Scene))]
    public class ChatInfoUnitsComponent : Entity, IAwake, IDestroy
    {
        /// <summary>
        /// 存储Unit到Chat服务器中ChatInfo的映射
        /// Key: UnitId
        /// Value: ChatInfoUnit
        /// </summary>
        public Dictionary<long, ChatInfoUnit> ChatInfoUnitsDict = new Dictionary<long, ChatInfoUnit>();
    }
}