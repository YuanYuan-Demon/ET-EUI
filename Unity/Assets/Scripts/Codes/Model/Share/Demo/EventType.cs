namespace ET.EventType
{
    public struct SceneChangeStart
    {
    }

    public struct SceneChangeFinish
    {
    }

    public struct AfterCreateClientScene
    {
    }

    public struct AfterCreateCurrentScene
    {
    }

    public struct AppStartInitFinish
    {
    }

    public struct LoginFinish
    {
    }

    public struct EnterMapFinish
    {
    }

    public struct AfterUnitCreate
    {
        public Unit Unit;
    }

    public struct SelectRole
    {
        public long RoleId;
    }

    public struct SelectRoleClass
    {
        public RoleClass RoleClass;
    }

    public struct SelectShopItem
    {
        public long Id;
        public int Count;
    }
}