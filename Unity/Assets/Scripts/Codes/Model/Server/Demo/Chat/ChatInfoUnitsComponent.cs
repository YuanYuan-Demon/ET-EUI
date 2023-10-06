﻿using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Scene))]
    public class ChatInfoUnitsComponent: Entity, IAwake, IDestroy
    {
        /// <summary>
        ///     存储Unit到Chat服务器中ChatInfo的映射
        ///     Key: UnitId
        ///     Value: ChatInfoUnit
        /// </summary>
        public Dictionary<long, ChatInfoUnit> ChatInfoUnits = new();
    }
}