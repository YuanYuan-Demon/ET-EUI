using System;

namespace ET
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DisplayAttribute: BaseAttribute
    {
        public string DisplayName;

        public DisplayAttribute(string name)
        {
            this.DisplayName = name;
        }
    }
}