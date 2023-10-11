using System;

namespace ET
{
    [Flags]
    public enum ChatChannel: short
    {
        [Display("综合")]
        All = short.MaxValue,

        [Display("本地")]
        Local = 1 << 0,

        [Display("世界")]
        World = 1 << 1,

        [Display("队伍")]
        Team = 1 << 2,

        [Display("公会")]
        Guild = 1 << 3,

        [Display("私聊")]
        Private = 1 << 4,

        [Display("系统")]
        System = 1 << 5,
    }
}