using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

namespace ET
{
    public partial class StartSceneConfigCategory
    {
        public MultiMap<int, StartSceneConfig> Gates = new();
        public Dictionary<int, StartSceneConfig> Realms = new();

        public MultiMap<int, StartSceneConfig> ProcessScenes = new();
        public Dictionary<int, StartSceneConfig> UnitCaches = new();

        public Dictionary<long, Dictionary<string, StartSceneConfig>> ClientScenesByName = new();

        public StartSceneConfig LocationConfig;
        public StartSceneConfig LoginCenterConfig;

        public List<StartSceneConfig> Routers = new();

        public List<StartSceneConfig> Robots = new();

        public StartSceneConfig BenchmarkServer;

        public List<StartSceneConfig> GetByProcess(int process)
        {
            return this.ProcessScenes[process];
        }

        public StartSceneConfig GetBySceneName(int zone, string name)
        {
            return this.ClientScenesByName[zone][name];
        }

        /// <summary>
        /// 获取Unit对应的缓存服务器配置
        /// </summary>
        /// <param name="unitId">Unit对象的Id</param>
        /// <returns></returns>
        public StartSceneConfig GetUnitCacheConfig(long unitId)
        {
            return UnitCaches[UnitIdStruct.GetUnitZone(unitId)];
        }

        public override void AfterEndInit()
        {
            foreach (StartSceneConfig startSceneConfig in this.GetAll().Values)
            {
                this.ProcessScenes.Add(startSceneConfig.Process, startSceneConfig);

                if (!this.ClientScenesByName.ContainsKey(startSceneConfig.Zone))
                {
                    this.ClientScenesByName.Add(startSceneConfig.Zone, new Dictionary<string, StartSceneConfig>());
                }
                this.ClientScenesByName[startSceneConfig.Zone].Add(startSceneConfig.Name, startSceneConfig);

                switch (startSceneConfig.Type)
                {
                    case SceneType.Realm:
                        this.Realms.Add(startSceneConfig.Zone, startSceneConfig);
                        break;

                    case SceneType.Gate:
                        this.Gates.Add(startSceneConfig.Zone, startSceneConfig);
                        break;

                    case SceneType.Location:
                        this.LocationConfig = startSceneConfig;
                        break;

                    case SceneType.Robot:
                        this.Robots.Add(startSceneConfig);
                        break;

                    case SceneType.Router:
                        this.Routers.Add(startSceneConfig);
                        break;

                    case SceneType.BenchmarkServer:
                        this.BenchmarkServer = startSceneConfig;
                        break;

                    case SceneType.LoginCenter:
                        this.LoginCenterConfig = startSceneConfig;
                        break;

                    case SceneType.UnitCache:
                        this.UnitCaches[startSceneConfig.Zone] = startSceneConfig;
                        break;
                }
            }
        }
    }

    public partial class StartSceneConfig : ISupportInitialize
    {
        public long InstanceId;

        public SceneType Type;

        // 内网地址外网端口，通过防火墙映射端口过来
        private IPEndPoint innerIPOutPort;

        private IPEndPoint outerIPPort;

        public StartProcessConfig StartProcessConfig
        {
            get
            {
                return StartProcessConfigCategory.Instance.Get(this.Process);
            }
        }

        public StartZoneConfig StartZoneConfig
        {
            get
            {
                return StartZoneConfigCategory.Instance.Get(this.Zone);
            }
        }

        public IPEndPoint InnerIPOutPort
        {
            get
            {
                if (innerIPOutPort == null)
                {
                    this.innerIPOutPort = NetworkHelper.ToIPEndPoint($"{this.StartProcessConfig.InnerIP}:{this.OuterPort}");
                }

                return this.innerIPOutPort;
            }
        }

        // 外网地址外网端口
        public IPEndPoint OuterIPPort
        {
            get
            {
                if (this.outerIPPort == null)
                {
                    this.outerIPPort = NetworkHelper.ToIPEndPoint($"{this.StartProcessConfig.OuterIP}:{this.OuterPort}");
                }

                return this.outerIPPort;
            }
        }

        public override void AfterEndInit()
        {
            this.Type = EnumHelper.FromString<SceneType>(this.SceneType);
            InstanceIdStruct instanceIdStruct = new(this.Process, (uint)this.Id);
            this.InstanceId = instanceIdStruct.ToLong();
        }
    }
}