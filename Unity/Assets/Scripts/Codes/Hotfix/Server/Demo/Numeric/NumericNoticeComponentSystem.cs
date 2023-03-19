using ET.EventType;

namespace ET.Server
{
    [FriendOf(typeof(NumericNoticeComponent))]
    public static class NumericNoticeComponentSystem
    {
        public static void NoticeImmediately(this NumericNoticeComponent self, NumbericChange args)
        {
            Unit unit = self.GetParent<Unit>();
            MessageHelper.SendToClient(unit,
                new M2C_NoticeUnitNumeric()
                {
                    UnitId = unit.Id,
                    NewValue = args.New,
                    NumericType = args.NumericType,
                });
        }
    }
}