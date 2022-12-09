using ET.EventType;

namespace ET
{
    [FriendClass(typeof(DlgRoleInfo))]
    public class AddAttribute_ModifyNumeric : AEvent<AddAttribute>
    {
        protected override void Run(AddAttribute args)
        {
            DlgRoleInfo ui = args.ZoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoleInfo>();
            if (ui != null)
            {
                //添加到加点缓存中
                var dic = ui?.AddingAttributes;
                if (dic.ContainsKey(args.NumericType))
                    dic[args.NumericType] += args.AddValue;
                else
                    dic[args.NumericType] = args.AddValue;

                //修改数值组件
                var numericComponent = UnitHelper.GetMyUnitNumericComponentFromCurScene(args.ZoneScene.CurrentScene());
                numericComponent?.Add(args.NumericType, args.AddValue);
                numericComponent?.Minus(NumericType.AttributePoints, args.AddValue);

                //更新UI数据
                ui.Refresh();
            }
        }
    }
}