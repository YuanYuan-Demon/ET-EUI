using System.Collections.Generic;

public class AOTGenericReferences: UnityEngine.MonoBehaviour
{
    // {{ AOT assemblies
    public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
    {
        "Cinemachine.dll",
        "DOTween.dll",
        "MongoDB.Bson.dll",
        "System.Core.dll",
        "System.dll",
        "Unity.Core.dll",
        "Unity.Loader.dll",
        "Unity.ThirdParty.dll",
        "UnityEngine.CoreModule.dll",
        "mscorlib.dll",
    };
    // }}

    // {{ constraint implement type
    // }} 

    // {{ AOT generic types
    // ET.AEvent.<Handle>d__3<ET.Client.EventType.ChangeEquipItem>
    // ET.AEvent.<Handle>d__3<ET.Client.EventType.FriendUpdate>
    // ET.AEvent.<Handle>d__3<ET.Client.EventType.PrivateChat>
    // ET.AEvent.<Handle>d__3<ET.Client.EventType.SelectTask>
    // ET.AEvent.<Handle>d__3<ET.Client.EventType.UpdateChat>
    // ET.AEvent.<Handle>d__3<ET.Client.EventType.UpdateTaskInfo>
    // ET.AEvent.<Handle>d__3<ET.Client.NetClientComponentOnRead>
    // ET.AEvent.<Handle>d__3<ET.EventType.AfterCreateClientScene>
    // ET.AEvent.<Handle>d__3<ET.EventType.AfterCreateCurrentScene>
    // ET.AEvent.<Handle>d__3<ET.EventType.AfterUnitCreate>
    // ET.AEvent.<Handle>d__3<ET.EventType.AppStartInitFinish>
    // ET.AEvent.<Handle>d__3<ET.EventType.ChangePosition>
    // ET.AEvent.<Handle>d__3<ET.EventType.ChangeRotation>
    // ET.AEvent.<Handle>d__3<ET.EventType.EnterMapFinish>
    // ET.AEvent.<Handle>d__3<ET.EventType.EntryEvent1>
    // ET.AEvent.<Handle>d__3<ET.EventType.EntryEvent2>
    // ET.AEvent.<Handle>d__3<ET.EventType.EntryEvent3>
    // ET.AEvent.<Handle>d__3<ET.EventType.LoginFinish>
    // ET.AEvent.<Handle>d__3<ET.EventType.MoveStart>
    // ET.AEvent.<Handle>d__3<ET.EventType.MoveStop>
    // ET.AEvent.<Handle>d__3<ET.EventType.NumbericChange>
    // ET.AEvent.<Handle>d__3<ET.EventType.SceneChangeFinish>
    // ET.AEvent.<Handle>d__3<ET.EventType.SceneChangeStart>
    // ET.AEvent.<Handle>d__3<ET.EventType.SelectRole>
    // ET.AEvent.<Handle>d__3<ET.EventType.SelectRoleClass>
    // ET.AEvent.<Handle>d__3<ET.EventType.SelectShopItem>
    // ET.AEvent.<Handle>d__3<ET.EventType.ShowCreateRolePanel>
    // ET.AEvent<ET.Client.EventType.ChangeEquipItem>
    // ET.AEvent<ET.Client.EventType.FriendUpdate>
    // ET.AEvent<ET.Client.EventType.PrivateChat>
    // ET.AEvent<ET.Client.EventType.SelectTask>
    // ET.AEvent<ET.Client.EventType.UpdateChat>
    // ET.AEvent<ET.Client.EventType.UpdateTaskInfo>
    // ET.AEvent<ET.Client.NetClientComponentOnRead>
    // ET.AEvent<ET.EventType.AfterCreateClientScene>
    // ET.AEvent<ET.EventType.AfterCreateCurrentScene>
    // ET.AEvent<ET.EventType.AfterUnitCreate>
    // ET.AEvent<ET.EventType.AppStartInitFinish>
    // ET.AEvent<ET.EventType.ChangePosition>
    // ET.AEvent<ET.EventType.ChangeRotation>
    // ET.AEvent<ET.EventType.EnterMapFinish>
    // ET.AEvent<ET.EventType.EntryEvent1>
    // ET.AEvent<ET.EventType.EntryEvent2>
    // ET.AEvent<ET.EventType.EntryEvent3>
    // ET.AEvent<ET.EventType.LoginFinish>
    // ET.AEvent<ET.EventType.MoveStart>
    // ET.AEvent<ET.EventType.MoveStop>
    // ET.AEvent<ET.EventType.NumbericChange>
    // ET.AEvent<ET.EventType.SceneChangeFinish>
    // ET.AEvent<ET.EventType.SceneChangeStart>
    // ET.AEvent<ET.EventType.SelectRole>
    // ET.AEvent<ET.EventType.SelectRoleClass>
    // ET.AEvent<ET.EventType.SelectShopItem>
    // ET.AEvent<ET.EventType.ShowCreateRolePanel>
    // ET.AInvokeHandler<ET.ConfigComponent.GetAllConfigBytes,object>
    // ET.AInvokeHandler<ET.ConfigComponent.GetOneConfigBytes,object>
    // ET.AInvokeHandler<ET.NavmeshComponent.RecastFileLoader,object>
    // ET.AInvokeHandler<ET.TimerCallback>
    // ET.ATimer<object>
    // ET.AwakeSystem<object,int>
    // ET.AwakeSystem<object,object,int>
    // ET.AwakeSystem<object,object,object>
    // ET.AwakeSystem<object,object>
    // ET.AwakeSystem<object>
    // ET.ConfigSingleton<object>
    // ET.DestroySystem<object>
    // ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_CreateMyUnit>
    // ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_SceneChangeFinish>
    // ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_UnitAddGOComponent>
    // ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_UnitStop>
    // ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>
    // ET.ETAsyncTaskMethodBuilder<byte>
    // ET.ETAsyncTaskMethodBuilder<int>
    // ET.ETAsyncTaskMethodBuilder<object>
    // ET.ETAsyncTaskMethodBuilder<uint>
    // ET.ETTask.<InnerCoroutine>d__8<ET.Client.Wait_CreateMyUnit>
    // ET.ETTask.<InnerCoroutine>d__8<ET.Client.Wait_SceneChangeFinish>
    // ET.ETTask.<InnerCoroutine>d__8<ET.Client.Wait_UnitAddGOComponent>
    // ET.ETTask.<InnerCoroutine>d__8<ET.Client.Wait_UnitStop>
    // ET.ETTask.<InnerCoroutine>d__8<System.ValueTuple<uint,object>>
    // ET.ETTask.<InnerCoroutine>d__8<byte>
    // ET.ETTask.<InnerCoroutine>d__8<int>
    // ET.ETTask.<InnerCoroutine>d__8<object>
    // ET.ETTask.<InnerCoroutine>d__8<uint>
    // ET.ETTask<ET.Client.Wait_CreateMyUnit>
    // ET.ETTask<ET.Client.Wait_SceneChangeFinish>
    // ET.ETTask<ET.Client.Wait_UnitAddGOComponent>
    // ET.ETTask<ET.Client.Wait_UnitStop>
    // ET.ETTask<System.ValueTuple<uint,object>>
    // ET.ETTask<byte>
    // ET.ETTask<int>
    // ET.ETTask<object>
    // ET.ETTask<uint>
    // ET.EventSystem.<PublishAsync>d__24<ET.Client.EventType.ChangeEquipItem>
    // ET.EventSystem.<PublishAsync>d__24<ET.Client.EventType.FriendUpdate>
    // ET.EventSystem.<PublishAsync>d__24<ET.Client.EventType.UpdateChat>
    // ET.EventSystem.<PublishAsync>d__24<ET.EventType.AfterCreateClientScene>
    // ET.EventSystem.<PublishAsync>d__24<ET.EventType.AppStartInitFinish>
    // ET.EventSystem.<PublishAsync>d__24<ET.EventType.EntryEvent1>
    // ET.EventSystem.<PublishAsync>d__24<ET.EventType.EntryEvent2>
    // ET.EventSystem.<PublishAsync>d__24<ET.EventType.EntryEvent3>
    // ET.IAwake<int>
    // ET.IAwake<object,int>
    // ET.IAwake<object,object>
    // ET.IAwake<object>
    // ET.IAwakeSystem<int>
    // ET.IAwakeSystem<object,int>
    // ET.IAwakeSystem<object,object>
    // ET.IAwakeSystem<object>
    // ET.LateUpdateSystem<object>
    // ET.ListComponent<Unity.Mathematics.float3>
    // ET.ListComponent<object>
    // ET.LoadSystem<object>
    // ET.MultiMap<int,object>
    // ET.Singleton<object>
    // ET.UpdateSystem<object>
    // MongoDB.Bson.Serialization.IBsonSerializer<object>
    // System.Action<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Action<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Action<Unity.Mathematics.float3>
    // System.Action<int>
    // System.Action<long,int>
    // System.Action<long,long,object>
    // System.Action<long>
    // System.Action<object,int>
    // System.Action<object,object>
    // System.Action<object>
    // System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Collections.Generic.ArraySortHelper<Unity.Mathematics.float3>
    // System.Collections.Generic.ArraySortHelper<int>
    // System.Collections.Generic.ArraySortHelper<long>
    // System.Collections.Generic.ArraySortHelper<object>
    // System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Collections.Generic.Comparer<Unity.Mathematics.float3>
    // System.Collections.Generic.Comparer<int>
    // System.Collections.Generic.Comparer<long>
    // System.Collections.Generic.Comparer<object>
    // System.Collections.Generic.Comparer<uint>
    // System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.ComparisonComparer<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Collections.Generic.ComparisonComparer<Unity.Mathematics.float3>
    // System.Collections.Generic.ComparisonComparer<int>
    // System.Collections.Generic.ComparisonComparer<long>
    // System.Collections.Generic.ComparisonComparer<object>
    // System.Collections.Generic.ComparisonComparer<uint>
    // System.Collections.Generic.Dictionary.Enumerator<byte,object>
    // System.Collections.Generic.Dictionary.Enumerator<int,ET.RpcInfo>
    // System.Collections.Generic.Dictionary.Enumerator<int,long>
    // System.Collections.Generic.Dictionary.Enumerator<int,object>
    // System.Collections.Generic.Dictionary.Enumerator<long,object>
    // System.Collections.Generic.Dictionary.Enumerator<object,int>
    // System.Collections.Generic.Dictionary.Enumerator<object,long>
    // System.Collections.Generic.Dictionary.Enumerator<object,object>
    // System.Collections.Generic.Dictionary.Enumerator<short,object>
    // System.Collections.Generic.Dictionary.Enumerator<ushort,object>
    // System.Collections.Generic.Dictionary.KeyCollection.Enumerator<byte,object>
    // System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,ET.RpcInfo>
    // System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,long>
    // System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
    // System.Collections.Generic.Dictionary.KeyCollection.Enumerator<long,object>
    // System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,int>
    // System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,long>
    // System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
    // System.Collections.Generic.Dictionary.KeyCollection.Enumerator<short,object>
    // System.Collections.Generic.Dictionary.KeyCollection.Enumerator<ushort,object>
    // System.Collections.Generic.Dictionary.KeyCollection<byte,object>
    // System.Collections.Generic.Dictionary.KeyCollection<int,ET.RpcInfo>
    // System.Collections.Generic.Dictionary.KeyCollection<int,long>
    // System.Collections.Generic.Dictionary.KeyCollection<int,object>
    // System.Collections.Generic.Dictionary.KeyCollection<long,object>
    // System.Collections.Generic.Dictionary.KeyCollection<object,int>
    // System.Collections.Generic.Dictionary.KeyCollection<object,long>
    // System.Collections.Generic.Dictionary.KeyCollection<object,object>
    // System.Collections.Generic.Dictionary.KeyCollection<short,object>
    // System.Collections.Generic.Dictionary.KeyCollection<ushort,object>
    // System.Collections.Generic.Dictionary.ValueCollection.Enumerator<byte,object>
    // System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,ET.RpcInfo>
    // System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,long>
    // System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
    // System.Collections.Generic.Dictionary.ValueCollection.Enumerator<long,object>
    // System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,int>
    // System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,long>
    // System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
    // System.Collections.Generic.Dictionary.ValueCollection.Enumerator<short,object>
    // System.Collections.Generic.Dictionary.ValueCollection.Enumerator<ushort,object>
    // System.Collections.Generic.Dictionary.ValueCollection<byte,object>
    // System.Collections.Generic.Dictionary.ValueCollection<int,ET.RpcInfo>
    // System.Collections.Generic.Dictionary.ValueCollection<int,long>
    // System.Collections.Generic.Dictionary.ValueCollection<int,object>
    // System.Collections.Generic.Dictionary.ValueCollection<long,object>
    // System.Collections.Generic.Dictionary.ValueCollection<object,int>
    // System.Collections.Generic.Dictionary.ValueCollection<object,long>
    // System.Collections.Generic.Dictionary.ValueCollection<object,object>
    // System.Collections.Generic.Dictionary.ValueCollection<short,object>
    // System.Collections.Generic.Dictionary.ValueCollection<ushort,object>
    // System.Collections.Generic.Dictionary<byte,object>
    // System.Collections.Generic.Dictionary<int,ET.RpcInfo>
    // System.Collections.Generic.Dictionary<int,long>
    // System.Collections.Generic.Dictionary<int,object>
    // System.Collections.Generic.Dictionary<long,object>
    // System.Collections.Generic.Dictionary<object,int>
    // System.Collections.Generic.Dictionary<object,long>
    // System.Collections.Generic.Dictionary<object,object>
    // System.Collections.Generic.Dictionary<short,object>
    // System.Collections.Generic.Dictionary<ushort,object>
    // System.Collections.Generic.EqualityComparer<ET.RpcInfo>
    // System.Collections.Generic.EqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.EqualityComparer<byte>
    // System.Collections.Generic.EqualityComparer<int>
    // System.Collections.Generic.EqualityComparer<long>
    // System.Collections.Generic.EqualityComparer<object>
    // System.Collections.Generic.EqualityComparer<short>
    // System.Collections.Generic.EqualityComparer<uint>
    // System.Collections.Generic.EqualityComparer<ushort>
    // System.Collections.Generic.HashSet.Enumerator<object>
    // System.Collections.Generic.HashSet.Enumerator<ushort>
    // System.Collections.Generic.HashSet<object>
    // System.Collections.Generic.HashSet<ushort>
    // System.Collections.Generic.HashSetEqualityComparer<object>
    // System.Collections.Generic.HashSetEqualityComparer<ushort>
    // System.Collections.Generic.ICollection<ET.RpcInfo>
    // System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<byte,object>>
    // System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
    // System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,long>>
    // System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<long,object>>
    // System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,long>>
    // System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
    // System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<short,object>>
    // System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<ushort,object>>
    // System.Collections.Generic.ICollection<Unity.Mathematics.float3>
    // System.Collections.Generic.ICollection<int>
    // System.Collections.Generic.ICollection<long>
    // System.Collections.Generic.ICollection<object>
    // System.Collections.Generic.ICollection<ushort>
    // System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Collections.Generic.IComparer<Unity.Mathematics.float3>
    // System.Collections.Generic.IComparer<int>
    // System.Collections.Generic.IComparer<long>
    // System.Collections.Generic.IComparer<object>
    // System.Collections.Generic.IEnumerable<ET.RpcInfo>
    // System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<byte,object>>
    // System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
    // System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,long>>
    // System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<long,object>>
    // System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,long>>
    // System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
    // System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<short,object>>
    // System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<ushort,object>>
    // System.Collections.Generic.IEnumerable<Unity.Mathematics.float3>
    // System.Collections.Generic.IEnumerable<int>
    // System.Collections.Generic.IEnumerable<long>
    // System.Collections.Generic.IEnumerable<object>
    // System.Collections.Generic.IEnumerable<ushort>
    // System.Collections.Generic.IEnumerator<ET.RpcInfo>
    // System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<byte,object>>
    // System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>>
    // System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,long>>
    // System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<long,object>>
    // System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,long>>
    // System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
    // System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<short,object>>
    // System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ushort,object>>
    // System.Collections.Generic.IEnumerator<Unity.Mathematics.float3>
    // System.Collections.Generic.IEnumerator<int>
    // System.Collections.Generic.IEnumerator<long>
    // System.Collections.Generic.IEnumerator<object>
    // System.Collections.Generic.IEnumerator<ushort>
    // System.Collections.Generic.IEqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.IEqualityComparer<byte>
    // System.Collections.Generic.IEqualityComparer<int>
    // System.Collections.Generic.IEqualityComparer<long>
    // System.Collections.Generic.IEqualityComparer<object>
    // System.Collections.Generic.IEqualityComparer<short>
    // System.Collections.Generic.IEqualityComparer<ushort>
    // System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Collections.Generic.IList<Unity.Mathematics.float3>
    // System.Collections.Generic.IList<int>
    // System.Collections.Generic.IList<long>
    // System.Collections.Generic.IList<object>
    // System.Collections.Generic.KeyValuePair<byte,object>
    // System.Collections.Generic.KeyValuePair<int,ET.RpcInfo>
    // System.Collections.Generic.KeyValuePair<int,long>
    // System.Collections.Generic.KeyValuePair<int,object>
    // System.Collections.Generic.KeyValuePair<long,object>
    // System.Collections.Generic.KeyValuePair<object,int>
    // System.Collections.Generic.KeyValuePair<object,long>
    // System.Collections.Generic.KeyValuePair<object,object>
    // System.Collections.Generic.KeyValuePair<short,object>
    // System.Collections.Generic.KeyValuePair<ushort,object>
    // System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Collections.Generic.List.Enumerator<Unity.Mathematics.float3>
    // System.Collections.Generic.List.Enumerator<int>
    // System.Collections.Generic.List.Enumerator<long>
    // System.Collections.Generic.List.Enumerator<object>
    // System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Collections.Generic.List<Unity.Mathematics.float3>
    // System.Collections.Generic.List<int>
    // System.Collections.Generic.List<long>
    // System.Collections.Generic.List<object>
    // System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Collections.Generic.ObjectComparer<Unity.Mathematics.float3>
    // System.Collections.Generic.ObjectComparer<int>
    // System.Collections.Generic.ObjectComparer<long>
    // System.Collections.Generic.ObjectComparer<object>
    // System.Collections.Generic.ObjectComparer<uint>
    // System.Collections.Generic.ObjectEqualityComparer<ET.RpcInfo>
    // System.Collections.Generic.ObjectEqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.ObjectEqualityComparer<byte>
    // System.Collections.Generic.ObjectEqualityComparer<int>
    // System.Collections.Generic.ObjectEqualityComparer<long>
    // System.Collections.Generic.ObjectEqualityComparer<object>
    // System.Collections.Generic.ObjectEqualityComparer<short>
    // System.Collections.Generic.ObjectEqualityComparer<uint>
    // System.Collections.Generic.ObjectEqualityComparer<ushort>
    // System.Collections.Generic.Queue.Enumerator<int>
    // System.Collections.Generic.Queue.Enumerator<object>
    // System.Collections.Generic.Queue<int>
    // System.Collections.Generic.Queue<object>
    // System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_0<int,object>
    // System.Collections.Generic.SortedDictionary.<>c__DisplayClass34_1<int,object>
    // System.Collections.Generic.SortedDictionary.Enumerator<int,object>
    // System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass5_0<int,object>
    // System.Collections.Generic.SortedDictionary.KeyCollection.<>c__DisplayClass6_0<int,object>
    // System.Collections.Generic.SortedDictionary.KeyCollection.Enumerator<int,object>
    // System.Collections.Generic.SortedDictionary.KeyCollection<int,object>
    // System.Collections.Generic.SortedDictionary.KeyValuePairComparer<int,object>
    // System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass5_0<int,object>
    // System.Collections.Generic.SortedDictionary.ValueCollection.<>c__DisplayClass6_0<int,object>
    // System.Collections.Generic.SortedDictionary.ValueCollection.Enumerator<int,object>
    // System.Collections.Generic.SortedDictionary.ValueCollection<int,object>
    // System.Collections.Generic.SortedDictionary<int,object>
    // System.Collections.Generic.SortedSet.<>c__DisplayClass52_0<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.SortedSet.<>c__DisplayClass53_0<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.SortedSet.<>c__DisplayClass85_0<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.SortedSet.<Reverse>d__94<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.SortedSet.Enumerator<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.SortedSet.Node<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.SortedSet.TreeSubSet.<>c__DisplayClass9_0<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.SortedSet.TreeSubSet<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.SortedSet<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.SortedSetEqualityComparer<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.Stack.Enumerator<object>
    // System.Collections.Generic.Stack<object>
    // System.Collections.Generic.TreeSet<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.Generic.TreeWalkPredicate<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Collections.ObjectModel.ReadOnlyCollection<Unity.Mathematics.float3>
    // System.Collections.ObjectModel.ReadOnlyCollection<int>
    // System.Collections.ObjectModel.ReadOnlyCollection<long>
    // System.Collections.ObjectModel.ReadOnlyCollection<object>
    // System.Comparison<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Comparison<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Comparison<Unity.Mathematics.float3>
    // System.Comparison<int>
    // System.Comparison<long>
    // System.Comparison<object>
    // System.Comparison<uint>
    // System.Func<System.Collections.Generic.KeyValuePair<object,int>,byte>
    // System.Func<System.Collections.Generic.KeyValuePair<object,int>,int>
    // System.Func<System.Collections.Generic.KeyValuePair<object,int>,object>
    // System.Func<System.ValueTuple<uint,uint>>
    // System.Func<int,object>
    // System.Func<object,System.ValueTuple<uint,uint>>
    // System.Func<object,byte>
    // System.Func<object,object,System.ValueTuple<uint,uint>>
    // System.Func<object,object,object>
    // System.Func<object,object>
    // System.Func<object>
    // System.Linq.Buffer<ET.RpcInfo>
    // System.Linq.Buffer<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Linq.Buffer<object>
    // System.Linq.Enumerable.Iterator<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Linq.Enumerable.Iterator<object>
    // System.Linq.Enumerable.WhereArrayIterator<object>
    // System.Linq.Enumerable.WhereEnumerableIterator<object>
    // System.Linq.Enumerable.WhereListIterator<object>
    // System.Linq.Enumerable.WhereSelectArrayIterator<System.Collections.Generic.KeyValuePair<object,int>,object>
    // System.Linq.Enumerable.WhereSelectEnumerableIterator<System.Collections.Generic.KeyValuePair<object,int>,object>
    // System.Linq.Enumerable.WhereSelectListIterator<System.Collections.Generic.KeyValuePair<object,int>,object>
    // System.Linq.EnumerableSorter<System.Collections.Generic.KeyValuePair<object,int>,int>
    // System.Linq.EnumerableSorter<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Linq.OrderedEnumerable.<GetEnumerator>d__1<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Linq.OrderedEnumerable<System.Collections.Generic.KeyValuePair<object,int>,int>
    // System.Linq.OrderedEnumerable<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Predicate<System.Collections.Generic.KeyValuePair<int,object>>
    // System.Predicate<System.Collections.Generic.KeyValuePair<object,int>>
    // System.Predicate<Unity.Mathematics.float3>
    // System.Predicate<int>
    // System.Predicate<long>
    // System.Predicate<object>
    // System.Predicate<ushort>
    // System.Runtime.CompilerServices.ConditionalWeakTable.<>c<object,object>
    // System.Runtime.CompilerServices.ConditionalWeakTable.CreateValueCallback<object,object>
    // System.Runtime.CompilerServices.ConditionalWeakTable.Enumerator<object,object>
    // System.Runtime.CompilerServices.ConditionalWeakTable<object,object>
    // System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<System.ValueTuple<uint,uint>>
    // System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>
    // System.Runtime.CompilerServices.ConfiguredTaskAwaitable<System.ValueTuple<uint,uint>>
    // System.Runtime.CompilerServices.ConfiguredTaskAwaitable<object>
    // System.Runtime.CompilerServices.TaskAwaiter<System.ValueTuple<uint,uint>>
    // System.Runtime.CompilerServices.TaskAwaiter<object>
    // System.Threading.Tasks.ContinuationTaskFromResultTask<System.ValueTuple<uint,uint>>
    // System.Threading.Tasks.ContinuationTaskFromResultTask<object>
    // System.Threading.Tasks.Task<System.ValueTuple<uint,uint>>
    // System.Threading.Tasks.Task<object>
    // System.Threading.Tasks.TaskFactory.<>c<System.ValueTuple<uint,uint>>
    // System.Threading.Tasks.TaskFactory.<>c<object>
    // System.Threading.Tasks.TaskFactory.<>c__DisplayClass32_0<System.ValueTuple<uint,uint>>
    // System.Threading.Tasks.TaskFactory.<>c__DisplayClass32_0<object>
    // System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<System.ValueTuple<uint,uint>>
    // System.Threading.Tasks.TaskFactory.<>c__DisplayClass35_0<object>
    // System.Threading.Tasks.TaskFactory<System.ValueTuple<uint,uint>>
    // System.Threading.Tasks.TaskFactory<object>
    // System.ValueTuple<int,int>
    // System.ValueTuple<int,object>
    // System.ValueTuple<uint,object>
    // System.ValueTuple<uint,uint>
    // UnityEngine.Events.InvokableCall<byte>
    // UnityEngine.Events.InvokableCall<int>
    // UnityEngine.Events.InvokableCall<object>
    // UnityEngine.Events.UnityAction<byte>
    // UnityEngine.Events.UnityAction<int>
    // UnityEngine.Events.UnityAction<object,UnityEngine.Vector3>
    // UnityEngine.Events.UnityAction<object>
    // UnityEngine.Events.UnityEvent<byte>
    // UnityEngine.Events.UnityEvent<int>
    // UnityEngine.Events.UnityEvent<object>
    // }}

