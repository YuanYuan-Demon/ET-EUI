using System.Collections.Generic;
using ET.EventType;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
    [FriendOf(typeof (NumericComponent))]
    public static class NumericComponentSystem
    {
        public static void Update(this NumericComponent self, NumericType numericType, bool isPublicEvent)
        {
            var final = (int)numericType / 10;
            var bas = final * 10 + 1;
            var add = final * 10 + 2;
            var pct = final * 10 + 3;
            var finalAdd = final * 10 + 4;
            var finalPct = final * 10 + 5;

            // 一个数值可能会多种情况影响，比如速度,加个buff可能增加速度绝对值100，也有些buff增加10%速度，所以一个值可以由5个值进行控制其最终结果
            // final = (((base + add) * (100 + pct) / 100) + finalAdd) * (100 + finalPct) / 100;
            var result = (long)(((self.GetByKey((NumericType)bas) + self.GetByKey((NumericType)add)) * (100 + self.GetAsFloat((NumericType)pct)) /
                    100f + self.GetByKey((NumericType)finalAdd)) *
                (100 + self.GetAsFloat((NumericType)finalPct)) / 100f);
            self.Insert((NumericType)final, result, isPublicEvent);
        }

#region Get

        public static float GetAsFloat(this NumericComponent self, NumericType numericType) => (float)self.GetByKey(numericType) / 10000;

        public static int GetAsInt(this NumericComponent self, NumericType numericType) => (int)self.GetByKey(numericType);

        public static long GetAsLong(this NumericComponent self, NumericType numericType) => self.GetByKey(numericType);

        public static long GetByKey(this NumericComponent self, NumericType key)
        {
            long value = 0;
            self.NumericDic.TryGetValue(key, out value);
            return value;
        }

#endregion Get

#region Set

        public static void Set(this NumericComponent self, NumericType nt, float value) => self[nt] = (long)(value * 10000);

        public static void Set(this NumericComponent self, NumericType nt, int value) => self[nt] = value;

        public static void Set(this NumericComponent self, NumericType nt, long value) => self[nt] = value;

        public static void SetNoEvent(this NumericComponent self, NumericType numericType, long value) => self.Insert(numericType, value, false);

        public static void Insert(this NumericComponent self, NumericType numericType, long value, bool isPublicEvent = true)
        {
            var oldValue = self.GetByKey(numericType);
            if (oldValue == value)
                return;

            self.NumericDic[numericType] = value;

            if (numericType >= NumericType.Max)
            {
                self.Update(numericType, isPublicEvent);
                return;
            }

            if (isPublicEvent)
                EventSystem.Instance.Publish(self.DomainScene(),
                    new NumbericChange() { Unit = self.GetParent<Unit>(), New = value, Old = oldValue, NumericType = numericType },
                    true);
        }

#endregion Set

#region Add

        public static long Add(this NumericComponent self, NumericType nt, float value) => self[nt] += (int)(value * 10000);

        public static long Add(this NumericComponent self, NumericType nt, int value) => self[nt] += value;

        public static long Add(this NumericComponent self, NumericType nt, long value) => self[nt] += value;

#endregion Add

#region Minus

        public static long Minus(this NumericComponent self, NumericType nt, float value) => self[nt] -= (int)(value * 10000);

        public static long Minus(this NumericComponent self, NumericType nt, int value) => self[nt] -= value;

        public static long Minus(this NumericComponent self, NumericType nt, long value) => self[nt] -= value;

#endregion Minus
    }

    namespace EventType
    {
        public struct NumbericChange
        {
            public Unit Unit;
            public NumericType NumericType;
            public long Old;
            public long New;
        }
    }

    [ComponentOf(typeof (Unit))]
    public class NumericComponent: Entity, IAwake, ITransfer, IUnitCache
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)]
        public Dictionary<NumericType, long> NumericDic = new();

        public long this[NumericType numericType]
        {
            get => this.GetByKey(numericType);
            set => this.Insert(numericType, value);
        }
    }
}