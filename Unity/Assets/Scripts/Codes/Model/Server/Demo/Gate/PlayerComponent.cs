using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class PlayerComponent : Entity, IAwake, IDestroy
    {
        public readonly Dictionary<long, Player> idPlayers = new Dictionary<long, Player>();
    }
}