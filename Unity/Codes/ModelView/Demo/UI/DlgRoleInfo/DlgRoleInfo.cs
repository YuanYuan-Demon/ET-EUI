using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRoleInfo : Entity, IAwake, IUILogic
    {
        /// <summary>
        /// 正在加点的属性
        /// </summary>
        public readonly Dictionary<int, long> AddingAttributes = new();

        public List<Scroll_Item_Attribute> ScrollItem_Attribute;
        public DlgRoleInfoViewComponent View { get => this.Parent.GetComponent<DlgRoleInfoViewComponent>(); }
    }
}