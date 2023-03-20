﻿namespace ET.Server
{
    [FriendOf(typeof(Item))]
    [FriendOf(typeof(AttributeEntry))]
    [FriendOf(typeof(EquipInfoComponent))]
    public static class EquipInfoComponentSystem
    {
        #region 生命周期

        public class EquipInfoComponentAwakeSystem : AwakeSystem<EquipInfoComponent>
        {
            protected override void Awake(EquipInfoComponent self)
            {
                self.GenerateEntries();
            }
        }

        public class EquipInfoComponentDestorySystem : DestroySystem<EquipInfoComponent>
        {
            protected override void Destroy(EquipInfoComponent self)
            {
                self.IsInited = false;
                self.Score = 0;

                foreach (var entry in self.EntryList)
                {
                    entry?.Dispose();
                }
                self.EntryList.Clear();
            }
        }

        #endregion 生命周期

        public class EquipInfoComponentDeserializeSystem : DeserializeSystem<EquipInfoComponent>
        {
            protected override void Deserialize(EquipInfoComponent self)
            {
                foreach (var entity in self.Children.Values)
                {
                    self.EntryList.Add(entity as AttributeEntry);
                }
            }
        }

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
        /// 创建随机词条
        /// </summary>
        /// <param name="self">装备信息组件</param>
        public static void CreateEntry(this EquipInfoComponent self)
        {
            ItemConfig itemConfig = self.GetParent<Item>().Config;

            EntryRandomConfig entryRandomConfig = EntryRandomConfigCategory.Instance.Get(itemConfig.EntryRandomId);

            //创建普通词条
            int entryCount = RandomHelper.RandomNumber(entryRandomConfig.EntryRandMinCount + self.GetParent<Item>().Quality, entryRandomConfig.EntryRandMaxCount + self.GetParent<Item>().Quality);
            for (int i = 0; i < entryCount; i++)
            {
                EntryConfig entryConfig = EntryConfigCategory.Instance.GetRandomEntryConfigByLevel((int)EntryType.Common, entryRandomConfig.EntryLevel);
                if (entryConfig == null)
                {
                    continue;
                }

                AttributeEntry attributeEntry = self.AddChild<AttributeEntry>();
                attributeEntry.EntryType = EntryType.Common;
                attributeEntry.AttributeType = entryConfig.AttributeType;
                attributeEntry.AttributeValue = RandomHelper.RandomNumber(entryConfig.AttributeMinValue, entryConfig.AttributeMaxValue + self.GetParent<Item>().Quality);
                self.EntryList.Add(attributeEntry);
                self.Score += entryConfig.EntryScore;
            }

            //创建特殊词条
            entryCount = RandomHelper.RandomNumber(entryRandomConfig.SpecialEntryRandMinCount, entryRandomConfig.SpecialEntryRandMaxCount);
            for (int i = 0; i < entryCount; i++)
            {
                EntryConfig entryConfig = EntryConfigCategory.Instance.GetRandomEntryConfigByLevel((int)EntryType.Special, entryRandomConfig.SpecialEntryLevel);
                if (entryConfig == null)
                {
                    continue;
                }
                AttributeEntry attributeEntry = self.AddChild<AttributeEntry>();
                attributeEntry.EntryType = EntryType.Special;
                attributeEntry.AttributeType = entryConfig.AttributeType;
                attributeEntry.AttributeValue = RandomHelper.RandomNumber(entryConfig.AttributeMinValue, entryConfig.AttributeMaxValue);
                self.EntryList.Add(attributeEntry);
                self.Score += entryConfig.EntryScore;
            }
        }

        public static EquipInfoProto ToMessage(this EquipInfoComponent self)
        {
            EquipInfoProto equipInfoProto = new EquipInfoProto
            {
                Id = self.Id,
                Score = self.Score
            };
            for (int i = 0; i < self.EntryList.Count; i++)
            {
                equipInfoProto.AttributeEntryList.Add(self.EntryList[i].ToMessage());
            }
            return equipInfoProto;
        }
    }
}