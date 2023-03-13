namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误

        // 110000以下的错误请看ErrorCore.cs

        // 这里配置逻辑层的错误码; 110000 - 200000是抛异常的错误 200001以上不抛异常

        public const int ERR_NetWorkError = 200002;

        /// <summary>
        /// 帐号信息为空
        /// </summary>
        public const int ERR_AccountInfoIsNull = 200003;

        /// <summary>
        /// 账户名格式错误
        /// </summary>
        public const int ERR_AccountNameFormError = 200004;

        /// <summary>
        /// 账号密码错误
        /// </summary>
        public const int ERR_PasswordFormError = 200005;

        /// <summary>
        /// 账户名或密码错误
        /// </summary>
        public const int ERR_AccountInfoError = 200006;

        /// <summary>
        /// 帐号状态异常
        /// </summary>
        public const int ERR_AccountStatusAbnormal = 200007;

        /// <summary>
        /// 重复请求
        /// </summary>
        public const int ERR_RequestRepeatedly = 200008;

        /// <summary>
        /// 令牌错误
        /// </summary>
        public const int ERR_TokenError = 200009;

        /// <summary>
        /// 角色名为空
        /// </summary>
        public const int ERR_RoleNameIsNull = 200010;

        public const int ERR_RoleNameSame = 200011;
        public const int ERR_RoleNotExist = 200012;

        public const int ERR_RequestSceneTypeError = 200013;
        public const int ERR_ConnectGateKeyError = 200014;
        public const int ERR_OtherAccountLogin = 200015;
        public const int ERR_SessionPlayerError = 200016;
        public const int ERR_NonePlayerError = 200017;
        public const int ERR_SessionStatusError = 200018;
        public const int ERR_EnterGameError = 200019;

        public const int ERR_ReEnterGameError2 = 200020;
        public const int ERR_NumericTypeNotExist = 200021;
        public const int ERR_NumericTypeNotAddPoint = 200022;
        public const int ERR_AddPointNotEnough = 200023;

        public const int ERR_AlreadyAdventureStatus = 200024;
        public const int ERR_AdventureInDying = 200025;
        public const int ERR_AdventureLevelError = 200026;
        public const int ERR_AdventureLevelNotEnough = 200027;
        public const int ERR_AdventureRoundError = 200028;
        public const int ERR_AdventureResultError = 200029;
        public const int ERR_AdventureWinResultError = 200030;

        public const int ERR_ExpNotEnough = 200031;
        public const int ERR_ItemNotExist = 200032;
        public const int ERR_AddBagItemError = 200033;
        public const int ERR_EquipItemError = 200034;
        public const int ERR_BagMaxLoad = 200035;

        public const int ERR_MakeConfigNotExist = 200036;
        public const int ERR_MakeConsumeError = 200037;
        public const int ERR_NoMakeFreeQueue = 200038;
        public const int ERR_NoMakeQueueOver = 200039;

        public const int ERR_NoTaskInfoExist = 200040;
        public const int ERR_TaskNoCompleted = 200041;
    }
}