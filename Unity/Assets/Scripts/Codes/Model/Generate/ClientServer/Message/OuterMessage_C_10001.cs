using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using ProtoBuf;
using Unity.Mathematics;

namespace ET
{
    [Message(OuterMessage.HttpGetRouterResponse)]
    [ProtoContract]
    public class HttpGetRouterResponse: ProtoObject
    {
        [ProtoMember(1)]
        public List<string> Realms { get; set; } = new();

        [ProtoMember(2)]
        public List<string> Routers { get; set; } = new();
    }

    [Message(OuterMessage.RouterSync)]
    [ProtoContract]
    public class RouterSync: ProtoObject
    {
        [ProtoMember(1)]
        public uint ConnectId { get; set; }

        [ProtoMember(2)]
        public string Address { get; set; }
    }

    [ResponseType(nameof (M2C_TestResponse))]
    [Message(OuterMessage.C2M_TestRequest)]
    [ProtoContract]
    public class C2M_TestRequest: ProtoObject, IActorLocationRequest
    {
        [ProtoMember(2)]
        public string request { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.M2C_TestResponse)]
    [ProtoContract]
    public class M2C_TestResponse: ProtoObject, IActorLocationResponse
    {
        [ProtoMember(4)]
        public string response { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }

        [ProtoMember(2)]
        public int Error { get; set; }

        [ProtoMember(3)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (Actor_TransferResponse))]
    [Message(OuterMessage.Actor_TransferRequest)]
    [ProtoContract]
    public class Actor_TransferRequest: ProtoObject, IActorLocationRequest
    {
        [ProtoMember(2)]
        public int MapIndex { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.Actor_TransferResponse)]
    [ProtoContract]
    public class Actor_TransferResponse: ProtoObject, IActorLocationResponse
    {
        [ProtoMember(1)]
        public int RpcId { get; set; }

        [ProtoMember(2)]
        public int Error { get; set; }

