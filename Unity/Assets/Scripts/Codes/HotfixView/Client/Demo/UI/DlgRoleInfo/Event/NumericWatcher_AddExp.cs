using ET.EventType;

namespace ET.Client
{
    [NumericWatcher(SceneType.Current, NumericType.Exp)]
    [NumericWatcher(SceneType.Current, NumericType.AttributePoints)]
    public class NumericWatcher_AddExp : INumericWatcher
    {
        public void Run(Unit unit, NumbericChange args)
        {
            Scene zoneScene = unit.ClientScene();
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
                            RedDotHelper.ShowRedDotNode(zoneScene, RedDotType.UpLevelButton);
                        }
                        else
                        {
                            if (RedDotHelper.IsLogicAlreadyShow(zoneScene, RedDotType.UpLevelButton))
                            {
                                RedDotHelper.HideRedDotNode(zoneScene, RedDotType.UpLevelButton);
                            }
                        }
                    }
                    break;

                case NumericType.AttributePoints:
                    if (args.New > 0)
                    {
                        RedDotHelper.ShowRedDotNode(zoneScene, RedDotType.AddAttribute);
                    }
                    else
                    {
                        if (RedDotHelper.IsLogicAlreadyShow(zoneScene, RedDotType.AddAttribute))
                        {
                            RedDotHelper.HideRedDotNode(zoneScene, RedDotType.AddAttribute);
                        }
                    }
                    break;
            }

            zoneScene.GetComponent<UIComponent>().GetDlgLogic<DlgRoleInfo>()?.Refresh();
        }
    }
}