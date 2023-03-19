using ET.Client.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class AddAttributeConfirm_SendRequest : AEvent<AddAttributeConfirm>
    {
        protected override async ETTask Run(Scene scene, AddAttributeConfirm args)
        {
            if (args.ConfirmAdd)
            {
                var errcode = await NumericHelper.ReqeustAddAttributePoint(scene, args.Attributes);
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
                var numericComponent = scene.GetMyNumericComponent();
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