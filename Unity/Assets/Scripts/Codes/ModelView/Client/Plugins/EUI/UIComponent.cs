using System.Collections.Generic;

namespace ET.Client
{
    public interface IUILogic
    {
    }

    public interface IUIScrollItem
    {
    }

    [ComponentOf(typeof (Scene))]
    [ChildOf(typeof (UIBaseWindow))]
    public class UIComponent: Entity, IAwake, IDestroy
    {
        [StaticField]
        public static UIComponent Instance;

        public Dictionary<int, UIBaseWindow> AllWindowsDic = new();
        public bool IsPopStackWndStatus = false;
        public Queue<WindowID> StackWindowsQueue = new();
        public List<WindowID> UIBaseWindowlistCached = new();
        public Dictionary<int, UIBaseWindow> VisibleWindowsDic = new();
    }
}