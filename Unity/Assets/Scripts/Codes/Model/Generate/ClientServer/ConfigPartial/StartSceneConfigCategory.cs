using System.Collections.Generic;

namespace ET
{
    public partial class StartSceneConfigCategory
    {
        public StartSceneConfig BenchmarkServer;
        public Dictionary<long, Dictionary<string, StartSceneConfig>> ClientScenesByName = new();

        public MultiMap<int, StartSceneConfig> Gates = new();
        public StartSceneConfig LocationConfig;

        public StartSceneConfig LoginCenterConfig;
        public MultiMap<int, StartSceneConfig> ProcessScenes = new();
        public Dictionary<int, StartSceneConfig> Realms = new();
        public List<StartSceneConfig> Robots = new();
        public List<StartSceneConfig> Routers = new();

        public Dictionary<int, StartSceneConfig> UnitCaches = new();

        /// <summary>
        ///     获取Unit对应的缓存服务器配置
        /// </summary>
        /// <param name="unitId">Unit对象的Id</param>
        /// <returns></returns>
        public StartSceneConfig GetUnitCacheConfig(long unitId) => this.UnitCaches[UnitIdStruct.GetUnitZone(unitId)];

        public List<StartSceneConfig> GetByProcess(int process) => this.ProcessScenes[process];

        public StartSceneConfig GetBySceneName(int zone, string name) => this.ClientScenesByName[zone][name];

        protected override void PostResolve()
        {
            foreach (StartSceneConfig startSceneConfig in this.GetAll().Values)
            {
                this.ProcessScenes.Add(startSceneConfig.Process, startSceneConfig);

                if (!this.ClientScenesByName.ContainsKey(startSceneConfig.Zone))
                {
                    this.ClientScenesByName.Add(startSceneConfig.Zone, new());
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
}