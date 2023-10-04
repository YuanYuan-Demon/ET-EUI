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
    public partial class StartZoneConfigCategory: ConfigSingleton<StartZoneConfigCategory>
    {
        private readonly List<StartZoneConfig> _dataList;
        private readonly Dictionary<int, StartZoneConfig> _dataMap;

        public StartZoneConfigCategory(ByteBuf _buf)
        {
            _dataMap = new();
            _dataList = new();

            for (int n = _buf.ReadSize(); n > 0; --n)
            {
                StartZoneConfig _v;
                _v = StartZoneConfig.DeserializeStartZoneConfig(_buf);
                _dataList.Add(_v);
                _dataMap.Add(_v.Id, _v);
            }

            PostInit();
        }

        public List<StartZoneConfig> DataList => _dataList;

        public StartZoneConfig this[int key] => _dataMap[key];

        public bool Contain(int id)
        {
            return _dataMap.ContainsKey(id);
        }

        public Dictionary<int, StartZoneConfig> GetAll()
        {
            return _dataMap;
        }

        public StartZoneConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v)? v : null;
        public StartZoneConfig Get(int key) => _dataMap[key];

        public StartZoneConfig GetOne(int key)
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

        public override string ConfigName() => nameof (StartZoneConfig);
    }
}