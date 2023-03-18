using System.Collections.Generic;

namespace ET.Client
{
    public interface IUILogic
    {
    }

    public interface IUIScrollItem
    {
    }

    [ComponentOf(typeof(Scene))]
    public class UIComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<int, UIBaseWindow> AllWindowsDic = new();
        public List<WindowID> UIBaseWindowlistCached = new();
        public Dictionary<int, UIBaseWindow> VisibleWindowsDic = new();
        public Queue<WindowID> StackWindowsQueue = new();
        public bool IsPopStackWndStatus = false;
    }
}