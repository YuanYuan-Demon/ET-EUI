using ET.Client.EventType;

namespace ET.Client
{
    [FriendOf(typeof(DlgRoleInfo))]
    [Event(SceneType.Client)]
    public class AddAttribute_ModifyNumeric : AEvent<AddAttribute>
    {
        protected override async ETTask Run(Scene scene, AddAttribute args)
        {
            await ETTask.CompletedTask;
            DlgRoleInfo ui = scene.GetComponent<UIComponent>().GetDlgLogic<DlgRoleInfo>();
            if (ui is not null)
            {
                //添加到加点缓存中
                var dic = ui.AddingAttributes;
                if (dic.ContainsKey(args.NumericType))
                    dic[args.NumericType] += args.AddValue;
                else
                    dic[args.NumericType] = args.AddValue;

                //修改数值组件
                var numericComponent = scene.GetMyNumericComponent();
                numericComponent.Add(args.NumericType, args.AddValue);
                numericComponent.Minus(NumericType.AttributePoints, args.AddValue);

                //更新UI数据
                ui.Refresh();
            }
        }
    }
}