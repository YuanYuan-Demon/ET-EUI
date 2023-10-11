using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET.Server
{
    [ChildOf(typeof (FriendUnitComponent))]
    public class FriendUnit: Entity, IAwake, IDestroy, IDeserialize
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)]
        public Dictionary<long, FriendInfo> Application = new();

        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)]
        public Dictionary<long, FriendInfo> Friends = new();

        [BsonIgnore]
        private long gateSessionActorId;

        public string Name;

        [BsonIgnore]
        public bool Online;

        [BsonIgnore]
        public long VisitTime;

        [BsonIgnore]
        public long GateSessionActorId
        {
            get
            {
                this.VisitTime = TimeHelper.ServerNow();
                return this.gateSessionActorId;
            }
            set => this.gateSessionActorId = value;
        }
    }
}