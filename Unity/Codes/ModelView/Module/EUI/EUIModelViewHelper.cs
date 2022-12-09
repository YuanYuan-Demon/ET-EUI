using System.Collections.Generic;

namespace ET
{
    public static class EUIModelViewHelper
    {
        public static void AddUIScrollItems<K, T>(this K self, ref List<T> list, int count) where K : Entity, IUILogic where T : Entity, IAwake, IUIScrollItem
        {
            if (list == null)
            {
                list = new List<T>();
            }

            if (count <= 0)
            {
                return;
            }

            foreach (var item in list)
            {
                item.Dispose();
            }
            list.Clear();
            for (int i = 0; i <= count; i++)
            {
                T itemServer = self.AddChild<T>(true);
                list.Add(itemServer);
            }
        }
    }
}