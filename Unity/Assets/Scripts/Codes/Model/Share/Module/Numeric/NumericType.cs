namespace ET
{
    // 这个可弄个配置表生成
    public static class NumericType
    {
        public const int Max = 10000;

        public const int Speed = 1000;
        public const int SpeedBase = Speed * 10 + 1;
        public const int SpeedAdd = Speed * 10 + 2;
        public const int SpeedPct = Speed * 10 + 3;
        public const int SpeedFinalAdd = Speed * 10 + 4;
        public const int SpeedFinalPct = Speed * 10 + 5;

        public const int MaxHp = 1002;
        public const int MaxHpBase = MaxHp * 10 + 1;
        public const int MaxHpAdd = MaxHp * 10 + 2;
        public const int MaxHpPct = MaxHp * 10 + 3;
        public const int MaxHpFinalAdd = MaxHp * 10 + 4;
        public const int MaxHpFinalPct = MaxHp * 10 + 5;

        public const int AOI = 1003;
        public const int AOIBase = AOI * 10 + 1;
        public const int AOIAdd = AOI * 10 + 2;
        public const int AOIPct = AOI * 10 + 3;
        public const int AOIFinalAdd = AOI * 10 + 4;
        public const int AOIFinalPct = AOI * 10 + 5;

        public const int MaxMp = 1004;
        public const int MaxMpBase = MaxMp * 10 + 1;
        public const int MaxMpAdd = MaxMp * 10 + 2;
        public const int MaxMpPct = MaxMp * 10 + 3;
        public const int MaxMpFinalAdd = MaxMp * 10 + 4;
        public const int MaxMpFinalPct = MaxMp * 10 + 5;

        public const int AD = 1011;         //物理攻击
        public const int ADBase = AD * 10 + 1;
        public const int ADAdd = AD * 10 + 2;
        public const int ADPct = AD * 10 + 3;
        public const int ADFinalAdd = AD * 10 + 4;
        public const int ADFinalPct = AD * 10 + 5;

        public const int AdditionalAD = 1012;         //伤害追加

        public const int Hp = 1013;  // 生命值
        public const int HpBase = Hp * 10 + 1;
        public const int HpAdd = Hp * 10 + 2;
        public const int HpPct = Hp * 10 + 3;
        public const int HpFinalAdd = Hp * 10 + 4;
        public const int HpFinalPct = Hp * 10 + 5;

        public const int MP = 1014; //法力值
        public const int MPBase = MP * 10 + 1;
        public const int MPAdd = MP * 10 + 2;
        public const int MPPct = MP * 10 + 3;
        public const int MPFinalAdd = MP * 10 + 4;
        public const int MPFinalPct = MP * 10 + 5;

        public const int DEF = 1015; //护甲
        public const int DEFBase = DEF * 10 + 1;
        public const int DEFAdd = DEF * 10 + 2;
        public const int DEFPct = DEF * 10 + 3;
        public const int DEFFinalAdd = DEF * 10 + 4;
        public const int DEFFinalPct = DEF * 10 + 5;

        public const int DEFAddition = 1016; //护甲追加

        public const int Dodge = 1017;           //闪避
        public const int DodgeBase = Dodge * 10 + 1;
        public const int DodgeAdd = Dodge * 10 + 2;
        public const int DodgePct = Dodge * 10 + 3;
        public const int DodgeFinalAdd = Dodge * 10 + 4;
        public const int DodgeFinalPct = Dodge * 10 + 5;

        public const int DodgeAddition = 1018;   // 闪避追加

        public const int CRI = 1019; //暴击率
        public const int CRIBase = CRI * 10 + 1;
        public const int CRIAdd = CRI * 10 + 2;
        public const int CRIPct = CRI * 10 + 3;
        public const int CRIFinalAdd = CRI * 10 + 4;
        public const int CRIFinalPct = CRI * 10 + 5;

        public const int AP = 1020; //魔法攻击
        public const int APBase = AP * 10 + 1;
        public const int APAdd = AP * 10 + 2;
        public const int APPct = AP * 10 + 3;
        public const int APFinalAdd = AP * 10 + 4;
        public const int APFinalPct = AP * 10 + 5;

        public const int MDEF = 1020; //魔抗
        public const int MDEFBase = MDEF * 10 + 1;
        public const int MDEFAdd = MDEF * 10 + 2;
        public const int MDEFPct = MDEF * 10 + 3;
        public const int MDEFFinalAdd = MDEF * 10 + 4;
        public const int MDEFFinalPct = MDEF * 10 + 5;

        public const int STR = 3001; //力量

        public const int STA = 3002; //耐力

        public const int DEX = 3003; //敏捷值

        public const int INT = 3004; //智力

        public const int AttributePoints = 3005; //属性点

        public const int CombatEffectiveness = 3006; //战力值

        public const int Level = 3007;

        public const int Gold = 3008;

        public const int Exp = 3009;

        public const int AdventureStatus = 3010;   //关卡冒险状态

        public const int DyingState = 3011;      //垂死状态

        public const int AdventureStartTime = 3012;   //关卡开始冒险的时间

        public const int IsAlive = 3013;    //存活状态  0为死亡 1为活着

        public const int BattleRandomSeed = 3014;    //战斗随机数种子

        public const int MaxBagCapacity = 3015;   //背包最大负重

        public const int IronStone = 3016; //铁矿石

        public const int Fur = 3017; //皮毛
    }
}