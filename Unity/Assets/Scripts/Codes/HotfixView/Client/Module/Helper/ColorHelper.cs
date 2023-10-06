using UnityEngine;

namespace ET.Client
{
    public static class ColorHelper
    {
        public static string ToHtmlColor(this Color color) => ColorUtility.ToHtmlStringRGB(color);
    }
}