using System;

namespace ET.Client
{
    [FriendOf(typeof(ET.Production))]
    public static class ProductionSystem
    {
        public static void FromMessage(this Production self, ProductionProto productionProto)
        {
            self.Id = productionProto.Id;
            self.ConfigId = productionProto.ConfigId;
            self.ProductionState = (ProductionState)productionProto.ProductionState;
            self.StartTime = productionProto.StartTime;
            self.TargetTime = productionProto.TargetTime;
        }

        public static bool IsMakingState(this Production self)
        {
            return self.ProductionState == ProductionState.Making;
        }

        public static bool IsMakeTimeOver(this Production self)
        {
            return self.TargetTime <= TimeHelper.ServerNow();
        }

        /// <summary>
        /// 获取制作进度([0,1] --> 完成)
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static float GetProcess(this Production self)
        {
            long makedTime = TimeHelper.ServerNow() - self.StartTime;
            long totalTIme = self.TargetTime - self.StartTime;
            return makedTime >= totalTIme ? 1 : makedTime / (float)totalTIme;
        }

        public static string GetRemainingTimeStr(this Production self)
        {
            long RemainTime = self.TargetTime - TimeHelper.ServerNow();

            if (RemainTime <= 0)
            {
                return "0时0分0秒";
            }

            RemainTime /= 1000;

            float h = MathF.Floor(RemainTime / 3600f);
            float m = MathF.Floor(RemainTime / 60f - h * 60f);
            float s = MathF.Ceiling(RemainTime - m * 60f - h * 3600f);
            return $"{h:00}小时{m:00}分{s:00}秒";
        }
    }
}