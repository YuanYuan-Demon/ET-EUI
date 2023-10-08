using System.Net;

namespace ET
{
    public partial class StartSceneConfig
    {
        // 内网地址外网端口，通过防火墙映射端口过来
        private IPEndPoint innerIPOutPort;
        public long InstanceId;

        private IPEndPoint outerIPPort;

        public SceneType Type;

        public StartProcessConfig StartProcessConfig => StartProcessConfigCategory.Instance.Get(this.Process);

        public StartZoneConfig StartZoneConfig => StartZoneConfigCategory.Instance.Get(this.Zone);

        public IPEndPoint InnerIPOutPort
        {
            get
            {
                if (this.innerIPOutPort == null)
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

        protected override void PostResolve()
        {
            this.Type = EnumHelper.FromString<SceneType>(this.SceneType);
            InstanceIdStruct instanceIdStruct = new(this.Process, (uint)this.Id);
            this.InstanceId = instanceIdStruct.ToLong();
        }
    }
}