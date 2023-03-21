using ET;
using ProtoBuf;
using System.Collections.Generic;
namespace ET
{
	[Message(OuterMessage.HttpGetRouterResponse)]
	[ProtoContract]
	public partial class HttpGetRouterResponse: ProtoObject
	{
		[ProtoMember(1)]
		public List<string> Realms { get; set; } = new();

		[ProtoMember(2)]
		public List<string> Routers { get; set; } = new();

	}

	[Message(OuterMessage.RouterSync)]
	[ProtoContract]
	public partial class RouterSync: ProtoObject
	{
		[ProtoMember(1)]
		public uint ConnectId { get; set; }

		[ProtoMember(2)]
		public string Address { get; set; }

	}

	[ResponseType(nameof(M2C_TestResponse))]
	[Message(OuterMessage.C2M_TestRequest)]
	[ProtoContract]
	public partial class C2M_TestRequest: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public string request { get; set; }

	}

	[Message(OuterMessage.M2C_TestResponse)]
	[ProtoContract]
	public partial class M2C_TestResponse: ProtoObject, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public string response { get; set; }

	}

	[ResponseType(nameof(Actor_TransferResponse))]
	[Message(OuterMessage.Actor_TransferRequest)]
	[ProtoContract]
	public partial class Actor_TransferRequest: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int MapIndex { get; set; }

	}

	[Message(OuterMessage.Actor_TransferResponse)]
	[ProtoContract]
	public partial class Actor_TransferResponse: ProtoObject, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2C_EnterMap))]
	[Message(OuterMessage.C2G_EnterMap)]
	[ProtoContract]
	public partial class C2G_EnterMap: ProtoObject, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterMessage.G2C_EnterMap)]
	[ProtoContract]
	public partial class G2C_EnterMap: ProtoObject, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

