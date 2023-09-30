using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class UIPathComponent: Entity, IAwake, IDestroy
    {
        public Dictionary<WindowID, string> WindowPrefabPath = new();
        public Dictionary<string, int> WindowTypeIdDict = new();
        public static UIPathComponent Instance { get; set; }
    }
}