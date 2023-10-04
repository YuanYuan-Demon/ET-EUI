using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    [AddComponentMenu("")]
    [DisallowMultipleComponent]
    [RequireComponent(typeof (RectTransform))]
    /// <summary>
    /// A component for making a child RectTransform scroll with reuseable content.
    /// </summary>
    /// <remarks>
    /// LoopScrollRect will not do any clipping on its own. Combined with a Mask component, it can be turned into a loop scroll view.
    /// </remarks>
    public abstract class LoopScrollRectBase: UIBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IEndDragHandler, IDragHandler,
            IScrollHandler, ICanvasElement, ILayoutElement, ILayoutGroup
    {
        //==========LoopScrollRect==========

        /// <summary>
        ///     A setting for which behavior to use when content moves beyond the confines of its container.
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;  // Required when Using UI elements.
        /// 
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public ScrollRect myScrollRect;
        ///     public Scrollbar newScrollBar;
        /// 
        ///     //Called when a button is pressed
        ///     public void Example(int option)
        ///     {
        ///         if (option == 0)
        ///         {
        ///             myScrollRect.movementType = ScrollRect.MovementType.Clamped;
        ///         }
        ///         else if (option == 1)
        ///         {
        ///             myScrollRect.movementType = ScrollRect.MovementType.Elastic;
        ///         }
        ///         else if (option == 2)
        ///         {
        ///             myScrollRect.movementType = ScrollRect.MovementType.Unrestricted;
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public enum MovementType
        {
            /// <summary>
            ///     Unrestricted movement. The content can move forever.
            /// </summary>
            Unrestricted,

            /// <summary>
            ///     Elastic movement. The content is allowed to temporarily move beyond the container, but is pulled back elastically.
            /// </summary>
            Elastic,

            /// <summary>
            ///     Clamped movement. The content can not be moved beyond its container.
            /// </summary>
            Clamped,
        }

        /// <summary>
        ///     Enum for which behavior to use for scrollbar visibility.
        /// </summary>
        public enum ScrollbarVisibility
        {
            /// <summary>
            ///     Always show the scrollbar.
            /// </summary>
            Permanent,

            /// <summary>
            ///     Automatically hide the scrollbar when no scrolling is needed on this axis. The viewport rect will not be changed.
            /// </summary>
            AutoHide,

            /// <summary>
            ///     Automatically hide the scrollbar when no scrolling is needed on this axis, and expand the viewport rect accordingly.
            /// </summary>
            /// <remarks>
            ///     When this setting is used, the scrollbar and the viewport rect become driven, meaning that values in the RectTransform are calculated
            ///     automatically and can't be manually edited.
            /// </remarks>
            AutoHideAndExpandViewport,
        }

        //==========LoopScrollRect==========
        public LoopScrollPrefabSourceInstance prefabSource = new();

        /// <summary>
        ///     The scroll's total count for items with id in [0, totalCount]. Negative value like -1 means infinite items.
        /// </summary>
        [Tooltip("Total count, negative means INFINITE mode")]
        public int totalCount;

        /// <summary>
        ///     Whether we use down-upsize or right-left direction?
        /// </summary>
        [Tooltip("Reverse direction for dragging")]
        public bool reverseDirection;

        [SerializeField]
        protected RectTransform m_Content; //==========LoopScrollRect==========

        [SerializeField]
        private bool m_Horizontal = true;

        [SerializeField]
        private bool m_Vertical = true;

        [SerializeField]
        private MovementType m_MovementType = MovementType.Elastic;

        [SerializeField]
        private float m_Elasticity = 0.1f;

        [SerializeField]
        private bool m_Inertia = true;

        [SerializeField]
        private float m_DecelerationRate = 0.135f; // Only used when inertia is enabled

        [SerializeField]
        private float m_ScrollSensitivity = 1.0f;

        [SerializeField]
        private RectTransform m_Viewport;

        [SerializeField]
        private Scrollbar m_HorizontalScrollbar;

        [SerializeField]
        private Scrollbar m_VerticalScrollbar;

        [SerializeField]
        private ScrollbarVisibility m_HorizontalScrollbarVisibility;

        [SerializeField]
        private ScrollbarVisibility m_VerticalScrollbarVisibility;

        [SerializeField]
        private float m_HorizontalScrollbarSpacing;

        [SerializeField]
        private float m_VerticalScrollbarSpacing;

        [SerializeField]
        private ScrollRectEvent m_OnValueChanged = new();

        private readonly Vector3[] m_Corners = new Vector3[4];
        protected int deletedItemTypeEnd = 0;

        protected int deletedItemTypeStart = 0;

        protected LoopScrollRectDirection direction = LoopScrollRectDirection.Horizontal;

        /// <summary>
        ///     The last item id in LoopScroll.
        /// </summary>
        protected int itemTypeEnd;

        /// <summary>
        ///     The first item id in LoopScroll.
        /// </summary>
        protected int itemTypeStart;

        protected float m_ContentBottomPadding;

        protected Bounds m_ContentBounds;
        private int m_ContentConstraintCount;

        private bool m_ContentConstraintCountInit;
        protected float m_ContentLeftPadding;
        protected float m_ContentRightPadding;

        private bool m_ContentSpaceInit;
        private float m_ContentSpacing;
        protected Vector2 m_ContentStartPosition = Vector2.zero;
        protected float m_ContentTopPadding;

        private bool m_Dragging;
        protected GridLayoutGroup m_GridLayout;

        [NonSerialized]
        private bool m_HasRebuiltLayout;

        private RectTransform m_HorizontalScrollbarRect;

        private bool m_HSliderExpand;
        private float m_HSliderHeight;

        // The offset from handle position to mouse down position
        private Vector2 m_PointerStartLocalCursor = Vector2.zero;
        private Bounds m_PrevContentBounds;

        private Vector2 m_PrevPosition = Vector2.zero;
        private Bounds m_PrevViewBounds;

        [NonSerialized]
        private RectTransform m_Rect;

        private bool m_Scrolling;

        private DrivenRectTransformTracker m_Tracker;

        private Vector2 m_Velocity;
        private RectTransform m_VerticalScrollbarRect;
        private Bounds m_ViewBounds;

        private RectTransform m_ViewRect;
        private bool m_VSliderExpand;
        private float m_VSliderWidth;

        /// <summary>
        ///     [Optional] Helper for accurate size so we can achieve better scrolling.
        /// </summary>
        [HideInInspector]
        [NonSerialized]
        public LoopScrollSizeHelper sizeHelper = null;

        /// <summary>
        ///     When threshold reached, we prepare new items outside view. This will be expanded to at least 1.5 * itemSize.
        /// </summary>
        protected float threshold;

        protected float contentSpacing
        {
            get
            {
                if (this.m_ContentSpaceInit)
                {
                    return this.m_ContentSpacing;
                }

                this.m_ContentSpaceInit = true;
                this.m_ContentSpacing = 0;
                if (this.m_Content != null)
                {
                    var layout1 = this.m_Content.GetComponent<HorizontalOrVerticalLayoutGroup>();
                    if (layout1 != null)
                    {
                        this.m_ContentSpacing = layout1.spacing;
                        this.m_ContentLeftPadding = layout1.padding.left;
                        this.m_ContentRightPadding = layout1.padding.right;
                        this.m_ContentTopPadding = layout1.padding.top;
                        this.m_ContentBottomPadding = layout1.padding.bottom;
                    }

                    this.m_GridLayout = this.m_Content.GetComponent<GridLayoutGroup>();
                    if (this.m_GridLayout != null)
                    {
                        this.m_ContentSpacing = this.GetAbsDimension(this.m_GridLayout.spacing);
                        this.m_ContentLeftPadding = this.m_GridLayout.padding.left;
                        this.m_ContentRightPadding = this.m_GridLayout.padding.right;
                        this.m_ContentTopPadding = this.m_GridLayout.padding.top;
                        this.m_ContentBottomPadding = this.m_GridLayout.padding.bottom;
                    }
                }

                return this.m_ContentSpacing;
            }
        }

        protected int contentConstraintCount
        {
            get
            {
                if (this.m_ContentConstraintCountInit)
                {
                    return this.m_ContentConstraintCount;
                }

                this.m_ContentConstraintCountInit = true;
                this.m_ContentConstraintCount = 1;
                if (this.m_Content != null)
                {
                    var layout2 = this.m_Content.GetComponent<GridLayoutGroup>();
                    if (layout2 != null)
                    {
                        if (layout2.constraint == GridLayoutGroup.Constraint.Flexible)
                        {
                            Debug.LogWarning("[LoopScrollRect] Flexible not supported yet");
                        }

                        this.m_ContentConstraintCount = layout2.constraintCount;
                    }
                }

                return this.m_ContentConstraintCount;
            }
        }

        /// <summary>
        ///     The first line in scroll. Grid may have multiply items in one line.
        /// </summary>
        protected int StartLine => Mathf.CeilToInt((float)this.itemTypeStart / this.contentConstraintCount);

        /// <summary>
        ///     Current line count in scroll. Grid may have multiply items in one line.
        /// </summary>
        protected int CurrentLines => Mathf.CeilToInt((float)(this.itemTypeEnd - this.itemTypeStart) / this.contentConstraintCount);

        /// <summary>
        ///     Total line count in scroll. Grid may have multiply items in one line.
        /// </summary>
        protected int TotalLines => Mathf.CeilToInt((float)this.totalCount / this.contentConstraintCount);

        /// <summary>
        ///     The content that can be scrolled. It should be a child of the GameObject with ScrollRect on it.
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI; // Required when Using UI elements.
        /// 
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public ScrollRect myScrollRect;
        ///     public RectTransform scrollableContent;
        /// 
        ///     //Do this when the Save button is selected.
        ///     public void Start()
        ///     {
        ///         // assigns the contect that can be scrolled using the ScrollRect.
        ///         myScrollRect.content = scrollableContent;
        ///     }
        /// }
        /// </code>
        /// </example>
        public RectTransform content
        {
            get => this.m_Content;
            set => this.m_Content = value;
        }

        /// <summary>
        ///     Should horizontal scrolling be enabled?
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI; // Required when Using UI elements.
        /// 
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public ScrollRect myScrollRect;
        /// 
        ///     public void Start()
        ///     {
        ///         // Is horizontal scrolling enabled?
        ///         if (myScrollRect.horizontal == true)
        ///         {
        ///             Debug.Log("Horizontal Scrolling is Enabled!");
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public bool horizontal
        {
            get => this.m_Horizontal;
            set => this.m_Horizontal = value;
        }

        /// <summary>
        ///     Should vertical scrolling be enabled?
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;  // Required when Using UI elements.
        /// 
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public ScrollRect myScrollRect;
        /// 
        ///     public void Start()
        ///     {
        ///         // Is Vertical scrolling enabled?
        ///         if (myScrollRect.vertical == true)
        ///         {
        ///             Debug.Log("Vertical Scrolling is Enabled!");
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public bool vertical
        {
            get => this.m_Vertical;
            set => this.m_Vertical = value;
        }

        /// <summary>
        ///     The behavior to use when the content moves beyond the scroll rect.
        /// </summary>
        public MovementType movementType
        {
            get => this.m_MovementType;
            set => this.m_MovementType = value;
        }

        /// <summary>
        ///     The amount of elasticity to use when the content moves beyond the scroll rect.
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;
        /// 
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public ScrollRect myScrollRect;
        /// 
        ///     public void Start()
        ///     {
        ///         // assigns a new value to the elasticity of the scroll rect.
        ///         // The higher the number the longer it takes to snap back.
        ///         myScrollRect.elasticity = 3.0f;
        ///     }
        /// }
        /// </code>
        /// </example>
        public float elasticity
        {
            get => this.m_Elasticity;
            set => this.m_Elasticity = value;
        }

        /// <summary>
        ///     Should movement inertia be enabled?
        /// </summary>
        /// <remarks>
        ///     Inertia means that the scrollrect content will keep scrolling for a while after being dragged. It gradually slows down according to the
        ///     decelerationRate.
        /// </remarks>
        public bool inertia
        {
            get => this.m_Inertia;
            set => this.m_Inertia = value;
        }

        /// <summary>
        ///     The rate at which movement slows down.
        /// </summary>
        /// <remarks>
        ///     The deceleration rate is the speed reduction per second. A value of 0.5 halves the speed each second. The default is 0.135. The
        ///     deceleration rate is only used when inertia is enabled.
        /// </remarks>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI; // Required when Using UI elements.
        /// 
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public ScrollRect myScrollRect;
        /// 
        ///     public void Start()
        ///     {
        ///         // assigns a new value to the decelerationRate of the scroll rect.
        ///         // The higher the number the longer it takes to decelerate.
        ///         myScrollRect.decelerationRate = 5.0f;
        ///     }
        /// }
        /// </code>
        /// </example>
        public float decelerationRate
        {
            get => this.m_DecelerationRate;
            set => this.m_DecelerationRate = value;
        }

        /// <summary>
        ///     The sensitivity to scroll wheel and track pad scroll events.
        /// </summary>
        /// <remarks>
        ///     Higher values indicate higher sensitivity.
        /// </remarks>
        public float scrollSensitivity
        {
            get => this.m_ScrollSensitivity;
            set => this.m_ScrollSensitivity = value;
        }

        /// <summary>
        ///     Reference to the viewport RectTransform that is the parent of the content RectTransform.
        /// </summary>
        public RectTransform viewport
        {
            get => this.m_Viewport;
            set
            {
                this.m_Viewport = value;
                this.SetDirtyCaching();
            }
        }

        /// <summary>
        ///     Optional Scrollbar object linked to the horizontal scrolling of the ScrollRect.
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;  // Required when Using UI elements.
        /// 
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public ScrollRect myScrollRect;
        ///     public Scrollbar newScrollBar;
        /// 
        ///     public void Start()
        ///     {
        ///         // Assigns a scroll bar element to the ScrollRect, allowing you to scroll in the horizontal axis.
        ///         myScrollRect.horizontalScrollbar = newScrollBar;
        ///     }
        /// }
        /// </code>
        /// </example>
        public Scrollbar horizontalScrollbar
        {
            get => this.m_HorizontalScrollbar;
            set
            {
                if (this.m_HorizontalScrollbar)
                {
                    this.m_HorizontalScrollbar.onValueChanged.RemoveListener(this.SetHorizontalNormalizedPosition);
                }

                this.m_HorizontalScrollbar = value;
                if (this.m_HorizontalScrollbar)
                {
                    this.m_HorizontalScrollbar.onValueChanged.AddListener(this.SetHorizontalNormalizedPosition);
                }

                this.SetDirtyCaching();
            }
        }

        /// <summary>
        ///     Optional Scrollbar object linked to the vertical scrolling of the ScrollRect.
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;  // Required when Using UI elements.
        /// 
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public ScrollRect myScrollRect;
        ///     public Scrollbar newScrollBar;
        /// 
        ///     public void Start()
        ///     {
        ///         // Assigns a scroll bar element to the ScrollRect, allowing you to scroll in the vertical axis.
        ///         myScrollRect.verticalScrollbar = newScrollBar;
        ///     }
        /// }
        /// </code>
        /// </example>
        public Scrollbar verticalScrollbar
        {
            get => this.m_VerticalScrollbar;
            set
            {
                if (this.m_VerticalScrollbar)
                {
                    this.m_VerticalScrollbar.onValueChanged.RemoveListener(this.SetVerticalNormalizedPosition);
                }

                this.m_VerticalScrollbar = value;
                if (this.m_VerticalScrollbar)
                {
                    this.m_VerticalScrollbar.onValueChanged.AddListener(this.SetVerticalNormalizedPosition);
                }

                this.SetDirtyCaching();
            }
        }

        /// <summary>
        ///     The mode of visibility for the horizontal scrollbar.
        /// </summary>
        public ScrollbarVisibility horizontalScrollbarVisibility
        {
            get => this.m_HorizontalScrollbarVisibility;
            set
            {
                this.m_HorizontalScrollbarVisibility = value;
                this.SetDirtyCaching();
            }
        }

        /// <summary>
        ///     The mode of visibility for the vertical scrollbar.
        /// </summary>
        public ScrollbarVisibility verticalScrollbarVisibility
        {
            get => this.m_VerticalScrollbarVisibility;
            set
            {
                this.m_VerticalScrollbarVisibility = value;
                this.SetDirtyCaching();
            }
        }

        /// <summary>
        ///     The space between the scrollbar and the viewport.
        /// </summary>
        public float horizontalScrollbarSpacing
        {
            get => this.m_HorizontalScrollbarSpacing;
            set
            {
                this.m_HorizontalScrollbarSpacing = value;
                this.SetDirty();
            }
        }

        /// <summary>
        ///     The space between the scrollbar and the viewport.
        /// </summary>
        public float verticalScrollbarSpacing
        {
            get => this.m_VerticalScrollbarSpacing;
            set
            {
                this.m_VerticalScrollbarSpacing = value;
                this.SetDirty();
            }
        }

        /// <summary>
        ///     Callback executed when the position of the child changes.
        /// </summary>
        /// <remarks>
        ///     onValueChanged is used to watch for changes in the ScrollRect object.
        ///     The onValueChanged call will use the UnityEvent.AddListener API to watch for
        ///     changes.  When changes happen script code provided by the user will be called.
        ///     The UnityEvent.AddListener API for UI.ScrollRect._onValueChanged takes a Vector2.
        ///     Note: The editor allows the onValueChanged value to be set up manually.For example the
        ///     value can be set to run only a runtime.  The object and script function to call are also
        ///     provided here.
        ///     The onValueChanged variable can be alternatively set-up at runtime.The script example below
        ///     shows how this can be done.The script is attached to the ScrollRect object.
        /// </remarks>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using UnityEngine.UI;
        /// 
        /// public class ExampleScript : MonoBehaviour
        /// {
        ///     static ScrollRect scrollRect;
        /// 
        ///     void Start()
        ///     {
        ///         scrollRect = GetComponent<ScrollRect>
        ///             ();
        ///             scrollRect.onValueChanged.AddListener(ListenerMethod);
        ///             }
        ///             public void ListenerMethod(Vector2 value)
        ///             {
        ///             Debug.Log("ListenerMethod: " + value);
        ///             }
        ///             }
        /// </code>
        /// </example>
        public ScrollRectEvent onValueChanged
        {
            get => this.m_OnValueChanged;
            set => this.m_OnValueChanged = value;
        }

        protected RectTransform viewRect
        {
            get
            {
                if (this.m_ViewRect == null)
                {
                    this.m_ViewRect = this.m_Viewport;
                }

                if (this.m_ViewRect == null)
                {
                    this.m_ViewRect = (RectTransform)this.transform;
                }

                return this.m_ViewRect;
            }
        }

        /// <summary>
        ///     The current velocity of the content.
        /// </summary>
        /// <remarks>
        ///     The velocity is defined in units per second.
        /// </remarks>
        public Vector2 velocity
        {
            get => this.m_Velocity;
            set => this.m_Velocity = value;
        }

        private RectTransform rectTransform
        {
            get
            {
                if (this.m_Rect == null)
                {
                    this.m_Rect = this.GetComponent<RectTransform>();
                }

                return this.m_Rect;
            }
        }

        /// <summary>
        ///     The scroll position as a Vector2 between (0,0) and (1,1) with (0,0) being the lower left corner.
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;  // Required when Using UI elements.
        /// 
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public ScrollRect myScrollRect;
        ///     public Vector2 myPosition = new Vector2(0.5f, 0.5f);
        /// 
        ///     public void Start()
        ///     {
        ///         //Change the current scroll position.
        ///         myScrollRect.normalizedPosition = myPosition;
        ///     }
        /// }
        /// </code>
        /// </example>
        public Vector2 normalizedPosition
        {
            get => new(this.horizontalNormalizedPosition, this.verticalNormalizedPosition);
            set
            {
                this.SetNormalizedPosition(value.x, 0);
                this.SetNormalizedPosition(value.y, 1);
            }
        }

        /// <summary>
        ///     The horizontal scroll position as a value between 0 and 1, with 0 being at the left.
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;  // Required when Using UI elements.
        /// 
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public ScrollRect myScrollRect;
        ///     public Scrollbar newScrollBar;
        /// 
        ///     public void Start()
        ///     {
        ///         //Change the current horizontal scroll position.
        ///         myScrollRect.horizontalNormalizedPosition = 0.5f;
        ///     }
        /// }
        /// </code>
        /// </example>
        public float horizontalNormalizedPosition
        {
            get
            {
                this.UpdateBounds();
                //==========LoopScrollRect==========
                if (this.totalCount > 0 && this.itemTypeEnd > this.itemTypeStart)
                {
                    float totalSize, offset;
                    this.GetHorizonalOffsetAndSize(out totalSize, out offset);

                    if (totalSize <= this.m_ViewBounds.size.x)
                    {
                        return this.m_ViewBounds.min.x > offset? 1 : 0;
                    }

                    return (this.m_ViewBounds.min.x - offset) / (totalSize - this.m_ViewBounds.size.x);
                }

                return 0.5f;
                //==========LoopScrollRect==========
            }
            set => this.SetNormalizedPosition(value, 0);
        }

        /// <summary>
        ///     The vertical scroll position as a value between 0 and 1, with 0 being at the bottom.
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;  // Required when Using UI elements.
        /// 
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public ScrollRect myScrollRect;
        ///     public Scrollbar newScrollBar;
        /// 
        ///     public void Start()
        ///     {
        ///         //Change the current vertical scroll position.
        ///         myScrollRect.verticalNormalizedPosition = 0.5f;
        ///     }
        /// }
        /// </code>
        /// </example>

        public float verticalNormalizedPosition
        {
            get
            {
                this.UpdateBounds();
                //==========LoopScrollRect==========
                if (this.totalCount > 0 && this.itemTypeEnd > this.itemTypeStart)
                {
                    float totalSize, offset;
                    this.GetVerticalOffsetAndSize(out totalSize, out offset);

                    if (totalSize <= this.m_ViewBounds.size.y)
                    {
                        return offset > this.m_ViewBounds.max.y? 1 : 0;
                    }

                    return (offset - this.m_ViewBounds.max.y) / (totalSize - this.m_ViewBounds.size.y);
                }

                return 0.5f;
                //==========LoopScrollRect==========
            }
            set => this.SetNormalizedPosition(value, 1);
        }

        private bool hScrollingNeeded
        {
            get
            {
                if (Application.isPlaying)
                {
                    return this.m_ContentBounds.size.x > this.m_ViewBounds.size.x + 0.01f;
                }

                return true;
            }
        }

        private bool vScrollingNeeded
        {
            get
            {
                if (Application.isPlaying)
                {
                    return this.m_ContentBounds.size.y > this.m_ViewBounds.size.y + 0.01f;
                }

                return true;
            }
        }

        //==========LoopScrollRect==========
#if UNITY_EDITOR
        protected override void Awake()
        {
            base.Awake();

            if (Application.isPlaying)
            {
                float value = this.reverseDirection ^ (this.direction == LoopScrollRectDirection.Horizontal)? 0 : 1;
                if (this.m_Content != null)
                {
                    Debug.Assert(this.GetAbsDimension(this.m_Content.pivot) == value, this);
                    Debug.Assert(this.GetAbsDimension(this.m_Content.anchorMin) == value, this);
                    Debug.Assert(this.GetAbsDimension(this.m_Content.anchorMax) == value, this);
                }

                if (this.direction == LoopScrollRectDirection.Vertical)
                {
                    Debug.Assert(this.m_Vertical && !this.m_Horizontal, this);
                }
                else
                {
                    Debug.Assert(!this.m_Vertical && this.m_Horizontal, this);
                }
            }
        }
#endif

        protected virtual void LateUpdate()
        {
            if (!this.m_Content)
            {
                return;
            }

            this.EnsureLayoutHasRebuilt();
            this.UpdateBounds();
            var deltaTime = Time.unscaledDeltaTime;
            var offset = this.CalculateOffset(Vector2.zero);
            if (!this.m_Dragging && (offset != Vector2.zero || this.m_Velocity != Vector2.zero))
            {
                var position = this.m_Content.anchoredPosition;
                for (var axis = 0; axis < 2; axis++)
                {
                    // Apply spring physics if movement is elastic and content has an offset from the view.
                    if (this.m_MovementType == MovementType.Elastic && offset[axis] != 0)
                    {
                        var speed = this.m_Velocity[axis];
                        var smoothTime = this.m_Elasticity;
                        if (this.m_Scrolling)
                        {
                            smoothTime *= 3.0f;
                        }

                        position[axis] = Mathf.SmoothDamp(this.m_Content.anchoredPosition[axis], this.m_Content.anchoredPosition[axis] + offset[axis],
                            ref speed, smoothTime, Mathf.Infinity, deltaTime);
                        if (Mathf.Abs(speed) < 1)
                        {
                            speed = 0;
                        }

                        this.m_Velocity[axis] = speed;
                    }
                    // Else move content according to velocity with deceleration applied.
                    else if (this.m_Inertia)
                    {
                        this.m_Velocity[axis] *= Mathf.Pow(this.m_DecelerationRate, deltaTime);
                        if (Mathf.Abs(this.m_Velocity[axis]) < 1)
                        {
                            this.m_Velocity[axis] = 0;
                        }

                        position[axis] += this.m_Velocity[axis] * deltaTime;
                    }
                    // If we have neither elaticity or friction, there shouldn't be any velocity.
                    else
                    {
                        this.m_Velocity[axis] = 0;
                    }
                }

                if (this.m_MovementType == MovementType.Clamped)
                {
                    offset = this.CalculateOffset(position - this.m_Content.anchoredPosition);
                    position += offset;
                }

                this.SetContentAnchoredPosition(position);
            }

            if (this.m_Dragging && this.m_Inertia)
            {
                Vector3 newVelocity = (this.m_Content.anchoredPosition - this.m_PrevPosition) / deltaTime;
                this.m_Velocity = Vector3.Lerp(this.m_Velocity, newVelocity, deltaTime * 10);
            }

            if (this.m_ViewBounds != this.m_PrevViewBounds || this.m_ContentBounds != this.m_PrevContentBounds ||
                this.m_Content.anchoredPosition != this.m_PrevPosition)
            {
                this.UpdateScrollbars(offset);
#if UNITY_2017_1_OR_NEWER
                UISystemProfilerApi.AddMarker("ScrollRect.value", this);
#endif
                this.m_OnValueChanged.Invoke(this.normalizedPosition);
                this.UpdatePrevData();
            }

            this.UpdateScrollbarVisibility();
            this.m_Scrolling = false;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            if (this.m_HorizontalScrollbar)
            {
                this.m_HorizontalScrollbar.onValueChanged.AddListener(this.SetHorizontalNormalizedPosition);
            }

            if (this.m_VerticalScrollbar)
            {
                this.m_VerticalScrollbar.onValueChanged.AddListener(this.SetVerticalNormalizedPosition);
            }

            CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(this);
            this.SetDirty();
        }

        protected override void OnDisable()
        {
            CanvasUpdateRegistry.UnRegisterCanvasElementForRebuild(this);

            if (this.m_HorizontalScrollbar)
            {
                this.m_HorizontalScrollbar.onValueChanged.RemoveListener(this.SetHorizontalNormalizedPosition);
            }

            if (this.m_VerticalScrollbar)
            {
                this.m_VerticalScrollbar.onValueChanged.RemoveListener(this.SetVerticalNormalizedPosition);
            }

            this.m_Dragging = false;
            this.m_Scrolling = false;
            this.m_HasRebuiltLayout = false;
            this.m_Tracker.Clear();
            this.m_Velocity = Vector2.zero;
            LayoutRebuilder.MarkLayoutForRebuild(this.rectTransform);
            base.OnDisable();
        }

        protected override void OnRectTransformDimensionsChange() => this.SetDirty();

#if UNITY_EDITOR
        protected override void OnValidate() => this.SetDirtyCaching();

#endif

        /// <summary>
        ///     Handling for when the content is beging being dragged.
        /// </summary>
        /// <example>
        ///     <code>
        ///  using UnityEngine;
        ///  using System.Collections;
        ///  using UnityEngine.EventSystems; // Required when using event data
        /// 
        ///  public class ExampleClass : MonoBehaviour, IBeginDragHandler // required interface when using the OnBeginDrag method.
        ///  {
        ///      //Do this when the user starts dragging the element this script is attached to..
        ///      public void OnBeginDrag(PointerEventData data)
        ///      {
        ///          Debug.Log("They started dragging " + this.name);
        ///      }
        ///  }
        ///  </code>
        /// </example>
        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            if (!this.IsActive())
            {
                return;
            }

            this.UpdateBounds();

            this.m_PointerStartLocalCursor = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(this.viewRect, eventData.position, eventData.pressEventCamera,
                out this.m_PointerStartLocalCursor);
            this.m_ContentStartPosition = this.m_Content.anchoredPosition;
            this.m_Dragging = true;
        }
        //==========LoopScrollRect==========

        public virtual void Rebuild(CanvasUpdate executing)
        {
            if (executing == CanvasUpdate.Prelayout)
            {
                this.UpdateCachedData();
            }

            if (executing == CanvasUpdate.PostLayout)
            {
                this.UpdateBounds();
                this.UpdateScrollbars(Vector2.zero);
                this.UpdatePrevData();

                this.m_HasRebuiltLayout = true;
            }
        }

        public virtual void LayoutComplete()
        {
        }

        public virtual void GraphicUpdateComplete()
        {
        }

        /// <summary>
        ///     Handling for when the content is dragged.
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.EventSystems; // Required when using event data
        /// 
        /// public class ExampleClass : MonoBehaviour, IDragHandler // required interface when using the OnDrag method.
        /// {
        ///     //Do this while the user is dragging this UI Element.
        ///     public void OnDrag(PointerEventData data)
        ///     {
        ///         Debug.Log("Currently dragging " + this.name);
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual void OnDrag(PointerEventData eventData)
        {
            if (!this.m_Dragging)
            {
                return;
            }

            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            if (!this.IsActive())
            {
                return;
            }

            Vector2 localCursor;
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(this.viewRect, eventData.position, eventData.pressEventCamera,
                    out localCursor))
            {
                return;
            }

            this.UpdateBounds();

            var pointerDelta = localCursor - this.m_PointerStartLocalCursor;
            var position = this.m_ContentStartPosition + pointerDelta;

            // Offset to get content into place in the view.
            var offset = this.CalculateOffset(position - this.m_Content.anchoredPosition);
            position += offset;
            if (this.m_MovementType == MovementType.Elastic)
            {
                if (offset.x != 0)
                {
                    position.x = position.x - RubberDelta(offset.x, this.m_ViewBounds.size.x);
                }

                if (offset.y != 0)
                {
                    position.y = position.y - RubberDelta(offset.y, this.m_ViewBounds.size.y);
                }
            }

            this.SetContentAnchoredPosition(position);
        }

        /// <summary>
        ///     Handling for when the content has finished being dragged.
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.EventSystems; // Required when using event data
        /// 
        /// public class ExampleClass : MonoBehaviour, IEndDragHandler // required interface when using the OnEndDrag method.
        /// {
        ///     //Do this when the user stops dragging this UI Element.
        ///     public void OnEndDrag(PointerEventData data)
        ///     {
        ///         Debug.Log("Stopped dragging " + this.name + "!");
        ///     }
        /// }
        /// </code>
        /// </example>
        public virtual void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            this.m_Dragging = false;
        }

        public virtual void OnInitializePotentialDrag(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }

            this.m_Velocity = Vector2.zero;
        }

        /// <summary>
        ///     Called by the layout system.
        /// </summary>
        public virtual void CalculateLayoutInputHorizontal()
        {
        }

        /// <summary>
        ///     Called by the layout system.
        /// </summary>
        public virtual void CalculateLayoutInputVertical()
        {
        }

        /// <summary>
        ///     Called by the layout system.
        /// </summary>
        public virtual float minWidth => -1;

        /// <summary>
        ///     Called by the layout system.
        /// </summary>
        public virtual float preferredWidth => -1;

        /// <summary>
        ///     Called by the layout system.
        /// </summary>
        public virtual float flexibleWidth => -1;

        /// <summary>
        ///     Called by the layout system.
        /// </summary>
        public virtual float minHeight => -1;

        /// <summary>
        ///     Called by the layout system.
        /// </summary>
        public virtual float preferredHeight => -1;

        /// <summary>
        ///     Called by the layout system.
        /// </summary>
        public virtual float flexibleHeight => -1;

        /// <summary>
        ///     Called by the layout system.
        /// </summary>
        public virtual int layoutPriority => -1;

        public virtual void SetLayoutHorizontal()
        {
            this.m_Tracker.Clear();

            if (this.m_HSliderExpand || this.m_VSliderExpand)
            {
                this.m_Tracker.Add(this, this.viewRect,
                    DrivenTransformProperties.Anchors |
                    DrivenTransformProperties.SizeDelta |
                    DrivenTransformProperties.AnchoredPosition);

                // Make view full size to see if content fits.
                this.viewRect.anchorMin = Vector2.zero;
                this.viewRect.anchorMax = Vector2.one;
                this.viewRect.sizeDelta = Vector2.zero;
                this.viewRect.anchoredPosition = Vector2.zero;

                // Recalculate content layout with this size to see if it fits when there are no scrollbars.
                LayoutRebuilder.ForceRebuildLayoutImmediate(this.m_Content);
                this.m_ViewBounds = new(this.viewRect.rect.center, this.viewRect.rect.size);
                this.m_ContentBounds = this.GetBounds();
            }

            // If it doesn't fit vertically, enable vertical scrollbar and shrink view horizontally to make room for it.
            if (this.m_VSliderExpand && this.vScrollingNeeded)
            {
                this.viewRect.sizeDelta = new(-(this.m_VSliderWidth + this.m_VerticalScrollbarSpacing), this.viewRect.sizeDelta.y);

                // Recalculate content layout with this size to see if it fits vertically
                // when there is a vertical scrollbar (which may reflowed the content to make it taller).
                LayoutRebuilder.ForceRebuildLayoutImmediate(this.m_Content);
                this.m_ViewBounds = new(this.viewRect.rect.center, this.viewRect.rect.size);
                this.m_ContentBounds = this.GetBounds();
            }

            // If it doesn't fit horizontally, enable horizontal scrollbar and shrink view vertically to make room for it.
            if (this.m_HSliderExpand && this.hScrollingNeeded)
            {
                this.viewRect.sizeDelta = new(this.viewRect.sizeDelta.x, -(this.m_HSliderHeight + this.m_HorizontalScrollbarSpacing));
                this.m_ViewBounds = new(this.viewRect.rect.center, this.viewRect.rect.size);
                this.m_ContentBounds = this.GetBounds();
            }

            // If the vertical slider didn't kick in the first time, and the horizontal one did,
            // we need to check again if the vertical slider now needs to kick in.
            // If it doesn't fit vertically, enable vertical scrollbar and shrink view horizontally to make room for it.
            if (this.m_VSliderExpand && this.vScrollingNeeded && this.viewRect.sizeDelta.x == 0 && this.viewRect.sizeDelta.y < 0)
            {
                this.viewRect.sizeDelta = new(-(this.m_VSliderWidth + this.m_VerticalScrollbarSpacing), this.viewRect.sizeDelta.y);
            }
        }

        public virtual void SetLayoutVertical()
        {
            this.UpdateScrollbarLayout();
            this.m_ViewBounds = new(this.viewRect.rect.center, this.viewRect.rect.size);
            this.m_ContentBounds = this.GetBounds();
        }

        public virtual void OnScroll(PointerEventData data)
        {
            if (!this.IsActive())
            {
                return;
            }

            this.EnsureLayoutHasRebuilt();
            this.UpdateBounds();

            var delta = data.scrollDelta;
            // Down is positive for scroll events, while in UI system up is positive.
            delta.y *= -1;
            if (this.vertical && !this.horizontal)
            {
                if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
                {
                    delta.y = delta.x;
                }

                delta.x = 0;
            }

            if (this.horizontal && !this.vertical)
            {
                if (Mathf.Abs(delta.y) > Mathf.Abs(delta.x))
                {
                    delta.x = delta.y;
                }

                delta.y = 0;
            }

            if (data.IsScrolling())
            {
                this.m_Scrolling = true;
            }

            var position = this.m_Content.anchoredPosition;
            position += delta * this.m_ScrollSensitivity;
            if (this.m_MovementType == MovementType.Clamped)
            {
                position += this.CalculateOffset(position - this.m_Content.anchoredPosition);
            }

            this.SetContentAnchoredPosition(position);
            this.UpdateBounds();
        }

        protected abstract float GetSize(RectTransform item, bool includeSpacing = true);
        protected abstract float GetDimension(Vector2 vector);
        protected abstract float GetAbsDimension(Vector2 vector);
        protected abstract Vector2 GetVector(float value);

        protected virtual bool UpdateItems(ref Bounds viewBounds, ref Bounds contentBounds) => false;

        public void ClearCells()
        {
            if (Application.isPlaying)
            {
                this.itemTypeStart = 0;
                this.itemTypeEnd = 0;
                this.totalCount = 0;
                for (var i = this.m_Content.childCount - 1; i >= 0; i--)
                {
                    this.prefabSource.ReturnObject(this.m_Content.GetChild(i));
                }
            }
        }

        public int GetFirstItem(out float offset)
        {
            if (this.direction == LoopScrollRectDirection.Vertical)
            {
                offset = this.m_ViewBounds.max.y - this.m_ContentBounds.max.y;
            }
            else
            {
                offset = this.m_ContentBounds.min.x - this.m_ViewBounds.min.x;
            }

            var idx = 0;
            if (this.itemTypeEnd > this.itemTypeStart)
            {
                var size = this.GetSize(this.m_Content.GetChild(0) as RectTransform, false);
                while (size + offset <= 0 && this.itemTypeStart + idx + this.contentConstraintCount < this.itemTypeEnd)
                {
                    offset += size;
                    idx += this.contentConstraintCount;
                    size = this.GetSize(this.m_Content.GetChild(idx) as RectTransform);
                }
            }

            return idx + this.itemTypeStart;
        }

        public int GetLastItem(out float offset)
        {
            if (this.direction == LoopScrollRectDirection.Vertical)
            {
                offset = this.m_ContentBounds.min.y - this.m_ViewBounds.min.y;
            }
            else
            {
                offset = this.m_ViewBounds.max.x - this.m_ContentBounds.max.x;
            }

            var idx = 0;
            if (this.itemTypeEnd > this.itemTypeStart)
            {
                var totalChildCount = this.m_Content.childCount;
                var size = this.GetSize(this.m_Content.GetChild(totalChildCount - idx - 1) as RectTransform, false);
                while (size + offset <= 0 && this.itemTypeStart < this.itemTypeEnd - idx - this.contentConstraintCount)
                {
                    offset += size;
                    idx += this.contentConstraintCount;
                    size = this.GetSize(this.m_Content.GetChild(totalChildCount - idx - 1) as RectTransform);
                }
            }

            offset = -offset;
            return this.itemTypeEnd - idx - 1;
        }

        public void SrollToCell(int index, float speed)
        {
            if (this.totalCount >= 0 && (index < 0 || index >= this.totalCount))
            {
                Debug.LogErrorFormat("invalid index {0}", index);
                return;
            }

            this.StopAllCoroutines();
            if (speed <= 0)
            {
                this.RefillCells(index);
                return;
            }

            this.StartCoroutine(this.ScrollToCellCoroutine(index, speed));
        }

        public void SrollToCellWithinTime(int index, float time)
        {
            if (this.totalCount >= 0 && (index < 0 || index >= this.totalCount))
            {
                Debug.LogErrorFormat("invalid index {0}", index);
                return;
            }

            this.StopAllCoroutines();
            if (time <= 0)
            {
                this.RefillCells(index);
                return;
            }

            float dist = 0;
            float offset = 0;
            var currentFirst = this.reverseDirection? this.GetLastItem(out offset) : this.GetFirstItem(out offset);

            var TargetLine = index / this.contentConstraintCount;
            var CurrentLine = currentFirst / this.contentConstraintCount;

            if (TargetLine == CurrentLine)
            {
                dist = offset;
            }
            else
            {
                if (this.sizeHelper != null)
                {
                    dist = this.GetDimension(this.sizeHelper.GetItemsSize(currentFirst) - this.sizeHelper.GetItemsSize(index)) +
                            this.contentSpacing * (CurrentLine - TargetLine - 1);
                    dist += offset;
                }
                else
                {
                    var elementSize = (this.GetAbsDimension(this.m_ContentBounds.size) - this.contentSpacing * (this.CurrentLines - 1)) /
                            this.CurrentLines;
                    dist = elementSize * (CurrentLine - TargetLine) + this.contentSpacing * (CurrentLine - TargetLine - 1);
                    dist -= offset;
                }
            }

            this.StartCoroutine(this.ScrollToCellCoroutine(index, Mathf.Abs(dist) / time));
        }

        private IEnumerator ScrollToCellCoroutine(int index, float speed)
        {
            var needMoving = true;
            while (needMoving)
            {
                yield return null;
                if (!this.m_Dragging)
                {
                    float move = 0;
                    if (index < this.itemTypeStart)
                    {
                        move = -Time.deltaTime * speed;
                    }
                    else if (index >= this.itemTypeEnd)
                    {
                        move = Time.deltaTime * speed;
                    }
                    else
                    {
                        this.m_ViewBounds = new(this.viewRect.rect.center, this.viewRect.rect.size);
                        var m_ItemBounds = this.GetBounds4Item(index);
                        var offset = 0.0f;
                        if (this.direction == LoopScrollRectDirection.Vertical)
                        {
                            offset = this.reverseDirection? this.m_ViewBounds.min.y - m_ItemBounds.min.y
                                    : this.m_ViewBounds.max.y - m_ItemBounds.max.y;
                        }
                        else
                        {
                            offset = this.reverseDirection? m_ItemBounds.max.x - this.m_ViewBounds.max.x
                                    : m_ItemBounds.min.x - this.m_ViewBounds.min.x;
                        }

                        // check if we cannot move on
                        if (this.totalCount >= 0)
                        {
                            if (offset > 0 && this.itemTypeEnd == this.totalCount && !this.reverseDirection)
                            {
                                m_ItemBounds = this.GetBounds4Item(this.totalCount - 1);
                                // reach bottom
                                if ((this.direction == LoopScrollRectDirection.Vertical && m_ItemBounds.min.y > this.m_ViewBounds.min.y) ||
                                    (this.direction == LoopScrollRectDirection.Horizontal && m_ItemBounds.max.x < this.m_ViewBounds.max.x))
                                {
                                    needMoving = false;
                                    break;
                                }
                            }
                            else if (offset < 0 && this.itemTypeStart == 0 && this.reverseDirection)
                            {
                                m_ItemBounds = this.GetBounds4Item(0);
                                if ((this.direction == LoopScrollRectDirection.Vertical && m_ItemBounds.max.y < this.m_ViewBounds.max.y) ||
                                    (this.direction == LoopScrollRectDirection.Horizontal && m_ItemBounds.min.x > this.m_ViewBounds.min.x))
                                {
                                    needMoving = false;
                                    break;
                                }
                            }
                        }

                        var maxMove = Time.deltaTime * speed;
                        if (Mathf.Abs(offset) < maxMove)
                        {
                            needMoving = false;
                            move = offset;
                        }
                        else
                        {
                            move = Mathf.Sign(offset) * maxMove;
                        }
                    }

                    if (move != 0)
                    {
                        var offset = this.GetVector(move);
                        this.m_Content.anchoredPosition += offset;
                        this.m_PrevPosition += offset;
                        this.m_ContentStartPosition += offset;
                        this.UpdateBounds(true);
                    }
                }
            }

            this.StopMovement();
            this.UpdatePrevData();
        }

        protected abstract void ProvideData(Transform transform, int index);

        /// <summary>
        ///     Refresh item data
        /// </summary>
        public void RefreshCells()
        {
            if (Application.isPlaying && this.isActiveAndEnabled)
            {
                this.itemTypeEnd = this.itemTypeStart;
                // recycle items if we can
                for (var i = 0; i < this.m_Content.childCount; i++)
                {
                    if (this.itemTypeEnd < this.totalCount)
                    {
                        this.ProvideData(this.m_Content.GetChild(i), this.itemTypeEnd);
                        this.itemTypeEnd++;
                    }
                    else
                    {
                        this.prefabSource.ReturnObject(this.m_Content.GetChild(i));
                        i--;
                    }
                }

                this.UpdateBounds(true);
                this.UpdateScrollbars(Vector2.zero);
            }
        }

        /// <summary>
        ///     Refill cells from endItem at the end while clear existing ones
        /// </summary>
        public void RefillCellsFromEnd(int endItem = 0, bool alignStart = false)
        {
            if (!Application.isPlaying)
            {
                return;
            }

            this.itemTypeEnd = this.reverseDirection? endItem : this.totalCount - endItem;
            this.itemTypeStart = this.itemTypeEnd;

            if (this.totalCount >= 0 && this.itemTypeStart % this.contentConstraintCount != 0)
            {
                this.itemTypeStart = this.itemTypeStart / this.contentConstraintCount * this.contentConstraintCount;
            }

            this.ReturnToTempPool(!this.reverseDirection, this.m_Content.childCount);

            float sizeToFill = this.GetAbsDimension(this.viewRect.rect.size), sizeFilled = 0;

            var first = true;
            while (sizeToFill > sizeFilled)
            {
                var size = this.reverseDirection? this.NewItemAtEnd(!first) : this.NewItemAtStart(!first);
                if (size < 0)
                {
                    break;
                }

                first = false;
                sizeFilled += size;
            }

            // refill from start in case not full yet
            while (sizeToFill > sizeFilled)
            {
                var size = this.reverseDirection? this.NewItemAtStart(!first) : this.NewItemAtEnd(!first);
                if (size < 0)
                {
                    break;
                }

                first = false;
                sizeFilled += size;
            }

            var pos = this.m_Content.anchoredPosition;
            var dist = alignStart? 0 : Mathf.Max(0, sizeFilled - sizeToFill);
            if (this.reverseDirection)
            {
                dist = -dist;
            }

            if (this.direction == LoopScrollRectDirection.Vertical)
            {
                pos.y = dist;
            }
            else
            {
                pos.x = -dist;
            }

            this.m_Content.anchoredPosition = pos;
            this.m_ContentStartPosition = pos;

            this.ClearTempPool();
            // force build bounds here so scrollbar can access newest bounds
            LayoutRebuilder.ForceRebuildLayoutImmediate(this.m_Content);
            Canvas.ForceUpdateCanvases();
            this.UpdateBounds();
            this.UpdateScrollbars(Vector2.zero);
            this.StopMovement();
            this.UpdatePrevData();
        }

        /// <summary>
        ///     Refill cells with startItem at the beginning while clear existing ones
        /// </summary>
        /// <param name="startItem">The first item to fill</param>
        /// <param name="fillViewRect">
        ///     When [startItem, totalCount] is not enough for the whole viewBound, should we fill backwords with [0,
        ///     startItem)?
        /// </param>
        /// <param name="contentOffset">The first item's offset compared to viewBound</param>
        public void RefillCells(int startItem = 0, bool fillViewRect = false, float contentOffset = 0)
        {
            if (!Application.isPlaying)
            {
                return;
            }

            this.itemTypeStart = this.reverseDirection? this.totalCount - startItem : startItem;
            if (this.totalCount >= 0 && this.itemTypeStart % this.contentConstraintCount != 0)
            {
                this.itemTypeStart = this.itemTypeStart / this.contentConstraintCount * this.contentConstraintCount;
            }

            this.itemTypeEnd = this.itemTypeStart;

            // Don't `Canvas.ForceUpdateCanvases();` here, or it will new/delete cells to change itemTypeStart/End
            this.ReturnToTempPool(this.reverseDirection, this.m_Content.childCount);

            var sizeToFill = this.GetAbsDimension(this.viewRect.rect.size) + Mathf.Abs(contentOffset);
            float sizeFilled = 0;
            // m_ViewBounds may be not ready when RefillCells on Start

            float itemSize = 0;

            var first = true;
            while (sizeToFill > sizeFilled)
            {
                var size = this.reverseDirection? this.NewItemAtStart(!first) : this.NewItemAtEnd(!first);
                if (size < 0)
                {
                    break;
                }

                first = false;
                itemSize = size;
                sizeFilled += size;
            }

            // refill from start in case not full yet
            while (sizeToFill > sizeFilled)
            {
                var size = this.reverseDirection? this.NewItemAtEnd(!first) : this.NewItemAtStart(!first);
                if (size < 0)
                {
                    break;
                }

                first = false;
                sizeFilled += size;
            }

            if (fillViewRect && itemSize > 0 && sizeFilled < sizeToFill)
            {
                //calculate how many items can be added above the offset, so it still is visible in the view
                var itemsToAddCount = (int)((sizeToFill - sizeFilled) / itemSize);
                var newOffset = startItem - itemsToAddCount;
                if (newOffset < 0)
                {
                    newOffset = 0;
                }

                if (newOffset != startItem)
                {
                    //refill again, with the new offset value, and now with fillViewRect disabled.
                    this.RefillCells(newOffset);
                }
            }

            var pos = this.m_Content.anchoredPosition;
            if (this.direction == LoopScrollRectDirection.Vertical)
            {
                pos.y = -contentOffset;
            }
            else
            {
                pos.x = contentOffset;
            }

            this.m_Content.anchoredPosition = pos;
            this.m_ContentStartPosition = pos;

            this.ClearTempPool();
            // force build bounds here so scrollbar can access newest bounds
            LayoutRebuilder.ForceRebuildLayoutImmediate(this.m_Content);
            Canvas.ForceUpdateCanvases();
            this.UpdateBounds();
            this.UpdateScrollbars(Vector2.zero);
            this.StopMovement();
            this.UpdatePrevData();
        }

        protected float NewItemAtStart(bool includeSpacing = true)
        {
            if (this.totalCount >= 0 && this.itemTypeStart - this.contentConstraintCount < 0)
            {
                return -1;
            }

            float size = 0;
            for (var i = 0; i < this.contentConstraintCount; i++)
            {
                this.itemTypeStart--;
                var newItem = this.GetFromTempPool(this.itemTypeStart);
                newItem.SetSiblingIndex(this.deletedItemTypeStart);
                size = Mathf.Max(this.GetSize(newItem, includeSpacing), size);
            }

            this.threshold = Mathf.Max(this.threshold, size * 1.5f);

            if (size > 0)
            {
                this.m_HasRebuiltLayout = false;
                if (!this.reverseDirection)
                {
                    var offset = this.GetVector(size);
                    this.m_Content.anchoredPosition += offset;
                    this.m_PrevPosition += offset;
                    this.m_ContentStartPosition += offset;
                }
            }

            return size;
        }

        protected float DeleteItemAtStart()
        {
            // special case: when moving or dragging, we cannot simply delete start when we've reached the end
            if ((this.m_Dragging || this.m_Velocity != Vector2.zero) && this.totalCount >= 0 &&
                this.itemTypeEnd >= this.totalCount - this.contentConstraintCount)
            {
                return 0;
            }

            var availableChilds = this.m_Content.childCount - this.deletedItemTypeStart - this.deletedItemTypeEnd;
            Debug.Assert(availableChilds >= 0);
            if (availableChilds == 0)
            {
                return 0;
            }

            float size = 0;
            for (var i = 0; i < this.contentConstraintCount; i++)
            {
                var oldItem = this.m_Content.GetChild(this.deletedItemTypeStart) as RectTransform;
                size = Mathf.Max(this.GetSize(oldItem), size);
                this.ReturnToTempPool(true);
                availableChilds--;
                this.itemTypeStart++;

                if (availableChilds == 0)
                {
                    break;
                }
            }

            if (size > 0)
            {
                this.m_HasRebuiltLayout = false;
                if (!this.reverseDirection)
                {
                    var offset = this.GetVector(size);
                    this.m_Content.anchoredPosition -= offset;
                    this.m_PrevPosition -= offset;
                    this.m_ContentStartPosition -= offset;
                }
            }

            return size;
        }

        protected float NewItemAtEnd(bool includeSpacing = true)
        {
            if (this.totalCount >= 0 && this.itemTypeEnd >= this.totalCount)
            {
                return -1;
            }

            float size = 0;
            // issue 4: fill lines to end first
            var availableChilds = this.m_Content.childCount - this.deletedItemTypeStart - this.deletedItemTypeEnd;
            var count = this.contentConstraintCount - availableChilds % this.contentConstraintCount;
            for (var i = 0; i < count; i++)
            {
                var newItem = this.GetFromTempPool(this.itemTypeEnd);
                newItem.SetSiblingIndex(this.m_Content.childCount - this.deletedItemTypeEnd - 1);
                size = Mathf.Max(this.GetSize(newItem, includeSpacing), size);
                this.itemTypeEnd++;
                if (this.totalCount >= 0 && this.itemTypeEnd >= this.totalCount)
                {
                    break;
                }
            }

            this.threshold = Mathf.Max(this.threshold, size * 1.5f);

            if (size > 0)
            {
                this.m_HasRebuiltLayout = false;
                if (this.reverseDirection)
                {
                    var offset = this.GetVector(size);
                    this.m_Content.anchoredPosition -= offset;
                    this.m_PrevPosition -= offset;
                    this.m_ContentStartPosition -= offset;
                }
            }

            return size;
        }

        protected float DeleteItemAtEnd()
        {
            if ((this.m_Dragging || this.m_Velocity != Vector2.zero) && this.totalCount >= 0 && this.itemTypeStart < this.contentConstraintCount)
            {
                return 0;
            }

            var availableChilds = this.m_Content.childCount - this.deletedItemTypeStart - this.deletedItemTypeEnd;
            Debug.Assert(availableChilds >= 0);
            if (availableChilds == 0)
            {
                return 0;
            }

            float size = 0;
            for (var i = 0; i < this.contentConstraintCount; i++)
            {
                var oldItem = this.m_Content.GetChild(this.m_Content.childCount - this.deletedItemTypeEnd - 1) as RectTransform;
                size = Mathf.Max(this.GetSize(oldItem), size);
                this.ReturnToTempPool(false);
                availableChilds--;
                this.itemTypeEnd--;
                if (this.itemTypeEnd % this.contentConstraintCount == 0 || availableChilds == 0)
                {
                    break; //just delete the whole row
                }
            }

            if (size > 0)
            {
                this.m_HasRebuiltLayout = false;
                if (this.reverseDirection)
                {
                    var offset = this.GetVector(size);
                    this.m_Content.anchoredPosition += offset;
                    this.m_PrevPosition += offset;
                    this.m_ContentStartPosition += offset;
                }
            }

            return size;
        }

        protected abstract RectTransform GetFromTempPool(int itemIdx);
        protected abstract void ReturnToTempPool(bool fromStart, int count = 1);
        protected abstract void ClearTempPool();

        private void UpdateCachedData()
        {
            var transform = this.transform;
            this.m_HorizontalScrollbarRect = this.m_HorizontalScrollbar == null? null : this.m_HorizontalScrollbar.transform as RectTransform;
            this.m_VerticalScrollbarRect = this.m_VerticalScrollbar == null? null : this.m_VerticalScrollbar.transform as RectTransform;

            // These are true if either the elements are children, or they don't exist at all.
            var viewIsChild = this.viewRect.parent == transform;
            var hScrollbarIsChild = !this.m_HorizontalScrollbarRect || this.m_HorizontalScrollbarRect.parent == transform;
            var vScrollbarIsChild = !this.m_VerticalScrollbarRect || this.m_VerticalScrollbarRect.parent == transform;
            var allAreChildren = viewIsChild && hScrollbarIsChild && vScrollbarIsChild;

            this.m_HSliderExpand = allAreChildren && this.m_HorizontalScrollbarRect &&
                    this.horizontalScrollbarVisibility == ScrollbarVisibility.AutoHideAndExpandViewport;
            this.m_VSliderExpand = allAreChildren && this.m_VerticalScrollbarRect &&
                    this.verticalScrollbarVisibility == ScrollbarVisibility.AutoHideAndExpandViewport;
            this.m_HSliderHeight = this.m_HorizontalScrollbarRect == null? 0 : this.m_HorizontalScrollbarRect.rect.height;
            this.m_VSliderWidth = this.m_VerticalScrollbarRect == null? 0 : this.m_VerticalScrollbarRect.rect.width;
        }

        /// <summary>
        ///     See member in base class.
        /// </summary>
        /// <example>
        ///     <code>
        /// using UnityEngine;
        /// using System.Collections;
        /// using UnityEngine.UI;  // Required when Using UI elements.
        /// 
        /// public class ExampleClass : MonoBehaviour
        /// {
        ///     public ScrollRect myScrollRect;
        /// 
        ///     public void Start()
        ///     {
        ///         //Checks if the ScrollRect called "myScrollRect" is active.
        ///         if (myScrollRect.IsActive())
        ///         {
        ///             Debug.Log("The Scroll Rect is active!");
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public override bool IsActive() => base.IsActive() && this.m_Content != null;

        private void EnsureLayoutHasRebuilt()
        {
            if (!this.m_HasRebuiltLayout && !CanvasUpdateRegistry.IsRebuildingLayout())
            {
                Canvas.ForceUpdateCanvases();
            }
        }

        /// <summary>
        ///     Sets the velocity to zero on both axes so the content stops moving.
        /// </summary>
        public virtual void StopMovement() => this.m_Velocity = Vector2.zero;

        /// <summary>
        ///     Sets the anchored position of the content.
        /// </summary>
        protected virtual void SetContentAnchoredPosition(Vector2 position)
        {
            if (!this.m_Horizontal)
            {
                position.x = this.m_Content.anchoredPosition.x;
            }

            if (!this.m_Vertical)
            {
                position.y = this.m_Content.anchoredPosition.y;
            }

            //==========LoopScrollRect==========
            if ((position - this.m_Content.anchoredPosition).sqrMagnitude > 0.001f)
            {
                this.m_Content.anchoredPosition = position;
                this.UpdateBounds(true);
            }
            //==========LoopScrollRect==========
        }

        /// <summary>
        ///     Helper function to update the previous data fields on a ScrollRect. Call this before you change data in the ScrollRect.
        /// </summary>
        protected void UpdatePrevData()
        {
            if (this.m_Content == null)
            {
                this.m_PrevPosition = Vector2.zero;
            }
            else
            {
                this.m_PrevPosition = this.m_Content.anchoredPosition;
            }

            this.m_PrevViewBounds = this.m_ViewBounds;
            this.m_PrevContentBounds = this.m_ContentBounds;
        }

        //==========LoopScrollRect==========
        public void GetHorizonalOffsetAndSize(out float totalSize, out float offset)
        {
            if (this.sizeHelper != null)
            {
                totalSize = this.sizeHelper.GetItemsSize(this.TotalLines).x + this.contentSpacing * (this.TotalLines - 1);
                offset = this.m_ContentBounds.min.x - this.sizeHelper.GetItemsSize(this.StartLine).x - this.contentSpacing * this.StartLine;
            }
            else
            {
                var elementSize = (this.m_ContentBounds.size.x - this.contentSpacing * (this.CurrentLines - 1)) / this.CurrentLines;
                totalSize = elementSize * this.TotalLines + this.contentSpacing * (this.TotalLines - 1);
                offset = this.m_ContentBounds.min.x - elementSize * this.StartLine - this.contentSpacing * this.StartLine;
            }
        }

        public void GetVerticalOffsetAndSize(out float totalSize, out float offset)
        {
            if (this.sizeHelper != null)
            {
                totalSize = this.sizeHelper.GetItemsSize(this.TotalLines).y + this.contentSpacing * (this.TotalLines - 1);
                offset = this.m_ContentBounds.max.y + this.sizeHelper.GetItemsSize(this.StartLine).y + this.contentSpacing * this.StartLine;
            }
            else
            {
                var elementSize = (this.m_ContentBounds.size.y - this.contentSpacing * (this.CurrentLines - 1)) / this.CurrentLines;
                totalSize = elementSize * this.TotalLines + this.contentSpacing * (this.TotalLines - 1);
                offset = this.m_ContentBounds.max.y + elementSize * this.StartLine + this.contentSpacing * this.StartLine;
            }
        }
        //==========LoopScrollRect==========

        private void UpdateScrollbars(Vector2 offset)
        {
            if (this.m_HorizontalScrollbar)
            {
                //==========LoopScrollRect==========
                if (this.m_ContentBounds.size.x > 0 && this.totalCount > 0)
                {
                    float totalSize, _;
                    this.GetHorizonalOffsetAndSize(out totalSize, out _);
                    this.m_HorizontalScrollbar.size = Mathf.Clamp01((this.m_ViewBounds.size.x - Mathf.Abs(offset.x)) / totalSize);
                }
                //==========LoopScrollRect==========
                else
                {
                    this.m_HorizontalScrollbar.size = 1;
                }

                this.m_HorizontalScrollbar.value = this.horizontalNormalizedPosition;
            }

            if (this.m_VerticalScrollbar)
            {
                //==========LoopScrollRect==========
                if (this.m_ContentBounds.size.y > 0 && this.totalCount > 0)
                {
                    float totalSize, _;
                    this.GetVerticalOffsetAndSize(out totalSize, out _);
                    this.m_VerticalScrollbar.size = Mathf.Clamp01((this.m_ViewBounds.size.y - Mathf.Abs(offset.y)) / totalSize);
                }
                //==========LoopScrollRect==========
                else
                {
                    this.m_VerticalScrollbar.size = 1;
                }

                this.m_VerticalScrollbar.value = this.verticalNormalizedPosition;
            }
        }

        private void SetHorizontalNormalizedPosition(float value) => this.SetNormalizedPosition(value, 0);
        private void SetVerticalNormalizedPosition(float value) => this.SetNormalizedPosition(value, 1);

        /// <summary>
        ///     >Set the horizontal or vertical scroll position as a value between 0 and 1, with 0 being at the left or at the bottom.
        /// </summary>
        /// <param name="value">The position to set, between 0 and 1.</param>
        /// <param name="axis">The axis to set: 0 for horizontal, 1 for vertical.</param>
        protected virtual void SetNormalizedPosition(float value, int axis)
        {
            //==========LoopScrollRect==========
            if (this.totalCount <= 0 || this.itemTypeEnd <= this.itemTypeStart)
            {
                return;
            }
            //==========LoopScrollRect==========

            this.EnsureLayoutHasRebuilt();
            this.UpdateBounds();

            //==========LoopScrollRect==========
            float totalSize, offset;
            var newAnchoredPosition = this.m_Content.anchoredPosition[axis];
            if (axis == 0)
            {
                this.GetHorizonalOffsetAndSize(out totalSize, out offset);

                if (totalSize >= this.m_ViewBounds.size.x)
                {
                    newAnchoredPosition += this.m_ViewBounds.min.x - value * (totalSize - this.m_ViewBounds.size.x) - offset;
                }
            }
            else
            {
                this.GetVerticalOffsetAndSize(out totalSize, out offset);

                if (totalSize >= this.m_ViewBounds.size.y)
                {
                    newAnchoredPosition -= offset - value * (totalSize - this.m_ViewBounds.size.y) - this.m_ViewBounds.max.y;
                }
            }
            //==========LoopScrollRect==========

            Vector3 anchoredPosition = this.m_Content.anchoredPosition;
            if (Mathf.Abs(anchoredPosition[axis] - newAnchoredPosition) > 0.01f)
            {
                anchoredPosition[axis] = newAnchoredPosition;
                this.m_Content.anchoredPosition = anchoredPosition;
                this.m_Velocity[axis] = 0;
                this.UpdateBounds(true); //==========LoopScrollRect==========
            }
        }

        private static float RubberDelta(float overStretching, float viewSize) =>
                (1 - 1 / (Mathf.Abs(overStretching) * 0.55f / viewSize + 1)) * viewSize * Mathf.Sign(overStretching);

        private void UpdateScrollbarVisibility()
        {
            UpdateOneScrollbarVisibility(this.vScrollingNeeded, this.m_Vertical, this.m_VerticalScrollbarVisibility, this.m_VerticalScrollbar);
            UpdateOneScrollbarVisibility(this.hScrollingNeeded, this.m_Horizontal, this.m_HorizontalScrollbarVisibility, this.m_HorizontalScrollbar);
        }

        private static void UpdateOneScrollbarVisibility(bool xScrollingNeeded, bool xAxisEnabled, ScrollbarVisibility scrollbarVisibility,
        Scrollbar scrollbar)
        {
            if (scrollbar)
            {
                if (scrollbarVisibility == ScrollbarVisibility.Permanent)
                {
                    if (scrollbar.gameObject.activeSelf != xAxisEnabled)
                    {
                        scrollbar.gameObject.SetActive(xAxisEnabled);
                    }
                }
                else
                {
                    if (scrollbar.gameObject.activeSelf != xScrollingNeeded)
                    {
                        scrollbar.gameObject.SetActive(xScrollingNeeded);
                    }
                }
            }
        }

        private void UpdateScrollbarLayout()
        {
            if (this.m_VSliderExpand && this.m_HorizontalScrollbar)
            {
                this.m_Tracker.Add(this, this.m_HorizontalScrollbarRect,
                    DrivenTransformProperties.AnchorMinX |
                    DrivenTransformProperties.AnchorMaxX |
                    DrivenTransformProperties.SizeDeltaX |
                    DrivenTransformProperties.AnchoredPositionX);
                this.m_HorizontalScrollbarRect.anchorMin = new(0, this.m_HorizontalScrollbarRect.anchorMin.y);
                this.m_HorizontalScrollbarRect.anchorMax = new(1, this.m_HorizontalScrollbarRect.anchorMax.y);
                this.m_HorizontalScrollbarRect.anchoredPosition = new(0, this.m_HorizontalScrollbarRect.anchoredPosition.y);
                if (this.vScrollingNeeded)
                {
                    this.m_HorizontalScrollbarRect.sizeDelta = new(-(this.m_VSliderWidth + this.m_VerticalScrollbarSpacing),
                        this.m_HorizontalScrollbarRect.sizeDelta.y);
                }
                else
                {
                    this.m_HorizontalScrollbarRect.sizeDelta = new(0, this.m_HorizontalScrollbarRect.sizeDelta.y);
                }
            }

            if (this.m_HSliderExpand && this.m_VerticalScrollbar)
            {
                this.m_Tracker.Add(this, this.m_VerticalScrollbarRect,
                    DrivenTransformProperties.AnchorMinY |
                    DrivenTransformProperties.AnchorMaxY |
                    DrivenTransformProperties.SizeDeltaY |
                    DrivenTransformProperties.AnchoredPositionY);
                this.m_VerticalScrollbarRect.anchorMin = new(this.m_VerticalScrollbarRect.anchorMin.x, 0);
                this.m_VerticalScrollbarRect.anchorMax = new(this.m_VerticalScrollbarRect.anchorMax.x, 1);
                this.m_VerticalScrollbarRect.anchoredPosition = new(this.m_VerticalScrollbarRect.anchoredPosition.x, 0);
                if (this.hScrollingNeeded)
                {
                    this.m_VerticalScrollbarRect.sizeDelta = new(this.m_VerticalScrollbarRect.sizeDelta.x,
                        -(this.m_HSliderHeight + this.m_HorizontalScrollbarSpacing));
                }
                else
                {
                    this.m_VerticalScrollbarRect.sizeDelta = new(this.m_VerticalScrollbarRect.sizeDelta.x, 0);
                }
            }
        }

        /// <summary>
        ///     Calculate the bounds the ScrollRect should be using.
        /// </summary>
        protected void UpdateBounds(bool updateItems = false) //==========LoopScrollRect==========
        {
            this.m_ViewBounds = new(this.viewRect.rect.center, this.viewRect.rect.size);
            this.m_ContentBounds = this.GetBounds();

            if (this.m_Content == null)
            {
                return;
            }

            // ============LoopScrollRect============
            // Don't do this in Rebuild. Make use of ContentBounds before Adjust here.
            if (Application.isPlaying && updateItems && this.UpdateItems(ref this.m_ViewBounds, ref this.m_ContentBounds))
            {
                this.EnsureLayoutHasRebuilt();
                this.m_ContentBounds = this.GetBounds();
            }
            // ============LoopScrollRect============

            var contentSize = this.m_ContentBounds.size;
            var contentPos = this.m_ContentBounds.center;
            var contentPivot = this.m_Content.pivot;
            AdjustBounds(ref this.m_ViewBounds, ref contentPivot, ref contentSize, ref contentPos);
            this.m_ContentBounds.size = contentSize;
            this.m_ContentBounds.center = contentPos;

            if (this.movementType == MovementType.Clamped)
            {
                // Adjust content so that content bounds bottom (right side) is never higher (to the left) than the view bounds bottom (right side).
                // top (left side) is never lower (to the right) than the view bounds top (left side).
                // All this can happen if content has shrunk.
                // This works because content size is at least as big as view size (because of the call to InternalUpdateBounds above).
                var delta = Vector2.zero;
                if (this.m_ViewBounds.max.x > this.m_ContentBounds.max.x)
                {
                    delta.x = Math.Min(this.m_ViewBounds.min.x - this.m_ContentBounds.min.x, this.m_ViewBounds.max.x - this.m_ContentBounds.max.x);
                }
                else if (this.m_ViewBounds.min.x < this.m_ContentBounds.min.x)
                {
                    delta.x = Math.Max(this.m_ViewBounds.min.x - this.m_ContentBounds.min.x, this.m_ViewBounds.max.x - this.m_ContentBounds.max.x);
                }

                if (this.m_ViewBounds.min.y < this.m_ContentBounds.min.y)
                {
                    delta.y = Math.Max(this.m_ViewBounds.min.y - this.m_ContentBounds.min.y, this.m_ViewBounds.max.y - this.m_ContentBounds.max.y);
                }
                else if (this.m_ViewBounds.max.y > this.m_ContentBounds.max.y)
                {
                    delta.y = Math.Min(this.m_ViewBounds.min.y - this.m_ContentBounds.min.y, this.m_ViewBounds.max.y - this.m_ContentBounds.max.y);
                }

                if (delta.sqrMagnitude > float.Epsilon)
                {
                    contentPos = this.m_Content.anchoredPosition + delta;
                    if (!this.m_Horizontal)
                    {
                        contentPos.x = this.m_Content.anchoredPosition.x;
                    }

                    if (!this.m_Vertical)
                    {
                        contentPos.y = this.m_Content.anchoredPosition.y;
                    }

                    AdjustBounds(ref this.m_ViewBounds, ref contentPivot, ref contentSize, ref contentPos);
                }
            }
        }

        internal static void AdjustBounds(ref Bounds viewBounds, ref Vector2 contentPivot, ref Vector3 contentSize, ref Vector3 contentPos)
        {
            // Make sure content bounds are at least as large as view by adding padding if not.
            // One might think at first that if the content is smaller than the view, scrolling should be allowed.
            // However, that's not how scroll views normally work.
            // Scrolling is *only* possible when content is *larger* than view.
            // We use the pivot of the content rect to decide in which directions the content bounds should be expanded.
            // E.g. if pivot is at top, bounds are expanded downwards.
            // This also works nicely when ContentSizeFitter is used on the content.
            var excess = viewBounds.size - contentSize;
            if (excess.x > 0)
            {
                contentPos.x -= excess.x * (contentPivot.x - 0.5f);
                contentSize.x = viewBounds.size.x;
            }

            if (excess.y > 0)
            {
                contentPos.y -= excess.y * (contentPivot.y - 0.5f);
                contentSize.y = viewBounds.size.y;
            }
        }

        private Bounds GetBounds()
        {
            if (this.m_Content == null)
            {
                return new();
            }

            this.m_Content.GetWorldCorners(this.m_Corners);
            var viewWorldToLocalMatrix = this.viewRect.worldToLocalMatrix;
            return InternalGetBounds(this.m_Corners, ref viewWorldToLocalMatrix);
        }

        internal static Bounds InternalGetBounds(Vector3[] corners, ref Matrix4x4 viewWorldToLocalMatrix)
        {
            var vMin = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            var vMax = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            for (var j = 0; j < 4; j++)
            {
                var v = viewWorldToLocalMatrix.MultiplyPoint3x4(corners[j]);
                vMin = Vector3.Min(v, vMin);
                vMax = Vector3.Max(v, vMax);
            }

            var bounds = new Bounds(vMin, Vector3.zero);
            bounds.Encapsulate(vMax);
            return bounds;
        }

        //==========LoopScrollRect==========
        private Bounds GetBounds4Item(int index)
        {
            if (this.m_Content == null)
            {
                return new();
            }

            var offset = index - this.itemTypeStart;
            if (offset < 0 || offset >= this.m_Content.childCount)
            {
                return new();
            }

            var rt = this.m_Content.GetChild(offset) as RectTransform;
            if (rt == null)
            {
                return new();
            }

            rt.GetWorldCorners(this.m_Corners);

            var viewWorldToLocalMatrix = this.viewRect.worldToLocalMatrix;
            return InternalGetBounds(this.m_Corners, ref viewWorldToLocalMatrix);
        }
        //==========LoopScrollRect==========

        private Vector2 CalculateOffset(Vector2 delta)
        {
            //==========LoopScrollRect==========
            if (this.totalCount < 0 || this.movementType == MovementType.Unrestricted)
            {
                return delta;
            }

            var contentBound = this.m_ContentBounds;
            if (this.m_Horizontal)
            {
                float totalSize, offset;
                this.GetHorizonalOffsetAndSize(out totalSize, out offset);

                var center = contentBound.center;
                center.x = offset;
                contentBound.Encapsulate(center);
                center.x = offset + totalSize;
                contentBound.Encapsulate(center);
            }

            if (this.m_Vertical)
            {
                float totalSize, offset;
                this.GetVerticalOffsetAndSize(out totalSize, out offset);

                var center = contentBound.center;
                center.y = offset;
                contentBound.Encapsulate(center);
                center.y = offset - totalSize;
                contentBound.Encapsulate(center);
            }

            //==========LoopScrollRect==========
            return InternalCalculateOffset(ref this.m_ViewBounds, ref contentBound, this.m_Horizontal, this.m_Vertical, this.m_MovementType,
                ref delta);
        }

        internal static Vector2 InternalCalculateOffset(ref Bounds viewBounds, ref Bounds contentBounds, bool horizontal, bool vertical,
        MovementType movementType, ref Vector2 delta)
        {
            var offset = Vector2.zero;
            if (movementType == MovementType.Unrestricted)
            {
                return offset;
            }

            Vector2 min = contentBounds.min;
            Vector2 max = contentBounds.max;

            // min/max offset extracted to check if approximately 0 and avoid recalculating layout every frame (case 1010178)

            if (horizontal)
            {
                min.x += delta.x;
                max.x += delta.x;

                var maxOffset = viewBounds.max.x - max.x;
                var minOffset = viewBounds.min.x - min.x;

                if (minOffset < -0.001f)
                {
                    offset.x = minOffset;
                }
                else if (maxOffset > 0.001f)
                {
                    offset.x = maxOffset;
                }
            }

            if (vertical)
            {
                min.y += delta.y;
                max.y += delta.y;

                var maxOffset = viewBounds.max.y - max.y;
                var minOffset = viewBounds.min.y - min.y;

                if (maxOffset > 0.001f)
                {
                    offset.y = maxOffset;
                }
                else if (minOffset < -0.001f)
                {
                    offset.y = minOffset;
                }
            }

            return offset;
        }

        /// <summary>
        ///     Override to alter or add to the code that keeps the appearance of the scroll rect synced with its data.
        /// </summary>
        protected void SetDirty()
        {
            if (!this.IsActive())
            {
                return;
            }

            LayoutRebuilder.MarkLayoutForRebuild(this.rectTransform);
        }

        /// <summary>
        ///     Override to alter or add to the code that caches data to avoid repeated heavy operations.
        /// </summary>
        protected void SetDirtyCaching()
        {
            if (!this.IsActive())
            {
                return;
            }

            CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(this);
            LayoutRebuilder.MarkLayoutForRebuild(this.rectTransform);
        }

        /// <summary>
        ///     Direction for LoopScroll. This is a bit confusing with m_Horizontal/m_Vertical.
        /// </summary>
        protected enum LoopScrollRectDirection
        {
            Vertical,
            Horizontal,
        }

        [Serializable]
        /// <summary>
        /// Event type used by the ScrollRect.
        /// </summary>
        public class ScrollRectEvent: UnityEvent<Vector2>
        {
        }
    }
}