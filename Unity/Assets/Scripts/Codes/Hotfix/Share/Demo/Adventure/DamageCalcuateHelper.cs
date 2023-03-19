namespace ET
{
    public static class DamageCalcuateHelper
    {
        public static int CalcuateDamageValue(Unit attackUnit, Unit TargetUnit, ref SRandom random)
        {
            int damage = attackUnit.GetComponent<NumericComponent>().GetAsInt(NumericType.DamageValue);
            int dodge = TargetUnit.GetComponent<NumericComponent>().GetAsInt(NumericType.Dodge);
            int aromr = TargetUnit.GetComponent<NumericComponent>().GetAsInt(NumericType.Armor);

            //随机 0 - 100% 根据敏捷值进性闪避
            int rate = random.Range(0, 100_0000);
            Log.Debug($"Rate: {rate / 10000:P}");
            if (rate < dodge)
            {
                Log.Debug($"闪避成功");
                damage = 0;
            }
            if (damage > 0)
            {
                //计算护甲减免
                damage -= aromr;
                //最低造成1点伤害
                damage = damage <= 0 ? 1 : damage;
            }
            return damage;
        }
    }
}