        [ProtoMember(3)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (G2C_EnterMap))]
    [Message(OuterMessage.C2G_EnterMap)]
    [ProtoContract]
    public class C2G_EnterMap: ProtoObject, IRequest
    {
        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.G2C_EnterMap)]
    [ProtoContract]
    public class G2C_EnterMap: ProtoObject, IResponse
    {
        // 自己unitId
        [ProtoMember(4)]
        public long MyId { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }

        [ProtoMember(2)]
        public int Error { get; set; }

        [ProtoMember(3)]
        public string Message { get; set; }
    }

    [Message(OuterMessage.MoveInfo)]
    [ProtoContract]
    public class MoveInfo: ProtoObject
    {
        [ProtoMember(1)]
        public List<float3> Targets { get; set; } = new();

        [ProtoMember(2)]
        public quaternion Rotation { get; set; }

        [ProtoMember(3)]
        public int TurnSpeed { get; set; }
    }

    [Message(OuterMessage.UnitInfo)]
    [ProtoContract]
    public class UnitInfo: ProtoObject
    {
        [ProtoMember(1)]
        public long UnitId { get; set; }

        [ProtoMember(2)]
        public int ConfigId { get; set; }

        [ProtoMember(3)]
        public UnitType Type { get; set; }

        [ProtoMember(4)]
        public float3 Position { get; set; }

        [ProtoMember(5)]
        public float3 Forward { get; set; }

        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        [ProtoMember(6)]
        public Dictionary<NumericType, long> Numeric { get; set; } = new();

        [ProtoMember(7)]
        public MoveInfo MoveInfo { get; set; }

        [ProtoMember(8)]
        public NRoleInfo NRoleInfo { get; set; }
    }

    [Message(OuterMessage.M2C_CreateUnits)]
    [ProtoContract]
    public class M2C_CreateUnits: ProtoObject, IActorMessage
    {
        [ProtoMember(1)]
        public List<UnitInfo> Units { get; set; } = new();
    }

    [Message(OuterMessage.M2C_CreateMyUnit)]
    [ProtoContract]
    public class M2C_CreateMyUnit: ProtoObject, IActorMessage
    {
        [ProtoMember(1)]
        public UnitInfo Unit { get; set; }
    }

    [Message(OuterMessage.M2C_StartSceneChange)]
    [ProtoContract]
    public class M2C_StartSceneChange: ProtoObject, IActorMessage
    {
        [ProtoMember(1)]
        public long SceneInstanceId { get; set; }

        [ProtoMember(2)]
        public string SceneName { get; set; }
    }

    [Message(OuterMessage.M2C_RemoveUnits)]
    [ProtoContract]
    public class M2C_RemoveUnits: ProtoObject, IActorMessage
    {
        [ProtoMember(2)]
        public List<long> Units { get; set; } = new();
    }

    [Message(OuterMessage.C2M_PathfindingResult)]
    [ProtoContract]
    public class C2M_PathfindingResult: ProtoObject, IActorLocationMessage
    {
        [ProtoMember(2)]
        public float3 Position { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.C2M_Stop)]
    [ProtoContract]
    public class C2M_Stop: ProtoObject, IActorLocationMessage
    {
        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.M2C_PathfindingResult)]
    [ProtoContract]
    public class M2C_PathfindingResult: ProtoObject, IActorMessage
    {
        [ProtoMember(1)]
        public long Id { get; set; }

        [ProtoMember(2)]
        public float3 Position { get; set; }

        [ProtoMember(3)]
        public List<float3> Points { get; set; } = new();
    }

    [Message(OuterMessage.M2C_Stop)]
    [ProtoContract]
    public class M2C_Stop: ProtoObject, IActorMessage
    {
        [ProtoMember(1)]
        public int Error { get; set; }

        [ProtoMember(2)]
        public long Id { get; set; }

        [ProtoMember(3)]
        public float3 Position { get; set; }

        [ProtoMember(4)]
        public quaternion Rotation { get; set; }
    }

    [ResponseType(nameof (G2C_Ping))]
    [Message(OuterMessage.C2G_Ping)]
    [ProtoContract]
    public class C2G_Ping: ProtoObject, IRequest
    {
        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.G2C_Ping)]
    [ProtoContract]
    public class G2C_Ping: ProtoObject, IResponse
    {
        [ProtoMember(4)]
        public long Time { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }

        [ProtoMember(2)]
        public int Error { get; set; }

        [ProtoMember(3)]
        public string Message { get; set; }
    }

    [Message(OuterMessage.G2C_Test)]
    [ProtoContract]
    public class G2C_Test: ProtoObject, IMessage
    {
    }

    [ResponseType(nameof (M2C_Reload))]
    [Message(OuterMessage.C2M_Reload)]
    [ProtoContract]
    public class C2M_Reload: ProtoObject, IRequest
    {
        [ProtoMember(2)]
        public string Account { get; set; }

        [ProtoMember(3)]
        public string Password { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.M2C_Reload)]
    [ProtoContract]
    public class M2C_Reload: ProtoObject, IResponse
    {
        [ProtoMember(1)]
        public int RpcId { get; set; }

        [ProtoMember(2)]
        public int Error { get; set; }

        [ProtoMember(3)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (R2C_Login))]
    [Message(OuterMessage.C2R_Login)]
    [ProtoContract]
    public class C2R_Login: ProtoObject, IRequest
    {
        [ProtoMember(2)]
        public string Account { get; set; }

        [ProtoMember(3)]
        public string Password { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.R2C_Login)]
    [ProtoContract]
    public class R2C_Login: ProtoObject, IResponse
    {
        [ProtoMember(4)]
        public string Address { get; set; }

        [ProtoMember(5)]
        public long Key { get; set; }

        [ProtoMember(6)]
        public long GateId { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }

        [ProtoMember(2)]
        public int Error { get; set; }

        [ProtoMember(3)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (G2C_LoginGate))]
    [Message(OuterMessage.C2G_LoginGate)]
    [ProtoContract]
    public class C2G_LoginGate: ProtoObject, IRequest
    {
        [ProtoMember(2)]
        public long Key { get; set; }

        [ProtoMember(3)]
        public long GateId { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.G2C_LoginGate)]
    [ProtoContract]
    public class G2C_LoginGate: ProtoObject, IResponse
    {
        [ProtoMember(4)]
        public long PlayerId { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }

        [ProtoMember(2)]
        public int Error { get; set; }

        [ProtoMember(3)]
        public string Message { get; set; }
    }

    [Message(OuterMessage.G2C_TestHotfixMessage)]
    [ProtoContract]
    public class G2C_TestHotfixMessage: ProtoObject, IMessage
    {
        [ProtoMember(1)]
        public string Info { get; set; }
    }

    [ResponseType(nameof (M2C_TestRobotCase))]
    [Message(OuterMessage.C2M_TestRobotCase)]
    [ProtoContract]
    public class C2M_TestRobotCase: ProtoObject, IActorLocationRequest
    {
        [ProtoMember(2)]
        public int N { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.M2C_TestRobotCase)]
    [ProtoContract]
    public class M2C_TestRobotCase: ProtoObject, IActorLocationResponse
    {
        [ProtoMember(4)]
        public int N { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }

        [ProtoMember(2)]
        public int Error { get; set; }

        [ProtoMember(3)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (M2C_TransferMap))]
    [Message(OuterMessage.C2M_TransferMap)]
    [ProtoContract]
    public class C2M_TransferMap: ProtoObject, IActorLocationRequest
    {
        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.M2C_TransferMap)]
    [ProtoContract]
    public class M2C_TransferMap: ProtoObject, IActorLocationResponse
    {
        [ProtoMember(1)]
        public int RpcId { get; set; }

        [ProtoMember(2)]
        public int Error { get; set; }

        [ProtoMember(3)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (G2C_Benchmark))]
    [Message(OuterMessage.C2G_Benchmark)]
    [ProtoContract]
    public class C2G_Benchmark: ProtoObject, IRequest
    {
        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.G2C_Benchmark)]
    [ProtoContract]
    public class G2C_Benchmark: ProtoObject, IResponse
    {
        [ProtoMember(1)]
        public int RpcId { get; set; }

        [ProtoMember(2)]
        public int Error { get; set; }

        [ProtoMember(3)]
        public string Message { get; set; }
    }

    //============================================  账号系统  ============================================
    [ResponseType(nameof (A2C_RegisterAccount))]
    [Message(OuterMessage.C2A_RegisterAccount)]
    [ProtoContract]
    public class C2A_RegisterAccount: ProtoObject, IRequest
    {
        [ProtoMember(1)]
        public string AccountName { get; set; }

        [ProtoMember(2)]
        public string Password { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.A2C_RegisterAccount)]
    [ProtoContract]
    public class A2C_RegisterAccount: ProtoObject, IResponse
    {
        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (A2C_LoginAccount))]
    [Message(OuterMessage.C2A_LoginAccount)]
    [ProtoContract]
    public class C2A_LoginAccount: ProtoObject, IRequest
    {
        [ProtoMember(1)]
        public string AccountName { get; set; }

        [ProtoMember(2)]
        public string Password { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.A2C_LoginAccount)]
    [ProtoContract]
    public class A2C_LoginAccount: ProtoObject, IResponse
    {
        [ProtoMember(1)]
        public string Token { get; set; }

        [ProtoMember(2)]
        public long AccountId { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    [Message(OuterMessage.A2C_Disconnect)]
    [ProtoContract]
    public class A2C_Disconnect: ProtoObject, IMessage
    {
        [ProtoMember(1)]
        public int Error { get; set; }
    }

    //============================================  服务器选择流程  ============================================
    [Message(OuterMessage.NServerInfo)]
    [ProtoContract]
    public class NServerInfo: ProtoObject
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public int Status { get; set; }

        [ProtoMember(3)]
        public string ServerName { get; set; }
    }

    [ResponseType(nameof (A2C_GetServerInfos))]
    [Message(OuterMessage.C2A_GetServerInfos)]
    [ProtoContract]
    public class C2A_GetServerInfos: ProtoObject, IRequest
    {
        [ProtoMember(1)]
        public string Token { get; set; }

        [ProtoMember(2)]
        public long AccountId { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.A2C_GetServerInfos)]
    [ProtoContract]
    public class A2C_GetServerInfos: ProtoObject, IResponse
    {
        [ProtoMember(1)]
        public List<NServerInfo> NServerInfos { get; set; } = new();

        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    //============================================  角色创建/选择流程  ============================================
    [Message(OuterMessage.NRoleInfo)]
    [ProtoContract]
    public class NRoleInfo: ProtoObject
    {
        [ProtoMember(1)]
        public long RoleId { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public int ServerId { get; set; }

        [ProtoMember(4)]
        public RoleInfoStatus Status { get; set; }

        [ProtoMember(5)]
        public long AccountId { get; set; }

        [ProtoMember(6)]
        public RoleClass RoleClass { get; set; }

        [ProtoMember(7)]
        public int Level { get; set; }

        [ProtoMember(8)]
        public long LastLoginTIme { get; set; }

        [ProtoMember(9)]
        public long CreateTime { get; set; }
    }

    [ResponseType(nameof (A2C_GetRoles))]
    [Message(OuterMessage.C2A_GetRoles)]
    [ProtoContract]
    public class C2A_GetRoles: ProtoObject, IRequest
    {
        [ProtoMember(1)]
        public string Token { get; set; }

        [ProtoMember(2)]
        public int ServerId { get; set; }

        [ProtoMember(3)]
        public long AccountId { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.A2C_GetRoles)]
    [ProtoContract]
    public class A2C_GetRoles: ProtoObject, IResponse
    {
        [ProtoMember(1)]
        public List<NRoleInfo> NRoleInfos { get; set; } = new();

        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (A2C_CreateRole))]
    [Message(OuterMessage.C2A_CreateRole)]
    [ProtoContract]
    public class C2A_CreateRole: ProtoObject, IRequest
    {
        [ProtoMember(1)]
        public string Token { get; set; }

        [ProtoMember(2)]
        public int ServerId { get; set; }

        [ProtoMember(3)]
        public long AccountId { get; set; }

        [ProtoMember(4)]
        public string Name { get; set; }

        [ProtoMember(5)]
        public RoleClass RoleClass { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.A2C_CreateRole)]
    [ProtoContract]
    public class A2C_CreateRole: ProtoObject, IResponse
    {
        [ProtoMember(1)]
        public NRoleInfo NRoleInfo { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (A2C_DelteRole))]
    [Message(OuterMessage.C2A_DelteRole)]
    [ProtoContract]
    public class C2A_DelteRole: ProtoObject, IRequest
    {
        [ProtoMember(1)]
        public string Token { get; set; }

        [ProtoMember(2)]
        public int ServerId { get; set; }

        [ProtoMember(3)]
        public long AccountId { get; set; }

        [ProtoMember(4)]
        public long RoleId { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.A2C_DelteRole)]
    [ProtoContract]
    public class A2C_DelteRole: ProtoObject, IResponse
    {
        [ProtoMember(1)]
        public long RoleId { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    //============================================  登录流程  ============================================
    [ResponseType(nameof (A2C_GetRealmKey))]
    [Message(OuterMessage.C2A_GetRealmKey)]
    [ProtoContract]
    public class C2A_GetRealmKey: ProtoObject, IRequest
    {
        [ProtoMember(1)]
        public string Token { get; set; }

        [ProtoMember(2)]
        public int ServerId { get; set; }

        [ProtoMember(3)]
        public long AccountId { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.A2C_GetRealmKey)]
    [ProtoContract]
    public class A2C_GetRealmKey: ProtoObject, IResponse
    {
        [ProtoMember(1)]
        public string RealmToken { get; set; }

        [ProtoMember(2)]
        public string RealmAddress { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (R2C_LoginRealm))]
    [Message(OuterMessage.C2R_LoginRealm)]
    [ProtoContract]
    public class C2R_LoginRealm: ProtoObject, IRequest
    {
        [ProtoMember(1)]
        public string RealmToken { get; set; }

        [ProtoMember(2)]
        public long AccountId { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.R2C_LoginRealm)]
    [ProtoContract]
    public class R2C_LoginRealm: ProtoObject, IResponse
    {
        [ProtoMember(1)]
        public string GateSessionToken { get; set; }

        [ProtoMember(2)]
        public string GateAddress { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (G2C_LoginGameGate))]
    [Message(OuterMessage.C2G_LoginGameGate)]
    [ProtoContract]
    public class C2G_LoginGameGate: ProtoObject, IRequest
    {
        [ProtoMember(1)]
        public string Key { get; set; }

        [ProtoMember(2)]
        public long RoleId { get; set; }

        [ProtoMember(3)]
        public long AccountId { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.G2C_LoginGameGate)]
    [ProtoContract]
    public class G2C_LoginGameGate: ProtoObject, IResponse
    {
        [ProtoMember(1)]
        public long PlayerId { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (G2C_EnterGame))]
    [Message(OuterMessage.C2G_EnterGame)]
    [ProtoContract]
    public class C2G_EnterGame: ProtoObject, IRequest
    {
        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.G2C_EnterGame)]
    [ProtoContract]
    public class G2C_EnterGame: ProtoObject, IResponse
    {
        [ProtoMember(1)]
        public long UnitId { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    //============================================  移动同步  ============================================
    [Message(OuterMessage.C2M_JoyStop)]
    [ProtoContract]
    public class C2M_JoyStop: ProtoObject, IActorLocationMessage
    {
        [ProtoMember(1)]
        public float3 Position { get; set; }

        [ProtoMember(2)]
        public float3 Forward { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    //============================================  数值系统  ============================================
    [Message(OuterMessage.M2C_NoticeUnitNumeric)]
    [ProtoContract]
    public class M2C_NoticeUnitNumeric: ProtoObject, IActorMessage
    {
        [ProtoMember(1)]
        public long UnitId { get; set; }

        [ProtoMember(2)]
        public NumericType NumericType { get; set; }

        [ProtoMember(3)]
        public long NewValue { get; set; }
    }

    //============================================  属性点  ============================================
    [ResponseType(nameof (M2C_AddAttributePoints))]
    [Message(OuterMessage.C2M_AddAttributePoints)]
    [ProtoContract]
    public class C2M_AddAttributePoints: ProtoObject, IActorLocationRequest
    {
        [ProtoMember(1)]
        public List<NumericType> NumericTypes { get; set; } = new();

        [ProtoMember(2)]
        public List<long> AddValues { get; set; } = new();

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.M2C_AddAttributePoints)]
    [ProtoContract]
    public class M2C_AddAttributePoints: ProtoObject, IActorLocationResponse
    {
        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (M2C_UpRoleLevel))]
    [Message(OuterMessage.C2M_UpRoleLevel)]
    [ProtoContract]
    public class C2M_UpRoleLevel: ProtoObject, IActorLocationRequest
    {
        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.M2C_UpRoleLevel)]
    [ProtoContract]
    public class M2C_UpRoleLevel: ProtoObject, IActorLocationResponse
    {
        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    //============================================  道具系统  ============================================
    [Message(OuterMessage.ItemInfo)]
    [ProtoContract]
    public class ItemInfo: ProtoObject
    {
        [ProtoMember(1)]
        public long ItemUid { get; set; }

        [ProtoMember(2)]
        public int ItemConfigId { get; set; }

        [ProtoMember(3)]
        public int Count { get; set; }

        [ProtoMember(4)]
        public EquipInfoProto EquipInfo { get; set; }
    }

    [Message(OuterMessage.M2C_AllItemsList)]
    [ProtoContract]
    public class M2C_AllItemsList: ProtoObject, IActorMessage
    {
        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(1)]
        public List<ItemInfo> ItemInfoList { get; set; } = new();

        [ProtoMember(2)]
        public ItemContainerType ContainerType { get; set; }
    }

    [Message(OuterMessage.M2C_ItemUpdateOpInfo)]
    [ProtoContract]
    public class M2C_ItemUpdateOpInfo: ProtoObject, IActorMessage
    {
        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(1)]
        public ItemInfo ItemInfo { get; set; }

        [ProtoMember(2)]
        public ItemOp Op { get; set; }

        [ProtoMember(3)]
        public ItemContainerType ContainerType { get; set; }
    }

    [ResponseType(nameof (M2C_SellItem))]
    [Message(OuterMessage.C2M_SellItem)]
    [ProtoContract]
    public class C2M_SellItem: ProtoObject, IActorLocationRequest
    {
        [ProtoMember(2)]
        public long ItemUid { get; set; }

        [ProtoMember(3)]
        public int Count { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.M2C_SellItem)]
    [ProtoContract]
    public class M2C_SellItem: ProtoObject, IActorLocationResponse
    {
        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    //============================================  商店系统  ============================================
    [ResponseType(nameof (M2C_BuyItem))]
    [Message(OuterMessage.C2M_BuyItem)]
    [ProtoContract]
    public class C2M_BuyItem: ProtoObject, IActorLocationRequest
    {
        [ProtoMember(2)]
        public int ConfigId { get; set; }

        [ProtoMember(3)]
        public int Count { get; set; }

        [ProtoMember(1)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.M2C_BuyItem)]
    [ProtoContract]
    public class M2C_BuyItem: ProtoObject, IActorLocationResponse
    {
        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    //============================================  装备系统  ============================================
    [Message(OuterMessage.AttributeEntryProto)]
    [ProtoContract]
    public class AttributeEntryProto: ProtoObject
    {
        [ProtoMember(1)]
        public long Id { get; set; }

        [ProtoMember(2)]
        public EntryType EntryType { get; set; }

        [ProtoMember(3)]
        public NumericType AttributeName { get; set; }

        [ProtoMember(4)]
        public long AttributeValue { get; set; }
    }

    [Message(OuterMessage.EquipInfoProto)]
    [ProtoContract]
    public class EquipInfoProto: ProtoObject
    {
        [ProtoMember(1)]
        public long Id { get; set; }

        [ProtoMember(2)]
        public int Score { get; set; }

        [ProtoMember(3)]
        public int Quality { get; set; }

        [ProtoMember(4)]
        public List<AttributeEntryProto> AttributeEntryList { get; set; } = new();
    }

    [ResponseType(nameof (M2C_EquipItem))]
    [Message(OuterMessage.C2M_EquipItem)]
    [ProtoContract]
    public class C2M_EquipItem: ProtoObject, IActorLocationRequest
    {
        [ProtoMember(1)]
        public long ItemUid { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.M2C_EquipItem)]
    [ProtoContract]
    public class M2C_EquipItem: ProtoObject, IActorLocationResponse
    {
        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    [ResponseType(nameof (M2C_UnloadEquipItem))]
    [Message(OuterMessage.C2M_UnloadEquipItem)]
    [ProtoContract]
    public class C2M_UnloadEquipItem: ProtoObject, IActorLocationRequest
    {
        [ProtoMember(1)]
        public EquipPosition EquipPosition { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.M2C_UnloadEquipItem)]
    [ProtoContract]
    public class M2C_UnloadEquipItem: ProtoObject, IActorLocationResponse
    {
        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    //============================================  任务系统  ============================================
    [Message(OuterMessage.NTaskTarget)]
    [ProtoContract]
    public partial class NTaskTarget: ProtoObject
    {
        [ProtoMember(1)]
        public TaskTargetType Type { get; set; }

        [ProtoMember(2)]
        public int Target { get; set; }

        [ProtoMember(3)]
        public int Count { get; set; }
    }

    [Message(OuterMessage.NTaskInfo)]
    [ProtoContract]
    public class NTaskInfo: ProtoObject
    {
        [ProtoMember(1)]
        public int ConfigId { get; set; }

        [ProtoMember(2)]
        public TaskState TaskState { get; set; }

        [ProtoMember(3)]
        public List<NTaskTarget> Process { get; set; } = new();
    }

    [Message(OuterMessage.M2C_UpdateTaskInfo)]
    [ProtoContract]
    public class M2C_UpdateTaskInfo: ProtoObject, IActorMessage
    {
        [ProtoMember(1)]
        public NTaskInfo NTaskInfo { get; set; }
    }

    [Message(OuterMessage.M2C_AllTaskInfoList)]
    [ProtoContract]
    public class M2C_AllTaskInfoList: ProtoObject, IActorMessage
    {
        [ProtoMember(1)]
        public List<NTaskInfo> NTaskInfos { get; set; } = new();
    }

    [ResponseType(nameof (M2C_ReceiveTaskReward))]
    [Message(OuterMessage.C2M_ReceiveTaskReward)]
    [ProtoContract]
    public class C2M_ReceiveTaskReward: ProtoObject, IActorLocationRequest
    {
        [ProtoMember(1)]
        public int TaskConfigId { get; set; }

        [ProtoMember(90)]
        public int RpcId { get; set; }
    }

    [Message(OuterMessage.M2C_ReceiveTaskReward)]
    [ProtoContract]
    public class M2C_ReceiveTaskReward: ProtoObject, IActorLocationResponse
    {
        [ProtoMember(90)]
        public int RpcId { get; set; }

        [ProtoMember(91)]
        public int Error { get; set; }

        [ProtoMember(92)]
        public string Message { get; set; }
    }

    // //============================================  排行榜系统  ============================================
    // message RankInfoProto
    // {
    // 	int64 Id      = 1;
    // 	int64 UnitId  = 2;
    // 	string Name   = 4;
    // 	int32  Level  = 5;
    // }
    // //ResponseType Rank2C_GetRanksInfo
    // message C2Rank_GetRanksInfo // IActorRankInfoRequest
    // {
    // 	int32 RpcId        = 90;
    // }
    // message Rank2C_GetRanksInfo // IActorRankInfoResponse
    // {
    // 	int32 RpcId    = 90;
    // 	int32 Error    = 91;
    // 	string Message = 92;
    // 	repeated RankInfoProto RankInfoProtoList = 1;
    // }
    // //============================================  聊天系统  ============================================
    // //ResponseType Chat2C_SendChatInfo
    // message C2Chat_SendChatInfo // IActorChatInfoRequest
    // {
    // 	int32 RpcId         = 90;
    // 	string ChatMessage  = 1;
    // }
    // message Chat2C_SendChatInfo // IActorChatInfoResponse
    // {
    // 	int32 RpcId    = 90;
    // 	int32 Error    = 91;
    // 	string Message = 92;
    // }
    // message Chat2C_NoticeChatInfo // IActorMessage
    // {
    // 	string Name = 1;
    // 	string ChatMessage = 2;
    // }
    public static class OuterMessage
    {
        public const ushort HttpGetRouterResponse = 10002;
        public const ushort RouterSync = 10003;
        public const ushort C2M_TestRequest = 10004;
        public const ushort M2C_TestResponse = 10005;
        public const ushort Actor_TransferRequest = 10006;
        public const ushort Actor_TransferResponse = 10007;
        public const ushort C2G_EnterMap = 10008;
        public const ushort G2C_EnterMap = 10009;
        public const ushort MoveInfo = 10010;
        public const ushort UnitInfo = 10011;
        public const ushort M2C_CreateUnits = 10012;
        public const ushort M2C_CreateMyUnit = 10013;
        public const ushort M2C_StartSceneChange = 10014;
        public const ushort M2C_RemoveUnits = 10015;
        public const ushort C2M_PathfindingResult = 10016;
        public const ushort C2M_Stop = 10017;
        public const ushort M2C_PathfindingResult = 10018;
        public const ushort M2C_Stop = 10019;
        public const ushort C2G_Ping = 10020;
        public const ushort G2C_Ping = 10021;
        public const ushort G2C_Test = 10022;
        public const ushort C2M_Reload = 10023;
        public const ushort M2C_Reload = 10024;
        public const ushort C2R_Login = 10025;
        public const ushort R2C_Login = 10026;
        public const ushort C2G_LoginGate = 10027;
        public const ushort G2C_LoginGate = 10028;
        public const ushort G2C_TestHotfixMessage = 10029;
        public const ushort C2M_TestRobotCase = 10030;
        public const ushort M2C_TestRobotCase = 10031;
        public const ushort C2M_TransferMap = 10032;
        public const ushort M2C_TransferMap = 10033;
        public const ushort C2G_Benchmark = 10034;
        public const ushort G2C_Benchmark = 10035;
        public const ushort C2A_RegisterAccount = 10036;
        public const ushort A2C_RegisterAccount = 10037;
        public const ushort C2A_LoginAccount = 10038;
        public const ushort A2C_LoginAccount = 10039;
        public const ushort A2C_Disconnect = 10040;
        public const ushort NServerInfo = 10041;
        public const ushort C2A_GetServerInfos = 10042;
        public const ushort A2C_GetServerInfos = 10043;
        public const ushort NRoleInfo = 10044;
        public const ushort C2A_GetRoles = 10045;
        public const ushort A2C_GetRoles = 10046;
        public const ushort C2A_CreateRole = 10047;
        public const ushort A2C_CreateRole = 10048;
        public const ushort C2A_DelteRole = 10049;
        public const ushort A2C_DelteRole = 10050;
        public const ushort C2A_GetRealmKey = 10051;
        public const ushort A2C_GetRealmKey = 10052;
        public const ushort C2R_LoginRealm = 10053;
        public const ushort R2C_LoginRealm = 10054;
        public const ushort C2G_LoginGameGate = 10055;
        public const ushort G2C_LoginGameGate = 10056;
        public const ushort C2G_EnterGame = 10057;
        public const ushort G2C_EnterGame = 10058;
        public const ushort C2M_JoyStop = 10059;
        public const ushort M2C_NoticeUnitNumeric = 10060;
        public const ushort C2M_AddAttributePoints = 10061;
        public const ushort M2C_AddAttributePoints = 10062;
        public const ushort C2M_UpRoleLevel = 10063;
        public const ushort M2C_UpRoleLevel = 10064;
        public const ushort ItemInfo = 10065;
        public const ushort M2C_AllItemsList = 10066;
        public const ushort M2C_ItemUpdateOpInfo = 10067;
        public const ushort C2M_SellItem = 10068;
        public const ushort M2C_SellItem = 10069;
        public const ushort C2M_BuyItem = 10070;
        public const ushort M2C_BuyItem = 10071;
        public const ushort AttributeEntryProto = 10072;
        public const ushort EquipInfoProto = 10073;
        public const ushort C2M_EquipItem = 10074;
        public const ushort M2C_EquipItem = 10075;
        public const ushort C2M_UnloadEquipItem = 10076;
        public const ushort M2C_UnloadEquipItem = 10077;
        public const ushort NTaskTarget = 10078;
        public const ushort NTaskInfo = 10079;
        public const ushort M2C_UpdateTaskInfo = 10080;
        public const ushort M2C_AllTaskInfoList = 10081;
        public const ushort C2M_ReceiveTaskReward = 10082;
        public const ushort M2C_ReceiveTaskReward = 10083;
    }
}