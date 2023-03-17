namespace ET
{
    [UniqueId(100, 10000)]
    public static class TimerInvokeType
    {
        // 框架层[100,200]，逻辑层的timer type从200起

        public const int WaitTimer = 100;
        public const int SessionIdleChecker = 101;
        public const int ActorLocationSenderChecker = 102;
        public const int ActorMessageSenderChecker = 103;

        // 逻辑层(200,+)

        public const int MoveTimer = 201;
        public const int AITimer = 202;
        public const int SessionAcceptTimeout = 203;
        public const int AccountSessionCheckOutTime = 204;
        public const int PlayerOfflineOutTime = 205;
        public const int UnitDBSave = 206;
        public const int BattleRound = 207;
        public const int NoticeUnitNumericTime = 208;
        public const int MakeQueueOver = 209;
        public const int MakeQueueUI = 210;
        public const int RankUI = 211;
    }
}