// 自己unitId
		[ProtoMember(4)]
		public long MyId { get; set; }

	}

	[Message(OuterMessage.MoveInfo)]
	[ProtoContract]
	public partial class MoveInfo: ProtoObject
	{
		[ProtoMember(1)]
		public List<Unity.Mathematics.float3> Points { get; set; } = new();

		[ProtoMember(2)]
		public Unity.Mathematics.quaternion Rotation { get; set; }

		[ProtoMember(3)]
		public int TurnSpeed { get; set; }

	}

	[Message(OuterMessage.UnitInfo)]
	[ProtoContract]
	public partial class UnitInfo: ProtoObject
	{
		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public int ConfigId { get; set; }

		[ProtoMember(3)]
		public int Type { get; set; }

		[ProtoMember(4)]
		public Unity.Mathematics.float3 Position { get; set; }

		[ProtoMember(5)]
		public Unity.Mathematics.float3 Forward { get; set; }

		[MongoDB.Bson.Serialization.Attributes.BsonDictionaryOptions(MongoDB.Bson.Serialization.Options.DictionaryRepresentation.ArrayOfArrays)]
		[ProtoMember(6)]
		public Dictionary<int, long> KV { get; set; }
		[ProtoMember(7)]
		public MoveInfo MoveInfo { get; set; }

	}

	[Message(OuterMessage.M2C_CreateUnits)]
	[ProtoContract]
	public partial class M2C_CreateUnits: ProtoObject, IActorMessage
	{
		[ProtoMember(1)]
		public List<UnitInfo> Units { get; set; } = new();

	}

	[Message(OuterMessage.M2C_CreateMyUnit)]
	[ProtoContract]
	public partial class M2C_CreateMyUnit: ProtoObject, IActorMessage
	{
		[ProtoMember(1)]
		public UnitInfo Unit { get; set; }

	}

	[Message(OuterMessage.M2C_StartSceneChange)]
	[ProtoContract]
	public partial class M2C_StartSceneChange: ProtoObject, IActorMessage
	{
		[ProtoMember(1)]
		public long SceneInstanceId { get; set; }

		[ProtoMember(2)]
		public string SceneName { get; set; }

	}

	[Message(OuterMessage.M2C_RemoveUnits)]
	[ProtoContract]
	public partial class M2C_RemoveUnits: ProtoObject, IActorMessage
	{
		[ProtoMember(2)]
		public List<long> Units { get; set; } = new();

	}

	[Message(OuterMessage.C2M_PathfindingResult)]
	[ProtoContract]
	public partial class C2M_PathfindingResult: ProtoObject, IActorLocationMessage
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public Unity.Mathematics.float3 Position { get; set; }

	}

	[Message(OuterMessage.C2M_Stop)]
	[ProtoContract]
	public partial class C2M_Stop: ProtoObject, IActorLocationMessage
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterMessage.M2C_PathfindingResult)]
	[ProtoContract]
	public partial class M2C_PathfindingResult: ProtoObject, IActorMessage
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public Unity.Mathematics.float3 Position { get; set; }

		[ProtoMember(3)]
		public List<Unity.Mathematics.float3> Points { get; set; } = new();

	}

	[Message(OuterMessage.M2C_Stop)]
	[ProtoContract]
	public partial class M2C_Stop: ProtoObject, IActorMessage
	{
		[ProtoMember(1)]
		public int Error { get; set; }

		[ProtoMember(2)]
		public long Id { get; set; }

		[ProtoMember(3)]
		public Unity.Mathematics.float3 Position { get; set; }

		[ProtoMember(4)]
		public Unity.Mathematics.quaternion Rotation { get; set; }

	}

	[ResponseType(nameof(G2C_Ping))]
	[Message(OuterMessage.C2G_Ping)]
	[ProtoContract]
	public partial class C2G_Ping: ProtoObject, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterMessage.G2C_Ping)]
	[ProtoContract]
	public partial class G2C_Ping: ProtoObject, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public long Time { get; set; }

	}

	[Message(OuterMessage.G2C_Test)]
	[ProtoContract]
	public partial class G2C_Test: ProtoObject, IMessage
	{
	}

	[ResponseType(nameof(M2C_Reload))]
	[Message(OuterMessage.C2M_Reload)]
	[ProtoContract]
	public partial class C2M_Reload: ProtoObject, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public string Account { get; set; }

		[ProtoMember(3)]
		public string Password { get; set; }

	}

	[Message(OuterMessage.M2C_Reload)]
	[ProtoContract]
	public partial class M2C_Reload: ProtoObject, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(R2C_Login))]
	[Message(OuterMessage.C2R_Login)]
	[ProtoContract]
	public partial class C2R_Login: ProtoObject, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public string Account { get; set; }

		[ProtoMember(3)]
		public string Password { get; set; }

	}

	[Message(OuterMessage.R2C_Login)]
	[ProtoContract]
	public partial class R2C_Login: ProtoObject, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public string Address { get; set; }

		[ProtoMember(5)]
		public long Key { get; set; }

		[ProtoMember(6)]
		public long GateId { get; set; }

	}

	[ResponseType(nameof(G2C_LoginGate))]
	[Message(OuterMessage.C2G_LoginGate)]
	[ProtoContract]
	public partial class C2G_LoginGate: ProtoObject, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public long Key { get; set; }

		[ProtoMember(3)]
		public long GateId { get; set; }

	}

	[Message(OuterMessage.G2C_LoginGate)]
	[ProtoContract]
	public partial class G2C_LoginGate: ProtoObject, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public long PlayerId { get; set; }

	}

	[Message(OuterMessage.G2C_TestHotfixMessage)]
	[ProtoContract]
	public partial class G2C_TestHotfixMessage: ProtoObject, IMessage
	{
		[ProtoMember(1)]
		public string Info { get; set; }

	}

	[ResponseType(nameof(M2C_TestRobotCase))]
	[Message(OuterMessage.C2M_TestRobotCase)]
	[ProtoContract]
	public partial class C2M_TestRobotCase: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int N { get; set; }

	}

	[Message(OuterMessage.M2C_TestRobotCase)]
	[ProtoContract]
	public partial class M2C_TestRobotCase: ProtoObject, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

		[ProtoMember(4)]
		public int N { get; set; }

	}

	[ResponseType(nameof(M2C_TransferMap))]
	[Message(OuterMessage.C2M_TransferMap)]
	[ProtoContract]
	public partial class C2M_TransferMap: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterMessage.M2C_TransferMap)]
	[ProtoContract]
	public partial class M2C_TransferMap: ProtoObject, IActorLocationResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2C_Benchmark))]
	[Message(OuterMessage.C2G_Benchmark)]
	[ProtoContract]
	public partial class C2G_Benchmark: ProtoObject, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterMessage.G2C_Benchmark)]
	[ProtoContract]
	public partial class G2C_Benchmark: ProtoObject, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

	}

