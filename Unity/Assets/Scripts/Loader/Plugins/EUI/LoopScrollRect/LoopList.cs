using System;
using ET;

namespace UnityEngine.UI
{
    public abstract class LoopList: LoopScrollRectBase
    {
        [HideInInspector]
        [NonSerialized]
        public LoopScrollDataSourceInstance dataSource = new();

        protected override void ProvideData(Transform transform, int index) => this.dataSource.ProvideData(transform, index);

        protected override RectTransform GetFromTempPool(int itemIdx)
        {
            RectTransform nextItem = null;
            if (this.deletedItemTypeStart > 0)
            {
                this.deletedItemTypeStart--;
                nextItem = this.m_Content.GetChild(0) as RectTransform;
                nextItem.SetSiblingIndex(itemIdx - this.itemTypeStart + this.deletedItemTypeStart);
            }
            else if (this.deletedItemTypeEnd > 0)
            {
                this.deletedItemTypeEnd--;
                nextItem = this.m_Content.GetChild(this.m_Content.childCount - 1) as RectTransform;
                nextItem.SetSiblingIndex(itemIdx - this.itemTypeStart + this.deletedItemTypeStart);
            }
            else
            {
                nextItem = this.prefabSource.GetObject(itemIdx).transform as RectTransform;
                nextItem.transform.SetParent(this.m_Content, false);
                nextItem.gameObject.SetActive(true);
            }

            this.ProvideData(nextItem, itemIdx);
            return nextItem;
        }

        protected override void ReturnToTempPool(bool fromStart, int count)
        {
            if (fromStart)
            {
                this.deletedItemTypeStart += count;
            }
            else
            {
                this.deletedItemTypeEnd += count;
            }
        }

        protected override void ClearTempPool()
        {
            Debug.Assert(this.m_Content.childCount >= this.deletedItemTypeStart + this.deletedItemTypeEnd);
            if (this.deletedItemTypeStart > 0)
            {
                for (var i = this.deletedItemTypeStart - 1; i >= 0; i--)
                {
                    this.prefabSource.ReturnObject(this.m_Content.GetChild(i));
                }

                this.deletedItemTypeStart = 0;
            }

            if (this.deletedItemTypeEnd > 0)
            {
                var t = this.m_Content.childCount - this.deletedItemTypeEnd;
                for (var i = this.m_Content.childCount - 1; i >= t; i--)
                {
                    this.prefabSource.ReturnObject(this.m_Content.GetChild(i));
                }

                this.deletedItemTypeEnd = 0;
            }
        }

        public void AddItemRefreshListener(Action<Transform, int> scrollMoveEvent)
        {
            if (null == this.dataSource || scrollMoveEvent == null)
            {
                Log.Error("dataSource or scrollMoveEvent is error!");
                Debug.LogError("dataSource or scrollMoveEvent is error!");
            }

            this.dataSource.scrollMoveEvent = null;
            this.dataSource.scrollMoveEvent = scrollMoveEvent;
        }
    }
}