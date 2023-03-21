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
            long remainTime = self.TargetTime - TimeHelper.ServerNow();
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(remainTime);
            if (timeSpan.TotalMinutes <= 0)
                return "已完成";
            return timeSpan.ToString(@"hh\:mm\:ss");

            //var leftTime = remainTime / 1000f;
            //StringBuilder sb = new();
            //float h = MathF.Floor(leftTime / 3600f);
            //float m = MathF.Floor(leftTime / 60f - h * 60f);
            //float s = MathF.Ceiling(leftTime - m * 60f - h * 3600f);

            //if (h > 0) sb.Append($"{h:00}时");
            //if (m > 0) sb.Append($"{m:00}分");
            //if (s > 0) sb.Append($"{s:00}秒");
        }
    }
}