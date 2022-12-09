namespace ET
{
    namespace WaitType
    {
        public struct Wait_UnitStop : IWaitType
        {
            public int Error
            {
                get;
                set;
            }
        }

        public struct Wait_CreateMyUnit : IWaitType
        {
            public M2C_CreateMyUnit Message;

            public int Error
            {
                get;
                set;
            }
        }

        public struct Wait_SceneChangeFinish : IWaitType
        {
            public int Error { get; set; }
        }
    }
}