namespace ET.EventType
{
#region Scene

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

#endregion

#region 登录

    public struct LoginFinish
    {
    }

    public struct EnterMapFinish
    {
    }

#endregion

#region 角色管理

    public struct AfterUnitCreate
    {
        public Unit Unit;
        public string Prefab;
    }

    public struct SelectRole
    {
        public long RoleId;
    }

    public struct SelectRoleClass
    {
        public RoleClass RoleClass;
    }

#endregion

#region 商店

    public struct SelectShopItem
    {
        public long Id;
        public int Count;
    }

#endregion
}