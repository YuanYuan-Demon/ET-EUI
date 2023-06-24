using UnityEngine;

namespace ET.Client
{
    [EnableMethod]
    public class Scroll_Item_ShopItem : Entity, IAwake, IDestroy, IUIScrollItem
    {
        private bool isCacheNode = false;
        private UnityEngine.UI.Image m_EI_Icon_Image = null;
        private TMPro.TextMeshProUGUI m_ET_ItemTitle_TextMeshProUGUI = null;
        private TMPro.TextMeshProUGUI m_ET_ItemPrice_TextMeshProUGUI = null;
        private TMPro.TextMeshProUGUI m_ET_ItemDesc_TextMeshProUGUI = null;
        private UnityEngine.UI.Button m_EB_Add_Button = null;
        private TMPro.TextMeshProUGUI m_ET_BuyCount_TextMeshProUGUI = null;
        private UnityEngine.UI.Button m_EB_Minus_Button = null;
        private UnityEngine.UI.Button m_EB_Select_Button = null;
        private UnityEngine.UI.Image m_EB_Select_Image = null;
        private int count;
        public Transform uiTransform = null;
        public long DataId { get; set; }

        public int Count
        {
            get => count;
            set => count = Mathf.Clamp(value, 1, 99);
        }

        public UnityEngine.UI.Image EI_Icon_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if (this.m_EI_Icon_Image == null)
                    {
                        this.m_EI_Icon_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "Item/EI_Icon");
                    }
                    return this.m_EI_Icon_Image;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "Item/EI_Icon");
                }
            }
        }

        public TMPro.TextMeshProUGUI ET_ItemTitle_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if (this.m_ET_ItemTitle_TextMeshProUGUI == null)
                    {
                        this.m_ET_ItemTitle_TextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "ET_ItemTitle");
                    }
                    return this.m_ET_ItemTitle_TextMeshProUGUI;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "ET_ItemTitle");
                }
            }
        }

        public TMPro.TextMeshProUGUI ET_ItemPrice_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if (this.m_ET_ItemPrice_TextMeshProUGUI == null)
                    {
                        this.m_ET_ItemPrice_TextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "ET_ItemPrice");
                    }
                    return this.m_ET_ItemPrice_TextMeshProUGUI;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "ET_ItemPrice");
                }
            }
        }

        public TMPro.TextMeshProUGUI ET_ItemDesc_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if (this.m_ET_ItemDesc_TextMeshProUGUI == null)
                    {
                        this.m_ET_ItemDesc_TextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "ET_ItemDesc");
                    }
                    return this.m_ET_ItemDesc_TextMeshProUGUI;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "ET_ItemDesc");
                }
            }
        }

        public UnityEngine.UI.Button EB_Add_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if (this.m_EB_Add_Button == null)
                    {
                        this.m_EB_Add_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "BuyCount/EB_Add");
                    }
                    return this.m_EB_Add_Button;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "BuyCount/EB_Add");
                }
            }
        }

        public TMPro.TextMeshProUGUI ET_BuyCount_TextMeshProUGUI
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if (this.m_ET_BuyCount_TextMeshProUGUI == null)
                    {
                        this.m_ET_BuyCount_TextMeshProUGUI = UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "BuyCount/ET_BuyCount");
                    }
                    return this.m_ET_BuyCount_TextMeshProUGUI;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<TMPro.TextMeshProUGUI>(this.uiTransform.gameObject, "BuyCount/ET_BuyCount");
                }
            }
        }

        public UnityEngine.UI.Button EB_Minus_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if (this.m_EB_Minus_Button == null)
                    {
                        this.m_EB_Minus_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "BuyCount/EB_Minus");
                    }
                    return this.m_EB_Minus_Button;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "BuyCount/EB_Minus");
                }
            }
        }

        public UnityEngine.UI.Button EB_Select_Button
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if (this.m_EB_Select_Button == null)
                    {
                        this.m_EB_Select_Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "EB_Select");
                    }
                    return this.m_EB_Select_Button;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject, "EB_Select");
                }
            }
        }

        public UnityEngine.UI.Image EB_Select_Image
        {
            get
            {
                if (this.uiTransform == null)
                {
                    Log.Error("uiTransform is null.");
                    return null;
                }
                if (this.isCacheNode)
                {
                    if (this.m_EB_Select_Image == null)
                    {
                        this.m_EB_Select_Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "EB_Select");
                    }
                    return this.m_EB_Select_Image;
                }
                else
                {
                    return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject, "EB_Select");
                }
            }
        }

        public void SetCacheMode(bool isCache)
        {
            this.isCacheNode = isCache;
        }

        public Scroll_Item_ShopItem BindTrans(Transform trans)
        {
            this.uiTransform = trans;
            return this;
        }

        public void DestroyWidget()
        {
            this.m_EI_Icon_Image = null;
            this.m_ET_ItemTitle_TextMeshProUGUI = null;
            this.m_ET_ItemPrice_TextMeshProUGUI = null;
            this.m_ET_ItemDesc_TextMeshProUGUI = null;
            this.m_EB_Add_Button = null;
            this.m_ET_BuyCount_TextMeshProUGUI = null;
            this.m_EB_Minus_Button = null;
            this.m_EB_Select_Button = null;
            this.m_EB_Select_Image = null;
            this.uiTransform = null;
            this.DataId = 0;
        }
    }
}