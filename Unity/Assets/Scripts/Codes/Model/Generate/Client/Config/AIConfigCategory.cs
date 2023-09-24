
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


namespace ET.Client
{
[Config]
public partial class AIConfigCategory: ConfigSingleton<AIConfigCategory>
{
    private readonly Dictionary<int, AIConfig> _dataMap;
    private readonly List<AIConfig> _dataList;

    public AIConfigCategory(ByteBuf _buf)
    {
        _dataMap = new();
        _dataList = new();

        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            AIConfig _v;
            _v = AIConfig.DeserializeAIConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public bool Contain(int id)
    {
        return _dataMap.ContainsKey(id);
    }

    public Dictionary<int, AIConfig> GetAll()
    {
        return _dataMap;
    }

    public List<AIConfig> DataList => _dataList;

    public AIConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public AIConfig Get(int key) => _dataMap[key];
    public AIConfig GetOne(int key)
    {
        if(this._dataMap is not { Count: > 0 })
        {
            return null;
        }
        return _dataMap.Values.GetEnumerator().Current;
    }

    public AIConfig this[int key] => _dataMap[key];

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

    public override string ConfigName() => nameof (AIConfig);
}
}