//============================================  账号系统  ============================================
	[ResponseType(nameof(A2C_LoginAccount))]
	[Message(OuterMessage.C2A_LoginAccount)]
	[ProtoContract]
	public partial class C2A_LoginAccount: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string AccountName { get; set; }

		[ProtoMember(2)]
		public string Password { get; set; }

	}

	[Message(OuterMessage.A2C_LoginAccount)]
	[ProtoContract]
	public partial class A2C_LoginAccount: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

	}

	[Message(OuterMessage.A2C_Disconnect)]
	[ProtoContract]
	public partial class A2C_Disconnect: ProtoObject, IMessage
	{
		[ProtoMember(1)]
		public int Error { get; set; }

	}

//============================================  服务器选择流程  ============================================
	[Message(OuterMessage.NServerInfo)]
	[ProtoContract]
	public partial class NServerInfo: ProtoObject
	{
		[ProtoMember(1)]
		public int Id { get; set; }

		[ProtoMember(2)]
		public int Status { get; set; }

		[ProtoMember(3)]
		public string ServerName { get; set; }

	}

	[ResponseType(nameof(A2C_GetServerInfos))]
	[Message(OuterMessage.C2A_GetServerInfos)]
	[ProtoContract]
	public partial class C2A_GetServerInfos: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

	}

	[Message(OuterMessage.A2C_GetServerInfos)]
	[ProtoContract]
	public partial class A2C_GetServerInfos: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<NServerInfo> NServerInfos { get; set; } = new();

	}

//============================================  角色创建/选择流程  ============================================
	[Message(OuterMessage.NRoleInfo)]
	[ProtoContract]
	public partial class NRoleInfo: ProtoObject
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public int ServerId { get; set; }

		[ProtoMember(4)]
		public int Status { get; set; }

		[ProtoMember(5)]
		public long AccountId { get; set; }

		[ProtoMember(6)]
		public long LastLoginTIme { get; set; }

		[ProtoMember(7)]
		public long CreateTime { get; set; }

	}

	[ResponseType(nameof(A2C_GetRoles))]
	[Message(OuterMessage.C2A_GetRoles)]
	[ProtoContract]
	public partial class C2A_GetRoles: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public int ServerId { get; set; }

		[ProtoMember(3)]
		public long AccountId { get; set; }

	}

	[Message(OuterMessage.A2C_GetRoles)]
	[ProtoContract]
	public partial class A2C_GetRoles: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<NRoleInfo> NRoleInfos { get; set; } = new();

	}

	[ResponseType(nameof(A2C_CreateRole))]
	[Message(OuterMessage.C2A_CreateRole)]
	[ProtoContract]
	public partial class C2A_CreateRole: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public int ServerId { get; set; }

		[ProtoMember(3)]
		public long AccountId { get; set; }

		[ProtoMember(4)]
		public string Name { get; set; }

	}

	[Message(OuterMessage.A2C_CreateRole)]
	[ProtoContract]
	public partial class A2C_CreateRole: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public NRoleInfo NRoleInfo { get; set; }

	}

	[ResponseType(nameof(A2C_DelteRole))]
	[Message(OuterMessage.C2A_DelteRole)]
	[ProtoContract]
	public partial class C2A_DelteRole: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public int ServerId { get; set; }

		[ProtoMember(3)]
		public long AccountId { get; set; }

		[ProtoMember(4)]
		public long RoleId { get; set; }

	}

	[Message(OuterMessage.A2C_DelteRole)]
	[ProtoContract]
	public partial class A2C_DelteRole: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long RoleId { get; set; }

	}

