﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class LoginInfoRecordComponentDestroySystem : DestroySystem<LoginInfoRecordComponent>
    {
        public override void Destroy(LoginInfoRecordComponent self)
        {
            self.AccountLoginInfos.Clear();
        }
    }

    public static class LoginInfoRecordComponentSystem
    {
        public static long Get(this LoginInfoRecordComponent self, long accountId)
        {
            return self.AccountLoginInfos.TryGetValue(accountId, out var instanceId)
                ? instanceId : -1;
        }

        public static void Add(this LoginInfoRecordComponent self, long accountId, int value)
        {
            self.AccountLoginInfos[accountId] = value;
        }

        public static void Remove(this LoginInfoRecordComponent self, long accountId)
        {
            if (self.AccountLoginInfos.ContainsKey(accountId))
            {
                self.AccountLoginInfos.Remove(accountId);
            }
        }

        public static bool IsExist(this LoginInfoRecordComponent self, long accountId)
        {
            return self.AccountLoginInfos.ContainsKey(accountId);
        }
    }
}