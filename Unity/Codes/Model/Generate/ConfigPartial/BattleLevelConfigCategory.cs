namespace ET
{
    public partial class BattleLevelConfigCategory
    {
        public BattleLevelConfig GetByIndex(int index)
        {
            if (index < 0 || index >= list.Count)
            {
                Log.Error($"Get BattleLevelConfig Index Error: {index}");
                return null;
            }
            return this.list[index];
        }
    }
}