//============================================  登录流程  ============================================
	[ResponseType(nameof(A2C_GetRealmKey))]
	[Message(OuterMessage.C2A_GetRealmKey)]
	[ProtoContract]
	public partial class C2A_GetRealmKey: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public int ServerId { get; set; }

		[ProtoMember(3)]
		public long AccountId { get; set; }

	}

	[Message(OuterMessage.A2C_GetRealmKey)]
	[ProtoContract]
	public partial class A2C_GetRealmKey: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string RealmToken { get; set; }

		[ProtoMember(2)]
		public string RealmAddress { get; set; }

	}

	[ResponseType(nameof(R2C_LoginRealm))]
	[Message(OuterMessage.C2R_LoginRealm)]
	[ProtoContract]
	public partial class C2R_LoginRealm: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string RealmToken { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

	}

	[Message(OuterMessage.R2C_LoginRealm)]
	[ProtoContract]
	public partial class R2C_LoginRealm: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string GateSessionToken { get; set; }

		[ProtoMember(2)]
		public string GateAddress { get; set; }

	}

	[ResponseType(nameof(G2C_LoginGameGate))]
	[Message(OuterMessage.C2G_LoginGameGate)]
	[ProtoContract]
	public partial class C2G_LoginGameGate: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Key { get; set; }

		[ProtoMember(2)]
		public long RoleId { get; set; }

		[ProtoMember(3)]
		public long AccountId { get; set; }

	}

	[Message(OuterMessage.G2C_LoginGameGate)]
	[ProtoContract]
	public partial class G2C_LoginGameGate: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

	}

	[ResponseType(nameof(G2C_EnterGame))]
	[Message(OuterMessage.C2G_EnterGame)]
	[ProtoContract]
	public partial class C2G_EnterGame: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterMessage.G2C_EnterGame)]
	[ProtoContract]
	public partial class G2C_EnterGame: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long UnitId { get; set; }

	}

//============================================  数值系统  ============================================
	[Message(OuterMessage.M2C_NoticeUnitNumeric)]
	[ProtoContract]
	public partial class M2C_NoticeUnitNumeric: ProtoObject, IActorMessage
	{
		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public int NumericType { get; set; }

		[ProtoMember(3)]
		public long NewValue { get; set; }

	}

//============================================  属性点  ============================================
	[ResponseType(nameof(M2C_AddAttributePoints))]
	[Message(OuterMessage.C2M_AddAttributePoints)]
	[ProtoContract]
	public partial class C2M_AddAttributePoints: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public List<int> NumericTypes { get; set; } = new();

		[ProtoMember(2)]
		public List<long> AddValues { get; set; } = new();

	}

	[Message(OuterMessage.M2C_AddAttributePoints)]
	[ProtoContract]
	public partial class M2C_AddAttributePoints: ProtoObject, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

//============================================  闯关系统  ============================================
	[ResponseType(nameof(M2C_StartGameLevel))]
	[Message(OuterMessage.C2M_StartGameLevel)]
	[ProtoContract]
	public partial class C2M_StartGameLevel: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int LevelId { get; set; }

	}

	[Message(OuterMessage.M2C_StartGameLevel)]
	[ProtoContract]
	public partial class M2C_StartGameLevel: ProtoObject, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(M2C_EndGameLevel))]
	[Message(OuterMessage.C2M_EndGameLevel)]
	[ProtoContract]
	public partial class C2M_EndGameLevel: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int Round { get; set; }

		[ProtoMember(2)]
		public int BattleResult { get; set; }

	}

	[Message(OuterMessage.M2C_EndGameLevel)]
	[ProtoContract]
	public partial class M2C_EndGameLevel: ProtoObject, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(M2C_UpRoleLevel))]
	[Message(OuterMessage.C2M_UpRoleLevel)]
	[ProtoContract]
	public partial class C2M_UpRoleLevel: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterMessage.M2C_UpRoleLevel)]
	[ProtoContract]
	public partial class M2C_UpRoleLevel: ProtoObject, IActorLocationResponse
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
	public partial class ItemInfo: ProtoObject
	{
		[ProtoMember(1)]
		public long ItemUid { get; set; }

		[ProtoMember(2)]
		public int ItemConfigId { get; set; }

		[ProtoMember(3)]
		public int ItemQuality { get; set; }

		[ProtoMember(4)]
		public EquipInfoProto EquipInfo { get; set; }

	}

	[Message(OuterMessage.M2C_AllItemsList)]
	[ProtoContract]
	public partial class M2C_AllItemsList: ProtoObject, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public List<ItemInfo> ItemInfoList { get; set; } = new();

		[ProtoMember(2)]
		public int ContainerType { get; set; }

	}

	[Message(OuterMessage.M2C_ItemUpdateOpInfo)]
	[ProtoContract]
	public partial class M2C_ItemUpdateOpInfo: ProtoObject, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public ItemInfo ItemInfo { get; set; }

		[ProtoMember(2)]
		public int Op { get; set; }

		[ProtoMember(3)]
		public int ContainerType { get; set; }

	}

	[ResponseType(nameof(M2C_SellItem))]
	[Message(OuterMessage.C2M_SellItem)]
	[ProtoContract]
	public partial class C2M_SellItem: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public long ItemUid { get; set; }

	}

	[Message(OuterMessage.M2C_SellItem)]
	[ProtoContract]
	public partial class M2C_SellItem: ProtoObject, IActorLocationResponse
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
	public partial class AttributeEntryProto: ProtoObject
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public int EntryType { get; set; }

		[ProtoMember(3)]
		public int AttributeName { get; set; }

		[ProtoMember(4)]
		public long AttributeValue { get; set; }

	}

	[Message(OuterMessage.EquipInfoProto)]
	[ProtoContract]
	public partial class EquipInfoProto: ProtoObject
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public int Score { get; set; }

		[ProtoMember(3)]
		public List<AttributeEntryProto> AttributeEntryList { get; set; } = new();

	}

	[ResponseType(nameof(M2C_EquipItem))]
	[Message(OuterMessage.C2M_EquipItem)]
	[ProtoContract]
	public partial class C2M_EquipItem: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long ItemUid { get; set; }

	}

	[Message(OuterMessage.M2C_EquipItem)]
	[ProtoContract]
	public partial class M2C_EquipItem: ProtoObject, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(M2C_UnloadEquipItem))]
	[Message(OuterMessage.C2M_UnloadEquipItem)]
	[ProtoContract]
	public partial class C2M_UnloadEquipItem: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int EquipPosition { get; set; }

	}

	[Message(OuterMessage.M2C_UnloadEquipItem)]
	[ProtoContract]
	public partial class M2C_UnloadEquipItem: ProtoObject, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

