namespace UnityEngine.UI
{
    public static class LoopScrollRectDefaultControls
    {
        public static GameObject CreateLoopHorizontalScrollRect(DefaultControls.Resources resources, bool isGridLayout = false)
        {
            var root = CreateUIElementRoot("Loop H List", new(200, 200));

            var viewport = CreateUIObject("Viewport", root);
            var viewRect = viewport.GetComponent<RectTransform>();
            viewRect.anchorMax = Vector2.one;
            viewRect.anchorMin = Vector2.zero;
            viewRect.sizeDelta = Vector2.zero;
            viewRect.pivot = Vector2.one * 0.5f;

            viewport.AddComponent<RectMask2D>();
            var bg = viewport.AddComponent<Image>();
            bg.color = new(1, 1, 1, 0);

            var content = CreateUIObject("Content", viewport);
            var contentRT = content.GetComponent<RectTransform>();
            contentRT.anchorMin = Vector2.zero;
            contentRT.anchorMax = Vector2.up;
            contentRT.sizeDelta = Vector2.zero;
            contentRT.pivot = new(0, 0.5f);

            // Setup UI components.

            var list = root.AddComponent<LoopHList>();
            list.content = contentRT;
            list.viewport = viewRect;
            list.horizontalScrollbar = null;
            list.verticalScrollbar = null;
            list.horizontal = true;
            list.vertical = false;
            list.horizontalScrollbarVisibility = LoopScrollRectBase.ScrollbarVisibility.Permanent;
            list.verticalScrollbarVisibility = LoopScrollRectBase.ScrollbarVisibility.Permanent;
            list.horizontalScrollbarSpacing = 0;
            list.verticalScrollbarSpacing = 0;
            list.scrollSensitivity = 20;

            root.AddComponent<RectMask2D>();

            if (isGridLayout)
            {
                var layoutGroup = content.AddComponent<GridLayoutGroup>();
                layoutGroup.startCorner = GridLayoutGroup.Corner.UpperLeft;
                layoutGroup.startAxis = GridLayoutGroup.Axis.Vertical;
                layoutGroup.childAlignment = TextAnchor.UpperLeft;
                layoutGroup.constraint = GridLayoutGroup.Constraint.FixedRowCount;
                layoutGroup.constraintCount = 2;
            }
            else
            {
                var layoutGroup = content.AddComponent<HorizontalLayoutGroup>();
                layoutGroup.childAlignment = TextAnchor.MiddleLeft;
                layoutGroup.childForceExpandWidth = false;
                layoutGroup.childForceExpandHeight = true;
            }

            var sizeFitter = content.AddComponent<ContentSizeFitter>();
            sizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            sizeFitter.verticalFit = ContentSizeFitter.FitMode.Unconstrained;

            return root;
        }

