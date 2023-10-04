using System.Collections.Generic;

namespace ET.Client
{
    public static class EUIModelViewHelper
    {
        public static void AddUIScrollItems<Dlg, T>(this Dlg self, ref List<T> list, int count) where Dlg : Entity, IUILogic
                where T : Entity, IAwake, IUIScrollItem
        {
            list ??= new List<T>();

            if (count <= 0)
            {
                return;
            }

            foreach (var item in list)
            {
                item.Dispose();
            }

            list.Clear();
            for (var i = 0; i <= count; i++)
            {
                var itemServer = self.AddChild<T>(true);
                list.Add(itemServer);
            }
        }

        public static void AddUIScrollItems<Dlg, T>(this Dlg self, ref Dictionary<int, T> dict, int count) where Dlg : Entity, IUILogic
                where T : Entity, IAwake, IUIScrollItem
        {
            dict ??= new Dictionary<int, T>();

            if (count <= 0)
            {
                return;
            }

            foreach (var item in dict)
            {
                item.Value.Dispose();
            }

            dict.Clear();
            for (var i = 0; i <= count; i++)
            {
                var itemServer = self.AddChild<T>(true);
                dict.Add(i, itemServer);
            }
        }
    }
}