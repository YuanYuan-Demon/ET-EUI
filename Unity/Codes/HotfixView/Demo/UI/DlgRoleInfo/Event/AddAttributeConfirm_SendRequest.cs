using ET.EventType;

namespace ET
{
    public class AddAttributeConfirm_SendRequest : AEventAsync<AddAttributeConfirm>
    {
        protected override async ETTask Run(AddAttributeConfirm args)
        {
            if (args.ConfirmAdd)
            {
                var errcode = await NumericHelper.ReqeustAddAttributePoint(args.ZoneScene, args.Attributes);
                if (errcode != ErrorCode.ERR_Success)
                {
                    Log.Debug("加点失败");
                    return;
                }
                Log.Debug("加点成功");
            }
            else
            {
                //将属性还原
                var numericComponent = UnitHelper.GetMyUnitNumericComponentFromCurScene(args.ZoneScene.CurrentScene());
                long pointCount = 0;
                foreach ((int numericType, long addValue) in args.Attributes)
                {
                    numericComponent.Minus(numericType, addValue);
                    pointCount += addValue;
                }
                numericComponent.Add(NumericType.AttributePoints, pointCount);
            }
        }
    }
}