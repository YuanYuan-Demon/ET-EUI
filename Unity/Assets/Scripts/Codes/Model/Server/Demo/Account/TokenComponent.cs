using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Scene))]
    public class TokenComponent: Entity, IAwake
    {
        public Dictionary<long, string> Tokens { get; private set; } = new Dictionary<long, string>();
    }
}