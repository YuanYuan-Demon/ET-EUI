namespace ET.Server
{
    [FriendOf(typeof (Item))]
    [FriendOf(typeof (AttributeEntry))]
    [FriendOf(typeof (EquipInfoComponent))]
    public static class EquipInfoComponentSystem
    {
        public static void GenerateEntries(this EquipInfoComponent self)
        {
            if (self.IsInited)
            {
                return;
            }

            self.IsInited = true;
            self.CreateEntry();
        }

        /// <summary>
        ///     创建随机词条
        /// </summary>
        /// <param name="self">装备信息组件</param>
        public static void CreateEntry(this EquipInfoComponent self)
        {
            var item = self.GetParent<Item>();

            var equipConfig = EquipConfigCategory.Instance.Get(item.ConfigId);

            var entryRandomConfig = EntryRandomConfigCategory.Instance.Get(equipConfig.EntryRandomId);

            var quality = item.GetComponent<EquipInfoComponent>().Quality;
            //创建普通词条
            var entryCount = RandomHelper.RandomInt32(entryRandomConfig.EntryRandMinCount + quality, entryRandomConfig.EntryRandMaxCount + quality);
            for (var i = 0; i < entryCount; i++)
            {
                var entryConfig =
                        EntryConfigCategory.Instance.GetRandomEntryConfigByLevel((int)EntryType.Common, entryRandomConfig.EntryLevel);
                if (entryConfig == null)
                {
                    continue;
                }

                var attributeEntry = self.AddChild<AttributeEntry>();
                attributeEntry.EntryType = EntryType.Common;
                attributeEntry.AttributeType = entryConfig.AttributeType;
                attributeEntry.AttributeValue = RandomHelper.RandomInt32(entryConfig.AttributeMinValue, entryConfig.AttributeMaxValue + quality);
                self.EntryList.Add(attributeEntry);
                self.Score += entryConfig.EntryScore;
            }

            //创建特殊词条
            entryCount = RandomHelper.RandomInt32(entryRandomConfig.SpecialEntryRandMinCount, entryRandomConfig.SpecialEntryRandMaxCount);
            for (var i = 0; i < entryCount; i++)
            {
                var entryConfig =
                        EntryConfigCategory.Instance.GetRandomEntryConfigByLevel((int)EntryType.Special, entryRandomConfig.SpecialEntryLevel);
                if (entryConfig == null)
                {
                    continue;
                }

                var attributeEntry = self.AddChild<AttributeEntry>();
                attributeEntry.EntryType = EntryType.Special;
                attributeEntry.AttributeType = entryConfig.AttributeType;
                attributeEntry.AttributeValue = RandomHelper.RandomInt32(entryConfig.AttributeMinValue, entryConfig.AttributeMaxValue);
                self.EntryList.Add(attributeEntry);
                self.Score += entryConfig.EntryScore;
            }
        }

        public static EquipInfoProto ToMessage(this EquipInfoComponent self)
        {
            EquipInfoProto equipInfoProto = new() { Id = self.Id, Score = self.Score, Quality = self.Quality };
            for (var i = 0; i < self.EntryList.Count; i++)
            {
                equipInfoProto.AttributeEntryList.Add(self.EntryList[i].ToMessage());
            }

            return equipInfoProto;
        }

        public static void RandomQuality(this EquipInfoComponent self)
        {
            var rate = RandomHelper.RandomInt32(10000);
            switch (rate)
            {
                case < 4000:
                    self.Quality = (int)ItemQuality.General;
                    break;

                case < 7000:
                    self.Quality = (int)ItemQuality.Good;
                    break;

                case < 8500:
                    self.Quality = (int)ItemQuality.Excellent;
                    break;

                case < 9500:
                    self.Quality = (int)ItemQuality.Epic;
                    break;

                case < 10000:
                    self.Quality = (int)ItemQuality.Legend;
                    break;
            }
        }

        public class EquipInfoComponentDeserializeSystem: DeserializeSystem<EquipInfoComponent>
        {
            protected override void Deserialize(EquipInfoComponent self)
            {
                foreach (var entity in self.Children.Values)
                {
                    self.EntryList.Add(entity as AttributeEntry);
                }
            }
        }

#region 生命周期

        public class EquipInfoComponentAwakeSystem: AwakeSystem<EquipInfoComponent>
        {
            protected override void Awake(EquipInfoComponent self)
            {
                self.RandomQuality();
                self.GenerateEntries();
            }
        }

        public class EquipInfoComponentDestorySystem: DestroySystem<EquipInfoComponent>
        {
            protected override void Destroy(EquipInfoComponent self)
            {
                self.IsInited = false;
                self.Score = 0;
                self.Quality = 0;

                foreach (var entry in self.EntryList)
                {
                    entry?.Dispose();
                }

                self.EntryList.Clear();
            }
        }

#endregion 生命周期
    }
}