using DG.Tweening;
using TMPro;
using UnityEngine;

namespace ET
{
    public static class FlyDamageValueViewComponentSystem
    {
        public class FlyDamageValueViewComponentAwakeSystem : AwakeSystem<FlyDamageValueViewComponent>
        {
            public override void Awake(FlyDamageValueViewComponent self)
            {
                self.Init().Coroutine();
            }
        }

        public class FlyDamageValueViewComponentDestroySystem : DestroySystem<FlyDamageValueViewComponent>
        {
            public override void Destroy(FlyDamageValueViewComponent self)
            {
                foreach (var go in self.FlyDamageSet)
                {
                    go.transform.DOKill();
                    UnityEngine.Object.Destroy(go);
                }

                self.FlyDamageSet.Clear();
            }
        }

        public static async ETTask Init(this FlyDamageValueViewComponent self)
        {
            await ResourcesComponent.Instance.LoadBundleAsync("flyDamageValue.unity3d");
            GameObject prefabGO = ResourcesComponent.Instance.GetAsset("flyDamageValue.unity3d", "flyDamageValue") as GameObject;
            await GameObjectPoolHelper.InitPoolFormGamObjectAsync(prefabGO, 3);
        }

        public static async ETTask SpawnFlyDamage(this FlyDamageValueViewComponent self, Vector3 startPos, long DamageValue)
        {
            GameObject flyDamageGO = GameObjectPoolHelper.GetObjectFromPool("flyDamageValue");
            flyDamageGO.transform.SetParent(GlobalComponent.Instance.Unit);
            self.FlyDamageSet.Add(flyDamageGO);
            flyDamageGO.SetActive(true);

            flyDamageGO.GetComponentInChildren<TextMeshPro>().text = DamageValue <= 0 ? "Miss" : $"-{DamageValue}";
            flyDamageGO.transform.position = startPos;
            flyDamageGO.transform.DOMoveY(startPos.y + 1.5f, 0.8f).onComplete = () =>
            {
                flyDamageGO?.SetActive(false);
                self.FlyDamageSet.Remove(flyDamageGO);
                GameObjectPoolHelper.ReturnObjectToPool(flyDamageGO);
            };

            await ETTask.CompletedTask;
        }
    }
}