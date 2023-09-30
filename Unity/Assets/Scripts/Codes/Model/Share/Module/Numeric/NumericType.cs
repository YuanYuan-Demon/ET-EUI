namespace ET
{
    // 这个可弄个配置表生成
    public enum NumericType
    {
        Max = 10000,

        Speed = 1000,
        SpeedBase = Speed * 10 + 1,
        SpeedAdd = Speed * 10 + 2,
        SpeedPct = Speed * 10 + 3,
        SpeedFinalAdd = Speed * 10 + 4,
        SpeedFinalPct = Speed * 10 + 5,

        MaxHp = 1002,
        MaxHpBase = MaxHp * 10 + 1,
        MaxHpAdd = MaxHp * 10 + 2,
        MaxHpPct = MaxHp * 10 + 3,
        MaxHpFinalAdd = MaxHp * 10 + 4,
        MaxHpFinalPct = MaxHp * 10 + 5,

        AOI = 1003,
        AOIBase = AOI * 10 + 1,
        AOIAdd = AOI * 10 + 2,
        AOIPct = AOI * 10 + 3,
        AOIFinalAdd = AOI * 10 + 4,
        AOIFinalPct = AOI * 10 + 5,

        MaxMp = 1004,
        MaxMpBase = MaxMp * 10 + 1,
        MaxMpAdd = MaxMp * 10 + 2,
        MaxMpPct = MaxMp * 10 + 3,
        MaxMpFinalAdd = MaxMp * 10 + 4,
        MaxMpFinalPct = MaxMp * 10 + 5,

        AD = 1011, //物理攻击
        ADBase = AD * 10 + 1,
        ADAdd = AD * 10 + 2,
        ADPct = AD * 10 + 3,
        ADFinalAdd = AD * 10 + 4,
        ADFinalPct = AD * 10 + 5,

        AdditionalAD = 1012, //伤害追加

        Hp = 1013, // 生命值
        HpBase = Hp * 10 + 1,
        HpAdd = Hp * 10 + 2,
        HpPct = Hp * 10 + 3,
        HpFinalAdd = Hp * 10 + 4,
        HpFinalPct = Hp * 10 + 5,

        MP = 1014, //法力值
        MPBase = MP * 10 + 1,
        MPAdd = MP * 10 + 2,
        MPPct = MP * 10 + 3,
        MPFinalAdd = MP * 10 + 4,
        MPFinalPct = MP * 10 + 5,

        DEF = 1015, //护甲
        DEFBase = DEF * 10 + 1,
        DEFAdd = DEF * 10 + 2,
        DEFPct = DEF * 10 + 3,
        DEFFinalAdd = DEF * 10 + 4,
        DEFFinalPct = DEF * 10 + 5,

        DEFAddition = 1016, //护甲追加

        Dodge = 1017, //闪避
        DodgeBase = Dodge * 10 + 1,
        DodgeAdd = Dodge * 10 + 2,
        DodgePct = Dodge * 10 + 3,
        DodgeFinalAdd = Dodge * 10 + 4,
        DodgeFinalPct = Dodge * 10 + 5,

        DodgeAddition = 1018, // 闪避追加

        CRI = 1019, //暴击率
        CRIBase = CRI * 10 + 1,
        CRIAdd = CRI * 10 + 2,
        CRIPct = CRI * 10 + 3,
        CRIFinalAdd = CRI * 10 + 4,
        CRIFinalPct = CRI * 10 + 5,

        AP = 1020, //魔法攻击
        APBase = AP * 10 + 1,
        APAdd = AP * 10 + 2,
        APPct = AP * 10 + 3,
        APFinalAdd = AP * 10 + 4,
        APFinalPct = AP * 10 + 5,

        MDEF = 1020, //魔抗
        MDEFBase = MDEF * 10 + 1,
        MDEFAdd = MDEF * 10 + 2,
        MDEFPct = MDEF * 10 + 3,
        MDEFFinalAdd = MDEF * 10 + 4,
        MDEFFinalPct = MDEF * 10 + 5,

        STR = 3001, //力量

        STA = 3002, //耐力

        DEX = 3003, //敏捷值

        INT = 3004, //智力

        AttributePoints = 3005, //属性点

        CombatEffectiveness = 3006, //战力值

        Level = 3007,

        Gold = 3008,

        Exp = 3009,

        AdventureStatus = 3010, //关卡冒险状态

        DyingState = 3011, //垂死状态

        AdventureStartTime = 3012, //关卡开始冒险的时间

        IsAlive = 3013, //存活状态  0为死亡 1为活着

        BattleRandomSeed = 3014, //战斗随机数种子

        MaxBagCapacity = 3015, //背包最大负重

        IronStone = 3016, //铁矿石

        Fur = 3017, //皮毛
    }
}