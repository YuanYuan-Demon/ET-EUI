using ET.EventType;

namespace ET
{
    [NumericWatcher(NumericType.Exp)]
    [NumericWatcher(NumericType.AttributePoints)]
    public class NumericWatcher_AddExp : INumericWatcher
    {
        public void Run(NumbericChange args)
        {
            if (args.Parent is not Unit unit)
            {
                return;
            }
            switch (args.NumericType)
            {
                case NumericType.Exp:
                    NumericComponent numericComponent = unit.GetComponent<NumericComponent>(); ;
                    int unitLevel = numericComponent.GetAsInt(NumericType.Level);
                    if (PlayerLevelConfigCategory.Instance.Contain(unitLevel))
                    {
                        long needExp = PlayerLevelConfigCategory.Instance.Get(unitLevel).NeedExp;
                        if (args.New >= needExp)
                        {
                            RedDotHelper.ShowRedDotNode(unit.ZoneScene(), RedDotType.UpLevelButton);
                        }
                        else
                        {
                            if (RedDotHelper.IsLogicAlreadyShow(unit.ZoneScene(), RedDotType.UpLevelButton))
                            {
                                RedDotHelper.HideRedDotNode(unit.ZoneScene(), RedDotType.UpLevelButton);
                            }
                        }
                    }
                    break;

                case NumericType.AttributePoints:
                    if (args.New > 0)
                    {
                        RedDotHelper.ShowRedDotNode(unit.ZoneScene(), RedDotType.AddAttribute);
                    }
                    else
                    {
                        if (RedDotHelper.IsLogicAlreadyShow(unit.ZoneScene(), RedDotType.AddAttribute))
                        {
                            RedDotHelper.HideRedDotNode(unit.ZoneScene(), RedDotType.AddAttribute);
                        }
                    }
                    break;
            }

            unit.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgRoleInfo>()?.Refresh();
        }
    }
}