        public static GameObject CreateLoopVerticalScrollRect(DefaultControls.Resources resources, bool isGridLayout = false)
        {
            var root = CreateUIElementRoot("Loop V List", new(200, 200));

            var viewport = CreateUIObject("Viewport", root);
            var viewRect = viewport.GetComponent<RectTransform>();
            viewRect.anchorMax = Vector2.one;
            viewRect.anchorMin = Vector2.zero;
            viewRect.sizeDelta = Vector2.zero;
            viewRect.pivot = Vector2.one * 0.5f;

            viewport.AddComponent<RectMask2D>();
            var bg = viewport.AddComponent<Image>();
            bg.color = new(1, 1, 1, 0);

            var content = CreateUIObject("Content", viewport);
            var contentRT = content.GetComponent<RectTransform>();
            contentRT.anchorMin = Vector2.up;
            contentRT.anchorMax = Vector2.one;
            contentRT.sizeDelta = Vector2.zero;
            contentRT.pivot = new(0.5f, 1);

            // Setup UI components.

            var scrollRect = root.AddComponent<LoopVList>();
            scrollRect.content = contentRT;
            scrollRect.viewport = viewRect;
            scrollRect.horizontalScrollbar = null;
            scrollRect.verticalScrollbar = null;
            scrollRect.horizontal = false;
            scrollRect.vertical = true;
            scrollRect.horizontalScrollbarVisibility = LoopScrollRectBase.ScrollbarVisibility.Permanent;
            scrollRect.verticalScrollbarVisibility = LoopScrollRectBase.ScrollbarVisibility.Permanent;
            scrollRect.horizontalScrollbarSpacing = 0;
            scrollRect.verticalScrollbarSpacing = 0;
            scrollRect.scrollSensitivity = 20;

            if (isGridLayout)
            {
                var layoutGroup = content.AddComponent<GridLayoutGroup>();
                layoutGroup.startCorner = GridLayoutGroup.Corner.UpperLeft;
                layoutGroup.startAxis = GridLayoutGroup.Axis.Horizontal;
                layoutGroup.childAlignment = TextAnchor.UpperLeft;
                layoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
                layoutGroup.constraintCount = 2;
            }
            else
            {
                var layoutGroup = content.AddComponent<VerticalLayoutGroup>();
                layoutGroup.childAlignment = TextAnchor.UpperCenter;
                layoutGroup.childForceExpandWidth = true;
                layoutGroup.childForceExpandHeight = false;
            }

            var sizeFitter = content.AddComponent<ContentSizeFitter>();
            sizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            sizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

            return root;
        }

#region code from DefaultControls.cs

        public struct Resources
        {
            public Sprite standard;
            public Sprite background;
            public Sprite inputField;
            public Sprite knob;
            public Sprite checkmark;
            public Sprite dropdown;
            public Sprite mask;
        }

        private const float kWidth = 160f;
        private const float kThickHeight = 30f;

        private const float kThinHeight = 20f;

        //private static Vector2 s_ThickElementSize = new Vector2(kWidth, kThickHeight);
        //private static Vector2 s_ThinElementSize = new Vector2(kWidth, kThinHeight);
        //private static Vector2 s_ImageElementSize = new Vector2(100f, 100f);
        //private static Color s_DefaultSelectableColor = new Color(1f, 1f, 1f, 1f);
        //private static Color s_PanelColor = new Color(1f, 1f, 1f, 0.392f);
        private static Color s_TextColor = new(50f / 255f, 50f / 255f, 50f / 255f, 1f);

        // Helper methods at top

        private static GameObject CreateUIElementRoot(string name, Vector2 size)
        {
            var child = new GameObject(name);
            var rectTransform = child.AddComponent<RectTransform>();
            rectTransform.sizeDelta = size;
            return child;
        }

        private static GameObject CreateUIObject(string name, GameObject parent)
        {
            var go = new GameObject(name);
            go.AddComponent<RectTransform>();
            SetParentAndAlign(go, parent);
            return go;
        }

        private static void SetDefaultTextValues(Text lbl) =>
                // Set text values we want across UI elements in default controls.
                // Don't set values which are the same as the default values for the Text component,
                // since there's no point in that, and it's good to keep them as consistent as possible.
                lbl.color = s_TextColor;

        private static void SetDefaultColorTransitionValues(Selectable slider)
        {
            var colors = slider.colors;
            colors.highlightedColor = new(0.882f, 0.882f, 0.882f);
            colors.pressedColor = new(0.698f, 0.698f, 0.698f);
            colors.disabledColor = new(0.521f, 0.521f, 0.521f);
        }

        private static void SetParentAndAlign(GameObject child, GameObject parent)
        {
            if (parent == null)
                return;

            child.transform.SetParent(parent.transform, false);
            SetLayerRecursively(child, parent.layer);
        }

        private static void SetLayerRecursively(GameObject go, int layer)
        {
            go.layer = layer;
            var t = go.transform;
            for (var i = 0; i < t.childCount; i++)
                SetLayerRecursively(t.GetChild(i).gameObject, layer);
        }

#endregion
    }
}