using System;
using System.Reflection;

namespace ET
{
    public static class EnumHelper
    {
        public static string GetDisplayName(this Enum value)
        {
            MemberInfo[] memberInfo = value.GetType().GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof (DisplayAttribute), false);
            return attributes.Length > 0
                    ? (attributes[0] as DisplayAttribute).DisplayName
                    : value.GetName();
        }
    }
}