namespace ET
{
    [FriendClassAttribute(typeof(ET.RankInfo))]
    public static class RankInfoSystem
    {
        #region 生命周期

        public class RankInfoDestroySystem : DestroySystem<RankInfo>
        {
            public override void Destroy(RankInfo self)
            {
                self.UnitId = 0;
                self.Name = null;
                self.Level = 0;
            }
        }

        #endregion 生命周期

        public static void FromMessage(this RankInfo self, RankInfoProto rankInfoProto)
        {
            self.Id = rankInfoProto.Id;
            self.UnitId = rankInfoProto.UnitId;
            self.Name = rankInfoProto.Name;
            self.Level = rankInfoProto.Level;
        }

        public static RankInfoProto ToMessage(this RankInfo self)
        {
            RankInfoProto rankInfoProto = new RankInfoProto
            {
                Id = self.Id,
                UnitId = self.UnitId,
                Name = self.Name,
                Level = self.Level
            };
            return rankInfoProto;
        }
    }
}