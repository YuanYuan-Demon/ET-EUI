using System;
using System.Collections.Generic;
using System.IO;
using ET.Luban;
using UnityEngine;

namespace ET.Client
{
    [Invoke]
    public class GetAllConfigBytes: AInvokeHandler<ConfigComponent.GetAllConfigBytes, Dictionary<Type, ByteBuf>>
    {
        public override Dictionary<Type, ByteBuf> Handle(ConfigComponent.GetAllConfigBytes args)
        {
            var output = new Dictionary<Type, ByteBuf>();
            var configTypes = EventSystem.Instance.GetTypes(typeof (ConfigAttribute));

            if (Define.IsEditor)
            {
                string ct = "cs";
                GlobalConfig globalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
                CodeMode codeMode = globalConfig.CodeMode;
                switch (codeMode)
                {
                    case CodeMode.Client:
                        ct = "c";
                        break;
                    case CodeMode.Server:
                        ct = "s";
                        break;
                    case CodeMode.ClientServer:
                        ct = "cs";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var startConfigs = new List<string>()
                {
                    "StartMachineConfigCategory", "StartProcessConfigCategory", "StartSceneConfigCategory", "StartZoneConfigCategory",
                };
                foreach (Type configType in configTypes)
                {
                    string configFilePath;
                    if (startConfigs.Contains(configType.Name))
                    {
                        configFilePath = $"../Config/Bytes/{ct}/{Options.Instance.StartConfig}/{configType.Name}.bytes";
                    }
                    else
                    {
                        configFilePath = $"../Config/Bytes/{ct}/GameConfig/{configType.Name}.bytes";
                    }

                    output[configType] = new(File.ReadAllBytes(configFilePath));
                }
            }
            else
            {
                using (Root.Instance.Scene.AddComponent<ResourcesComponent>())
                {
                    const string configBundleName = "config.unity3d";
                    ResourcesComponent.Instance.LoadBundle(configBundleName);

                    foreach (Type configType in configTypes)
                    {
                        TextAsset v = ResourcesComponent.Instance.GetAsset(configBundleName, configType.Name) as TextAsset;
                        output[configType] = new(v.bytes);
                    }
                }
            }

            return output;
        }
    }

    [Invoke]
    public class GetOneConfigBytes: AInvokeHandler<ConfigComponent.GetOneConfigBytes, ByteBuf>
    {
        public override ByteBuf Handle(ConfigComponent.GetOneConfigBytes args) => throw new NotImplementedException("client cant use LoadOneConfig");
    }
}