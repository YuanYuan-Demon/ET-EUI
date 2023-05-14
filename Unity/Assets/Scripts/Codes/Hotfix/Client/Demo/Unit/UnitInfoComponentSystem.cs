namespace ET.Client
{
    public static class UnitInfoComponentSystem
    {
        public class UnitInfoComponentAwakeSystem : AwakeSystem<UnitInfoComponent, UnitInfo>
        {
            protected override void Awake(UnitInfoComponent self, UnitInfo unitInfo)
            {
                self.Name = unitInfo.Name;
            }
        }
    }
}