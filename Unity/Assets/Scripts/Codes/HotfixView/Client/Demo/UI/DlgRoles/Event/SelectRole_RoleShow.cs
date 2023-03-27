using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class SelectRole_RoleShow : AEvent<SelectRole>
    {
        protected override async ETTask Run(Scene scene, SelectRole args)
        {
            await ETTask.CompletedTask;
            UnityEngine.Transform transform = scene.GetComponent<RoleShowComponent>().Transform;
            for (int i = 0; i < 3; i++)
            {
                transform.GetChild(i).gameObject.SetActive(i == args.RoleClass);
            }
        }
    }
}