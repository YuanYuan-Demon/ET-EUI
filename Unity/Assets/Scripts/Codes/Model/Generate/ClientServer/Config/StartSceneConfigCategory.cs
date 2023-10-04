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
    public partial class StartSceneConfigCategory: ConfigSingleton<StartSceneConfigCategory>
    {
        private readonly List<StartSceneConfig> _dataList;
        private readonly Dictionary<int, StartSceneConfig> _dataMap;

        public StartSceneConfigCategory(ByteBuf _buf)
        {
            _dataMap = new();
            _dataList = new();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                StartSceneConfig _v;
                _v = StartSceneConfig.DeserializeStartSceneConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public List<StartSceneConfig> DataList => _dataList;

        public StartSceneConfig this[int key] => _dataMap[key];

        public bool Contain(int id)
        {
            return _dataMap.ContainsKey(id);
        }

        public Dictionary<int, StartSceneConfig> GetAll()
        {
            return _dataMap;
        }

        public StartSceneConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v)? v : null;
        public StartSceneConfig Get(int key) => _dataMap[key];

        public StartSceneConfig GetOne(int key)
        {
            if (this._dataMap is not { Count: > 0 })
            {
                return null;
            }

            return _dataMap.Values.GetEnumerator().Current;
        }

        public override void Resolve(Dictionary<Type, IConfigSingleton> tables)
        {
            foreach (var v in _dataList)
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

        public override string ConfigName() => nameof (StartSceneConfig);
    }
}