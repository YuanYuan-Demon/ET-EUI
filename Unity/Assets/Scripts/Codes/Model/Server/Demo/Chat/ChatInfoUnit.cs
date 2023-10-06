namespace ET.Server
{
    [ChildOf(typeof (ChatInfoUnitsComponent))]
    public class ChatInfoUnit: Entity, IAwake, IDestroy
    {
        public long GateSessionActorId;

        public string Name;
    }
}