/*
 * Unless otherwise licensed, this file cannot be copied or redistributed in any format without the explicit consent of the author.
 * (c) Preet Kamal Singh Minhas, http://marchingbytes.com
 * contact@marchingbytes.com
 */
// modified version by Kanglai Qian

using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    public enum PoolInflationType
    {
        /// 当动态池膨胀时，将其增加一个。
        Increment,

        /// 当动态池膨胀时，将池的大小加倍
        Double,
    }

    public class GameObjectPool
    {
        private Stack<PoolObject> availableObjStack = new();

        //the root obj for unused obj
        private GameObject rootObj;
        private PoolInflationType inflationType;
        private string poolName;
        private int objectsInUse;

        public GameObjectPool(string poolName, GameObject poolObjectPrefab, GameObject rootPoolObj, int initialCount, PoolInflationType type)
        {
            if (poolObjectPrefab == null)
            {
#if UNITY_EDITOR
                Debug.LogError("[ObjPoolManager] null pool object prefab !");
#endif
                return;
            }

            this.poolName = poolName;
            this.inflationType = type;
            this.rootObj = new(poolName + "Pool");
            this.rootObj.transform.SetParent(rootPoolObj.transform, false);

            // In case the origin one is Destroyed, we should keep at least one
            GameObject go = UnityEngine.Object.Instantiate(poolObjectPrefab);
            PoolObject po = go.GetComponent<PoolObject>();
            if (po == null)
            {
                po = go.AddComponent<PoolObject>();
            }

            po.poolName = poolName;
            this.AddObjectToPool(po);

            //populate the pool
            this.populatePool(Mathf.Max(initialCount, 1));
        }

        //o(1)
        private void AddObjectToPool(PoolObject po)
        {
            //add to pool
            po.gameObject.SetActive(false);
            po.gameObject.name = this.poolName;
            this.availableObjStack.Push(po);
            po.isPooled = true;
            //add to a root obj
            po.gameObject.transform.SetParent(this.rootObj.transform, false);
        }

        private void populatePool(int initialCount)
        {
            for (var index = 0; index < initialCount; index++)
            {
                PoolObject po = UnityEngine.Object.Instantiate(this.availableObjStack.Peek());
                this.AddObjectToPool(po);
            }
        }

        //o(1)
        public GameObject NextAvailableObject(bool autoActive)
        {
            PoolObject po = null;
            if (this.availableObjStack.Count > 1)
            {
                po = this.availableObjStack.Pop();
            }
            else
            {
                var increaseSize = 0;
                //增加大小变量，仅供信息目的
                if (this.inflationType == PoolInflationType.Increment)
                {
                    increaseSize = 1;
                }
                else if (this.inflationType == PoolInflationType.Double)
                {
                    increaseSize = this.availableObjStack.Count + Mathf.Max(this.objectsInUse, 0);
                }
#if UNITY_EDITOR
                Debug.Log($"Growing pool {this.poolName}: {increaseSize.ToString()} populated");
#endif
                if (increaseSize > 0)
                {
                    this.populatePool(increaseSize);
                    po = this.availableObjStack.Pop();
                }
            }

            GameObject result = null;
            if (po != null)
            {
                this.objectsInUse++;
                po.isPooled = false;
                result = po.gameObject;
                if (autoActive)
                {
                    result.SetActive(true);
                }
            }

            return result;
        }

        //o(1)
        public void ReturnObjectToPool(PoolObject po)
        {
            if (this.poolName.Equals(po.poolName))
            {
                this.objectsInUse--;
                /* we could have used availableObjStack.Contains(po) to check if this object is in pool.
                 * While that would have been more robust, it would have made this method O(n)
                 */
                if (po.isPooled)
                {
#if UNITY_EDITOR
                    Debug.LogWarning(po.gameObject.name + " is already in pool. Why are you trying to return it again? Check usage.");
#endif
                }
                else
                {
                    this.AddObjectToPool(po);
                }
            }
            else
            {
                Debug.LogError(string.Format("Trying to add object to incorrect pool {0} {1}", po.poolName, this.poolName));
            }
        }
    }
}