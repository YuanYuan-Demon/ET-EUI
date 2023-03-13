﻿using System;
using System.Collections.Generic;

namespace ET
{
    public static class RealmGateAddressHelper
    {
        /// <summary>
        /// 根据帐号ID取模分配Gate
        /// </summary>
        /// <param name="zone"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public static StartSceneConfig GetGate(int zone, long accountId)
        {
            List<StartSceneConfig> zoneGates = StartSceneConfigCategory.Instance.Gates[zone];

            //int n = RandomHelper.RandomNumber(0, zoneGates.Level);
            int n = accountId.GetHashCode() % zoneGates.Count;

            return zoneGates[n];
        }

        public static StartSceneConfig GetRealm(int zone)
        {
            StartSceneConfig zoneRealm = StartSceneConfigCategory.Instance.Realms[zone];
            return zoneRealm;
        }
    }
}