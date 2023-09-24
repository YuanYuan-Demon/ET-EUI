using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    public partial class AIConfigCategory
    {
        [ProtoIgnore]
        [BsonIgnore]
        public Dictionary<int, SortedDictionary<int, AIConfig>> AIConfigs = new();

        public SortedDictionary<int, AIConfig> GetAI(int aiConfigId) => this.AIConfigs[aiConfigId];

        protected override void PostInit()
        {
            foreach ((int id, AIConfig aiConfig) in this.GetAll())
            {
                SortedDictionary<int, AIConfig> aiNodeConfig;
                if (!this.AIConfigs.TryGetValue(aiConfig.AIConfigId, out aiNodeConfig))
                {
                    aiNodeConfig = new();
                    this.AIConfigs.Add(aiConfig.AIConfigId, aiNodeConfig);
                }

                aiNodeConfig.Add(id, aiConfig);
            }
        }
    }
}