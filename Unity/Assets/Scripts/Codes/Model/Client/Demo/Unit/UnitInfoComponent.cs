namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class UnitInfoComponent: Entity, IAwake<NUnit>
    {
        public string Name { get; set; }
    }
}