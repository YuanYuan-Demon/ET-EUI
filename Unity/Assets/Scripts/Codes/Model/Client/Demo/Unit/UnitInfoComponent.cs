namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class UnitInfoComponent: Entity, IAwake<UnitInfo>
    {
        public string Name { get; set; }
    }
}