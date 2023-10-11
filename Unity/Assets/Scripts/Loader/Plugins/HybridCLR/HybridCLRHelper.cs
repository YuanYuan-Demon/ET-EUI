using HybridCLR;
using UnityEngine;

namespace ET
{
    public static class HybridCLRHelper
    {
        public static void Load()
        {
            var dictionary = AssetsBundleHelper.LoadBundle("aotdlls.unity3d");
            foreach (var kv in dictionary)
            {
                var bytes = (kv.Value as TextAsset).bytes;
                RuntimeApi.LoadMetadataForAOTAssembly(bytes, HomologousImageMode.Consistent);
            }
        }
    }
}