//============================================  打造系统  ============================================
	[Message(OuterMessage.ProductionProto)]
	[ProtoContract]
	public partial class ProductionProto: ProtoObject
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public int ConfigId { get; set; }

		[ProtoMember(3)]
		public long TargetTime { get; set; }

		[ProtoMember(4)]
		public long StartTime { get; set; }

		[ProtoMember(5)]
		public int ProductionState { get; set; }

	}

	[ResponseType(nameof(M2C_StartProduction))]
	[Message(OuterMessage.C2M_StartProduction)]
	[ProtoContract]
	public partial class C2M_StartProduction: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int ConfigId { get; set; }

	}

	[Message(OuterMessage.M2C_StartProduction)]
	[ProtoContract]
	public partial class M2C_StartProduction: ProtoObject, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public ProductionProto ProductionProto { get; set; }

	}

	[ResponseType(nameof(M2C_ReceiveProduction))]
	[Message(OuterMessage.C2M_ReceiveProduction)]
	[ProtoContract]
	public partial class C2M_ReceiveProduction: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long ProducitonId { get; set; }

	}

	[Message(OuterMessage.M2C_ReceiveProduction)]
	[ProtoContract]
	public partial class M2C_ReceiveProduction: ProtoObject, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public ProductionProto ProductionProto { get; set; }

	}

	[Message(OuterMessage.M2C_AllProductionList)]
	[ProtoContract]
	public partial class M2C_AllProductionList: ProtoObject, IActorMessage
	{
		[ProtoMember(1)]
		public List<ProductionProto> ProductionProtoList { get; set; } = new();

	}

//============================================  任务系统  ============================================
	[Message(OuterMessage.TaskInfoProto)]
	[ProtoContract]
	public partial class TaskInfoProto: ProtoObject
	{
		[ProtoMember(1)]
		public int ConfigId { get; set; }

		[ProtoMember(2)]
		public int TaskState { get; set; }

		[ProtoMember(3)]
		public int TaskPogress { get; set; }

	}

	[Message(OuterMessage.M2C_UpdateTaskInfo)]
	[ProtoContract]
	public partial class M2C_UpdateTaskInfo: ProtoObject, IActorMessage
	{
		[ProtoMember(1)]
		public TaskInfoProto TaskInfoProto { get; set; }

	}

	[Message(OuterMessage.M2C_AllTaskInfoList)]
	[ProtoContract]
	public partial class M2C_AllTaskInfoList: ProtoObject, IActorMessage
	{
		[ProtoMember(1)]
		public List<TaskInfoProto> TaskInfoProtoList { get; set; } = new();

	}

	[ResponseType(nameof(M2C_ReceiveTaskReward))]
	[Message(OuterMessage.C2M_ReceiveTaskReward)]
	[ProtoContract]
	public partial class C2M_ReceiveTaskReward: ProtoObject, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int TaskConfigId { get; set; }

	}

	[Message(OuterMessage.M2C_ReceiveTaskReward)]
	[ProtoContract]
	public partial class M2C_ReceiveTaskReward: ProtoObject, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

