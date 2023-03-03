using UnityEngine;

namespace ET
{
    [FriendClass(typeof(Item))]
    public static class ItemViewHelper
    {
        public static Color ItemQualityColor(this Item item)
        {
            ItemQuality quality = (ItemQuality)item.Quality;
            return quality switch
            {
                ItemQuality.General => Color.white,
                ItemQuality.Good => Color.green,
                ItemQuality.Excellent => Color.blue,
                ItemQuality.Epic => Color.magenta,
                ItemQuality.Legend => new Color(225.0f / 255, 128.0f / 255, 0.0f),
                _ => Color.black,
            };
        }
    }
}