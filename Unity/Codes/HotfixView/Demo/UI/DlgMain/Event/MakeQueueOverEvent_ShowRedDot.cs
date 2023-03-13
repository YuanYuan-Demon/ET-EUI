﻿using ET.EventType;

namespace ET
{
    public class MakeQueueOverEvent_ShowRedDot : AEventClass<EventType.MakeQueueOver>
    {
        protected override void Run(MakeQueueOver args)
        {
            bool isExist = args.ZoneScene.GetComponent<ForgeComponent>().IsExistMakeQueueOver();
            if (isExist)
            {
                RedDotHelper.ShowRedDotNode(args.ZoneScene, RedDotType.Forge);
            }
            else
            {
                if (RedDotHelper.IsLogicAlreadyShow(args.ZoneScene, RedDotType.Forge))
                {
                    RedDotHelper.HideRedDotNode(args.ZoneScene, RedDotType.Forge);
                }
            }
        }
    }
}