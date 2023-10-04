
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using ET.Luban;


namespace ET
{
[Config]
public partial class ServerInfoConfigCategory: ConfigSingleton<ServerInfoConfigCategory>
{
    private readonly Dictionary<int, ServerInfoConfig> _dataMap;
    private readonly List<ServerInfoConfig> _dataList;


    public ServerInfoConfigCategory(ByteBuf _buf)
    {
        _dataMap = new();
        _dataList = new();

        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            ServerInfoConfig _v;
            _v = ServerInfoConfig.DeserializeServerInfoConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public bool Contain(int id)
    {
        return _dataMap.ContainsKey(id);
    }

    public Dictionary<int, ServerInfoConfig> GetAll()
    {
        return _dataMap;
    }

    public List<ServerInfoConfig> DataList => _dataList;

    public ServerInfoConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public ServerInfoConfig Get(int key) => _dataMap[key];
    public ServerInfoConfig GetOne(int key)
    {
        if(this._dataMap is not { Count: > 0 })
        {
            return null;
        }
        return _dataMap.Values.GetEnumerator().Current;
    }

    public ServerInfoConfig this[int key] => _dataMap[key];

    public override void Resolve(Dictionary<Type, IConfigSingleton> tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(tables);
        }
        PostResolve();
    }

    public override void TrimExcess()
    {
        _dataMap.TrimExcess();
        _dataList.TrimExcess();
    }

    public override string ConfigName() => nameof (ServerInfoConfig);
}
}
