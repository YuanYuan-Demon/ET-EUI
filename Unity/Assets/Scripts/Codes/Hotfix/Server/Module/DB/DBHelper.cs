using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ET.Server
{
    public static class DBHelper
    {
        public static async ETTask<List<T>> QueryDB<T>(this Entity self, Expression<Func<T, bool>> filter, string collection = null) where T : Entity
            => await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query(filter, collection);
    }
}