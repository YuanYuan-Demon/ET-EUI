using System;
using System.Collections.Generic;
using System.IO;
using ET.Luban;

namespace ET.Server
{
    [Invoke]
    public class GetAllConfigBytes: AInvokeHandler<ConfigComponent.GetAllConfigBytes, Dictionary<Type, ByteBuf>>
    {
        public override Dictionary<Type, ByteBuf> Handle(ConfigComponent.GetAllConfigBytes args)
        {
            var output = new Dictionary<Type, ByteBuf>();
            var startConfigs = new List<string>()
            {
                "StartMachineConfigCategory", "StartProcessConfigCategory", "StartSceneConfigCategory", "StartZoneConfigCategory",
            };
            var configTypes = EventSystem.Instance.GetTypes(typeof (ConfigAttribute));
            foreach (Type configType in configTypes)
            {
                string configFilePath;
                if (startConfigs.Contains(configType.Name))
                {
                    configFilePath = $"../Config/Bytes/s/{Options.Instance.StartConfig}/{configType.Name}.bytes";
                }
                else
                {
                    configFilePath = $"../Config/Bytes/s/GameConfig/{configType.Name}.bytes";
                }

                output[configType] = new(File.ReadAllBytes(configFilePath));
            }

            return output;
        }
    }

    [Invoke]
    public class GetOneConfigBytes: AInvokeHandler<ConfigComponent.GetOneConfigBytes, byte[]>
    {
        public override byte[] Handle(ConfigComponent.GetOneConfigBytes args)
        {
            byte[] configBytes = File.ReadAllBytes($"../Config/{args.ConfigName}.bytes");
            return configBytes;
        }
    }
}