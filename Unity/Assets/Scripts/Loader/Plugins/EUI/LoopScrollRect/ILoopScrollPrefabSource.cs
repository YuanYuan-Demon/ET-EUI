using System;
using ET.Client;

namespace UnityEngine.UI
{
    public interface ILoopScrollPrefabSource
    {
        GameObject GetObject(int index);

        void ReturnObject(Transform trans, bool isDestroy = false);
    }

    [Serializable]
    public class LoopScrollPrefabSourceInstance: ILoopScrollPrefabSource
    {
        public string prefabName;
        public int poolSize = 5;

        private bool inited;

        public virtual GameObject GetObject(int index)
        {
            try
            {
                if (!inited)
                {
                    GameObjectPoolHelper.InitPool(prefabName, poolSize);
                    inited = true;
                }

                return GameObjectPoolHelper.GetObjectFromPool(prefabName);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return null;
            }
        }

        public virtual void ReturnObject(Transform go, bool isDestroy = false)
        {
            try
            {
                if (isDestroy)
                {
                    GameObject.Destroy(go.gameObject);
                }
                else
                {
                    GameObjectPoolHelper.ReturnObjectToPool(go.gameObject);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}