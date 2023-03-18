using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class PlayerNumericConfigCategory : ConfigSingleton<PlayerNumericConfigCategory>, IMerge
    {
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, PlayerNumericConfig> dict = new Dictionary<int, PlayerNumericConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<PlayerNumericConfig> list = new List<PlayerNumericConfig>();
		
        public void Merge(object o)
        {
            PlayerNumericConfigCategory s = o as PlayerNumericConfigCategory;
            this.list.AddRange(s.list);
        }
		
		[ProtoAfterDeserialization]        
        public void ProtoEndInit()
        {
            foreach (PlayerNumericConfig config in list)
            {
                config.AfterEndInit();
                this.dict.Add(config.Id, config);
            }
            this.list.Clear();
            
            this.AfterEndInit();
        }
		
        public PlayerNumericConfig Get(int id)
        {
            this.dict.TryGetValue(id, out PlayerNumericConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (PlayerNumericConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, PlayerNumericConfig> GetAll()
        {
            return this.dict;
        }

        public PlayerNumericConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class PlayerNumericConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>名字</summary>
		[ProtoMember(2)]
		public string Name { get; set; }
		/// <summary>初始基础值</summary>
		[ProtoMember(3)]
		public long BaseValue { get; set; }
		/// <summary>是否用于展示</summary>
		[ProtoMember(4)]
		public int isNeedShow { get; set; }
		/// <summary>是否用于加成点</summary>
		[ProtoMember(5)]
		public int isAddPoint { get; set; }
		/// <summary>是否是百分比</summary>
		[ProtoMember(6)]
		public int isPrecent { get; set; }

	}
}
