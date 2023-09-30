namespace ET
{
    [ObjectSystem]
    public class UnitSystem: AwakeSystem<Unit, int>
    {
        protected override void Awake(Unit self, int name) => self.ConfigId = name;
    }
}