//============================================  排行榜系统  ============================================
	[Message(OuterMessage.RankInfoProto)]
	[ProtoContract]
	public partial class RankInfoProto: ProtoObject
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public long UnitId { get; set; }

		[ProtoMember(4)]
		public string Name { get; set; }

		[ProtoMember(5)]
		public int Level { get; set; }

	}

	[ResponseType(nameof(Rank2C_GetRanksInfo))]
	[Message(OuterMessage.C2Rank_GetRanksInfo)]
	[ProtoContract]
	public partial class C2Rank_GetRanksInfo: ProtoObject, IActorRankInfoRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterMessage.Rank2C_GetRanksInfo)]
	[ProtoContract]
	public partial class Rank2C_GetRanksInfo: ProtoObject, IActorRankInfoResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public List<RankInfoProto> RankInfoProtoList { get; set; } = new();

	}

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
		 public const ushort C2A_LoginAccount = 10036;
		 public const ushort A2C_LoginAccount = 10037;
		 public const ushort A2C_Disconnect = 10038;
		 public const ushort NServerInfo = 10039;
		 public const ushort C2A_GetServerInfos = 10040;
		 public const ushort A2C_GetServerInfos = 10041;
		 public const ushort NRoleInfo = 10042;
		 public const ushort C2A_GetRoles = 10043;
		 public const ushort A2C_GetRoles = 10044;
		 public const ushort C2A_CreateRole = 10045;
		 public const ushort A2C_CreateRole = 10046;
		 public const ushort C2A_DelteRole = 10047;
		 public const ushort A2C_DelteRole = 10048;
		 public const ushort C2A_GetRealmKey = 10049;
		 public const ushort A2C_GetRealmKey = 10050;
		 public const ushort C2R_LoginRealm = 10051;
		 public const ushort R2C_LoginRealm = 10052;
		 public const ushort C2G_LoginGameGate = 10053;
		 public const ushort G2C_LoginGameGate = 10054;
		 public const ushort C2G_EnterGame = 10055;
		 public const ushort G2C_EnterGame = 10056;
		 public const ushort M2C_NoticeUnitNumeric = 10057;
		 public const ushort C2M_AddAttributePoints = 10058;
		 public const ushort M2C_AddAttributePoints = 10059;
		 public const ushort C2M_StartGameLevel = 10060;
		 public const ushort M2C_StartGameLevel = 10061;
		 public const ushort C2M_EndGameLevel = 10062;
		 public const ushort M2C_EndGameLevel = 10063;
		 public const ushort C2M_UpRoleLevel = 10064;
		 public const ushort M2C_UpRoleLevel = 10065;
		 public const ushort ItemInfo = 10066;
		 public const ushort M2C_AllItemsList = 10067;
		 public const ushort M2C_ItemUpdateOpInfo = 10068;
		 public const ushort C2M_SellItem = 10069;
		 public const ushort M2C_SellItem = 10070;
		 public const ushort AttributeEntryProto = 10071;
		 public const ushort EquipInfoProto = 10072;
		 public const ushort C2M_EquipItem = 10073;
		 public const ushort M2C_EquipItem = 10074;
		 public const ushort C2M_UnloadEquipItem = 10075;
		 public const ushort M2C_UnloadEquipItem = 10076;
		 public const ushort ProductionProto = 10077;
		 public const ushort C2M_StartProduction = 10078;
		 public const ushort M2C_StartProduction = 10079;
		 public const ushort C2M_ReceiveProduction = 10080;
		 public const ushort M2C_ReceiveProduction = 10081;
		 public const ushort M2C_AllProductionList = 10082;
		 public const ushort TaskInfoProto = 10083;
		 public const ushort M2C_UpdateTaskInfo = 10084;
		 public const ushort M2C_AllTaskInfoList = 10085;
		 public const ushort C2M_ReceiveTaskReward = 10086;
		 public const ushort M2C_ReceiveTaskReward = 10087;
		 public const ushort RankInfoProto = 10088;
		 public const ushort C2Rank_GetRanksInfo = 10089;
		 public const ushort Rank2C_GetRanksInfo = 10090;
	}
}
