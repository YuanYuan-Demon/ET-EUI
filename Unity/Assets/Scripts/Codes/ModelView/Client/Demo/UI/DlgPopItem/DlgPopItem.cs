using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgPopItem: Entity, IAwake, IUILogic
    {
        public Dictionary<bool, string> ShowColor = new() { { true, "green" }, { false, "red" } };
        public DlgPopItemViewComponent View => this.GetComponent<DlgPopItemViewComponent>();
    }

    public class PopItemData: ShowWindowData
    {
        public Vector3 ClickPosition;
        public ItemConfig ItemConfig;
        public bool ShowButtons = true;
    }
}