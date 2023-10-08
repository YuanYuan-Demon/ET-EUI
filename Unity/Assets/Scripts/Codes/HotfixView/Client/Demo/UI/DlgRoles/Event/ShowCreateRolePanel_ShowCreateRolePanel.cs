using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class ShowCreateRolePanel_ShowCreateRolePanel: AEvent<ShowCreateRolePanel>
    {
        protected override async ETTask Run(Scene scene, ShowCreateRolePanel args)
        {
            UIComponent.Instance.GetParent<DlgRoles>().ShowSelectPanel(false);
            await ETTask.CompletedTask;
        }
    }
}