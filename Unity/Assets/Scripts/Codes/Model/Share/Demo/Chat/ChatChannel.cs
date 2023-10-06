using System;

namespace ET
{
    [Flags]
    public enum ChatChannel: short
    {
        [Display("综合")]
        All = short.MaxValue,

        [Display("本地")]
        Local = 1,

        [Display("世界")]
        World = 2,

        [Display("队伍")]
        Team = 4,

        [Display("公会")]
        Guild = 8,

        [Display("私聊")]
        Private = 16,

        [Display("系统")]
        System = 32,
    }
}