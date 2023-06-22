using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class EquipConfigCategory : ConfigSingleton<EquipConfigCategory>, IMerge
    {
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, EquipConfig> dict = new Dictionary<int, EquipConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<EquipConfig> list = new List<EquipConfig>();
		
        public void Merge(object o)
        {
            EquipConfigCategory s = o as EquipConfigCategory;
            this.list.AddRange(s.list);
        }
		
		[ProtoAfterDeserialization]        
        public void ProtoEndInit()
        {
            foreach (EquipConfig config in list)
            {
                config.AfterEndInit();
                this.dict.Add(config.Id, config);
            }
            this.list.Clear();
            
            this.AfterEndInit();
        }
		
        public EquipConfig Get(int id)
        {
            this.dict.TryGetValue(id, out EquipConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (EquipConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, EquipConfig> GetAll()
        {
            return this.dict;
        }

        public EquipConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class EquipConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>名称</summary>
		[ProtoMember(2)]
		public string Name { get; set; }
		/// <summary>位置</summary>
		[ProtoMember(3)]
		public int EquipPosition { get; set; }
		/// <summary>职业</summary>
		[ProtoMember(4)]
		public string Category { get; set; }
		/// <summary>生命</summary>
		[ProtoMember(5)]
		public int MaxHP { get; set; }
		/// <summary>法力</summary>
		[ProtoMember(6)]
		public int MaxMP { get; set; }
		/// <summary>力量</summary>
		[ProtoMember(7)]
		public int STR { get; set; }
		/// <summary>智力</summary>
		[ProtoMember(8)]
		public int INT { get; set; }
		/// <summary>敏捷</summary>
		[ProtoMember(9)]
		public int DEX { get; set; }
		/// <summary>物理攻击</summary>
		[ProtoMember(10)]
		public int AD { get; set; }
		/// <summary>法术攻击</summary>
		[ProtoMember(11)]
		public int AP { get; set; }
		/// <summary>物理防御</summary>
		[ProtoMember(12)]
		public int DEF { get; set; }
		/// <summary>法术防御</summary>
		[ProtoMember(13)]
		public int MDEF { get; set; }
		/// <summary>攻击速度</summary>
		[ProtoMember(14)]
		public int SPD { get; set; }
		/// <summary>暴击概率</summary>
		[ProtoMember(15)]
		public int CRI { get; set; }
		/// <summary>s词条随机Id</summary>
		[ProtoMember(16)]
		public int EntryRandomId { get; set; }

	}
}
