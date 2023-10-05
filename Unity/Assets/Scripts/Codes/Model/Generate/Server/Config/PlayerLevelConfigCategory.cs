
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
public partial class PlayerLevelConfigCategory: ConfigSingleton<PlayerLevelConfigCategory>
{
    private readonly Dictionary<int, PlayerLevelConfig> _dataMap;
    private readonly List<PlayerLevelConfig> _dataList;


    public PlayerLevelConfigCategory(ByteBuf _buf)
    {
        _dataMap = new();
        _dataList = new();

        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            PlayerLevelConfig _v;
            _v = PlayerLevelConfig.DeserializePlayerLevelConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public bool Contain(int id)
    {
        return _dataMap.ContainsKey(id);
    }

    public Dictionary<int, PlayerLevelConfig> GetAll()
    {
        return _dataMap;
    }

    public List<PlayerLevelConfig> DataList => _dataList;

    public PlayerLevelConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public PlayerLevelConfig Get(int key) => _dataMap[key];
    public PlayerLevelConfig GetOne(int key)
    {
        if(this._dataMap is not { Count: > 0 })
        {
            return null;
        }
        return _dataMap.Values.GetEnumerator().Current;
    }

    public PlayerLevelConfig this[int key] => _dataMap[key];

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

    public override string ConfigName() => nameof (PlayerLevelConfig);
}
}