    public void RefMethods()
    {
        // object Cinemachine.CinemachineVirtualCamera.AddCinemachineComponent<object>()
        // object DG.Tweening.TweenSettingsExtensions.SetEase<object>(object,DG.Tweening.Ease)
        // System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<ET.ETTaskCompleted,object>(ET.ETTaskCompleted&,object&)
        // System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<System.ValueTuple<uint,uint>>,object>(System.Runtime.CompilerServices.TaskAwaiter<System.ValueTuple<uint,uint>>&,object&)
        // System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,object>(System.Runtime.CompilerServices.TaskAwaiter<object>&,object&)
        // System.Void ET.ETAsyncTaskMethodBuilder.AwaitUnsafeOnCompleted<object,object>(object&,object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<byte>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<int>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<System.Runtime.CompilerServices.TaskAwaiter<object>,object>(System.Runtime.CompilerServices.TaskAwaiter<object>&,object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<object>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<uint>.AwaitUnsafeOnCompleted<object,object>(object&,object&)
        // System.Void ET.ETAsyncTaskMethodBuilder.Start<object>(object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_CreateMyUnit>.Start<object>(object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_SceneChangeFinish>.Start<object>(object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_UnitAddGOComponent>.Start<object>(object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<ET.Client.Wait_UnitStop>.Start<object>(object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<System.ValueTuple<uint,object>>.Start<object>(object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<byte>.Start<object>(object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<int>.Start<object>(object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<object>.Start<object>(object&)
        // System.Void ET.ETAsyncTaskMethodBuilder<uint>.Start<object>(object&)
        // object ET.Entity.AddChild<object,int>(int,bool)
        // object ET.Entity.AddChild<object,object,object>(object,object,bool)
        // object ET.Entity.AddChild<object,object>(object,bool)
        // object ET.Entity.AddChild<object>(bool)
        // object ET.Entity.AddChildWithId<object,int>(long,int,bool)
        // object ET.Entity.AddChildWithId<object>(long,bool)
        // object ET.Entity.AddComponent<object,int>(int,bool)
        // object ET.Entity.AddComponent<object,object,int>(object,int,bool)
        // object ET.Entity.AddComponent<object,object>(object,bool)
        // object ET.Entity.AddComponent<object>(bool)
        // object ET.Entity.GetChild<object>(long)
        // object ET.Entity.GetComponent<object>()
        // object ET.Entity.GetParent<object>()
        // System.Void ET.Entity.RemoveComponent<object>()
        // System.Void ET.EventSystem.Awake<int>(ET.Entity,int)
        // System.Void ET.EventSystem.Awake<object,int>(ET.Entity,object,int)
        // System.Void ET.EventSystem.Awake<object,object>(ET.Entity,object,object)
        // System.Void ET.EventSystem.Awake<object>(ET.Entity,object)
        // object ET.EventSystem.Invoke<ET.NavmeshComponent.RecastFileLoader,object>(ET.NavmeshComponent.RecastFileLoader)
        // object ET.EventSystem.Invoke<ET.NavmeshComponent.RecastFileLoader,object>(int,ET.NavmeshComponent.RecastFileLoader)
        // System.Void ET.EventSystem.Publish<ET.Client.EventType.PrivateChat>(ET.Scene,ET.Client.EventType.PrivateChat,bool)
        // System.Void ET.EventSystem.Publish<ET.Client.EventType.SelectTask>(ET.Scene,ET.Client.EventType.SelectTask,bool)
        // System.Void ET.EventSystem.Publish<ET.Client.EventType.UpdateTaskInfo>(ET.Scene,ET.Client.EventType.UpdateTaskInfo,bool)
        // System.Void ET.EventSystem.Publish<ET.Client.NetClientComponentOnRead>(ET.Scene,ET.Client.NetClientComponentOnRead,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.AfterCreateCurrentScene>(ET.Scene,ET.EventType.AfterCreateCurrentScene,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.AfterUnitCreate>(ET.Scene,ET.EventType.AfterUnitCreate,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.ChangePosition>(ET.Scene,ET.EventType.ChangePosition,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.ChangeRotation>(ET.Scene,ET.EventType.ChangeRotation,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.EnterMapFinish>(ET.Scene,ET.EventType.EnterMapFinish,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.MoveStart>(ET.Scene,ET.EventType.MoveStart,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.MoveStop>(ET.Scene,ET.EventType.MoveStop,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.NumbericChange>(ET.Scene,ET.EventType.NumbericChange,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.SceneChangeFinish>(ET.Scene,ET.EventType.SceneChangeFinish,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.SceneChangeStart>(ET.Scene,ET.EventType.SceneChangeStart,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.SelectRole>(ET.Scene,ET.EventType.SelectRole,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.SelectRoleClass>(ET.Scene,ET.EventType.SelectRoleClass,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.SelectShopItem>(ET.Scene,ET.EventType.SelectShopItem,bool)
        // System.Void ET.EventSystem.Publish<ET.EventType.ShowCreateRolePanel>(ET.Scene,ET.EventType.ShowCreateRolePanel,bool)
        // ET.ETTask ET.EventSystem.PublishAsync<ET.Client.EventType.ChangeEquipItem>(ET.Scene,ET.Client.EventType.ChangeEquipItem,bool)
        // ET.ETTask ET.EventSystem.PublishAsync<ET.Client.EventType.FriendUpdate>(ET.Scene,ET.Client.EventType.FriendUpdate,bool)
        // ET.ETTask ET.EventSystem.PublishAsync<ET.Client.EventType.UpdateChat>(ET.Scene,ET.Client.EventType.UpdateChat,bool)
        // ET.ETTask ET.EventSystem.PublishAsync<ET.EventType.AfterCreateClientScene>(ET.Scene,ET.EventType.AfterCreateClientScene,bool)
        // ET.ETTask ET.EventSystem.PublishAsync<ET.EventType.AppStartInitFinish>(ET.Scene,ET.EventType.AppStartInitFinish,bool)
        // ET.ETTask ET.EventSystem.PublishAsync<ET.EventType.EntryEvent1>(ET.Scene,ET.EventType.EntryEvent1,bool)
        // ET.ETTask ET.EventSystem.PublishAsync<ET.EventType.EntryEvent2>(ET.Scene,ET.EventType.EntryEvent2,bool)
        // ET.ETTask ET.EventSystem.PublishAsync<ET.EventType.EntryEvent3>(ET.Scene,ET.EventType.EntryEvent3,bool)
        // object ET.Game.AddSingleton<object>()
        // object ET.JsonHelper.FromJson<object>(string)
        // string ET.Luban.StringUtil.CollectionToString<int,long>(System.Collections.Generic.IDictionary<int,long>)
        // string ET.Luban.StringUtil.CollectionToString<int>(System.Collections.Generic.IEnumerable<int>)
        // string ET.Luban.StringUtil.CollectionToString<object>(System.Collections.Generic.IEnumerable<object>)
        // object ET.MongoHelper.FromJson<object>(string)
        // System.Void ET.RandomHelper.BreakRank<object>(System.Collections.Generic.List<object>)
        // string ET.StringHelper.ArrayToString<float>(float[])
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.Client.EventType.PrivateChat>(ET.Client.EventType.PrivateChat,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.Client.EventType.PrivateChat>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.Client.EventType.SelectTask>(ET.Client.EventType.SelectTask,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.Client.EventType.SelectTask>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.Client.EventType.UpdateTaskInfo>(ET.Client.EventType.UpdateTaskInfo,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.Client.EventType.UpdateTaskInfo>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.Client.NetClientComponentOnRead>(ET.Client.NetClientComponentOnRead,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.Client.NetClientComponentOnRead>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.AfterCreateCurrentScene>(ET.EventType.AfterCreateCurrentScene,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.AfterCreateCurrentScene>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.AfterUnitCreate>(ET.EventType.AfterUnitCreate,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.AfterUnitCreate>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.ChangePosition>(ET.EventType.ChangePosition,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.ChangePosition>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.ChangeRotation>(ET.EventType.ChangeRotation,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.ChangeRotation>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.EnterMapFinish>(ET.EventType.EnterMapFinish,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.EnterMapFinish>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.MoveStart>(ET.EventType.MoveStart,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.MoveStart>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.MoveStop>(ET.EventType.MoveStop,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.MoveStop>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.NumbericChange>(ET.EventType.NumbericChange,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.NumbericChange>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.SceneChangeFinish>(ET.EventType.SceneChangeFinish,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.SceneChangeFinish>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.SceneChangeStart>(ET.EventType.SceneChangeStart,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.SceneChangeStart>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.SelectRole>(ET.EventType.SelectRole,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.SelectRole>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.SelectRoleClass>(ET.EventType.SelectRoleClass,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.SelectRoleClass>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.SelectShopItem>(ET.EventType.SelectShopItem,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.SelectShopItem>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // string MongoDB.Bson.BsonExtensionMethods.ToJson<ET.EventType.ShowCreateRolePanel>(ET.EventType.ShowCreateRolePanel,MongoDB.Bson.IO.JsonWriterSettings,MongoDB.Bson.Serialization.IBsonSerializer<ET.EventType.ShowCreateRolePanel>,System.Action<MongoDB.Bson.Serialization.BsonSerializationContext.Builder>,MongoDB.Bson.Serialization.BsonSerializationArgs)
        // object MongoDB.Bson.Serialization.BsonSerializer.Deserialize<object>(MongoDB.Bson.IO.IBsonReader,System.Action<MongoDB.Bson.Serialization.BsonDeserializationContext.Builder>)
        // object MongoDB.Bson.Serialization.BsonSerializer.Deserialize<object>(string,System.Action<MongoDB.Bson.Serialization.BsonDeserializationContext.Builder>)
        // MongoDB.Bson.Serialization.IBsonSerializer<object> MongoDB.Bson.Serialization.BsonSerializer.LookupSerializer<object>()
        // object MongoDB.Bson.Serialization.IBsonSerializerExtensions.Deserialize<object>(MongoDB.Bson.Serialization.IBsonSerializer<object>,MongoDB.Bson.Serialization.BsonDeserializationContext)
        // object ReferenceCollector.Get<object>(string)
        // object System.Activator.CreateInstance<object>()
        // object[] System.Array.Empty<object>()
        // bool System.Linq.Enumerable.Any<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
        // object System.Linq.Enumerable.ElementAt<object>(System.Collections.Generic.IEnumerable<object>,int)
        // object System.Linq.Enumerable.FirstOrDefault<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
        // System.Linq.IOrderedEnumerable<System.Collections.Generic.KeyValuePair<object,int>> System.Linq.Enumerable.OrderBy<System.Collections.Generic.KeyValuePair<object,int>,int>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>,System.Func<System.Collections.Generic.KeyValuePair<object,int>,int>)
        // System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Select<System.Collections.Generic.KeyValuePair<object,int>,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,int>>,System.Func<System.Collections.Generic.KeyValuePair<object,int>,object>)
        // ET.RpcInfo[] System.Linq.Enumerable.ToArray<ET.RpcInfo>(System.Collections.Generic.IEnumerable<ET.RpcInfo>)
        // object[] System.Linq.Enumerable.ToArray<object>(System.Collections.Generic.IEnumerable<object>)
        // System.Collections.Generic.List<object> System.Linq.Enumerable.ToList<object>(System.Collections.Generic.IEnumerable<object>)
        // System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Where<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
        // System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Iterator<System.Collections.Generic.KeyValuePair<object,int>>.Select<object>(System.Func<System.Collections.Generic.KeyValuePair<object,int>,object>)
        // System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.AwaitUnsafeOnCompleted<object,object>(object&,object&)
        // System.Void System.Runtime.CompilerServices.AsyncVoidMethodBuilder.Start<object>(object&)
        // System.Threading.Tasks.Task<object> System.Threading.Tasks.TaskFactory.StartNew<object>(System.Func<object>,System.Threading.CancellationToken)
        // object UnityEngine.Component.GetComponent<object>()
        // object UnityEngine.Component.GetComponentInChildren<object>()
        // object UnityEngine.Component.GetComponentInParent<object>()
        // object[] UnityEngine.Component.GetComponents<object>()
        // object[] UnityEngine.Component.GetComponentsInChildren<object>()
        // object[] UnityEngine.Component.GetComponentsInChildren<object>(bool)
        // object UnityEngine.GameObject.AddComponent<object>()
        // object UnityEngine.GameObject.GetComponent<object>()
        // object UnityEngine.GameObject.GetComponentInChildren<object>()
        // object UnityEngine.GameObject.GetComponentInChildren<object>(bool)
        // object[] UnityEngine.GameObject.GetComponents<object>()
        // object[] UnityEngine.GameObject.GetComponentsInChildren<object>(bool)
        // object UnityEngine.Object.Instantiate<object>(object)
        // object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform)
        // object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform,bool)
        // object UnityEngine.Resources.Load<object>(string)
        // string string.Join<int>(string,System.Collections.Generic.IEnumerable<int>)
        // string string.Join<object>(string,System.Collections.Generic.IEnumerable<object>)
        // string string.JoinCore<int>(System.Char*,int,System.Collections.Generic.IEnumerable<int>)
        // string string.JoinCore<object>(System.Char*,int,System.Collections.Generic.IEnumerable<object>)
    }
}