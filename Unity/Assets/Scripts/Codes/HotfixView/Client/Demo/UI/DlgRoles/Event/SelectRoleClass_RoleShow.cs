using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SelectRoleClass_RoleShow: AEvent<SelectRoleClass>
    {
        protected override async ETTask Run(Scene scene, SelectRoleClass args)
        {
            scene.GetComponent<RoleShowComponent>().ShowRole((int)args.RoleClass - 1);
            await ETTask.CompletedTask;
        }
    }
}