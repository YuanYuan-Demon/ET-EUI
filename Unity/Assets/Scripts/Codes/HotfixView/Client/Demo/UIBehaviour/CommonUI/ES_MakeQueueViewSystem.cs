
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class ES_MakeQueueAwakeSystem : AwakeSystem<ES_MakeQueue,Transform> 
	{
		protected override void Awake(ES_MakeQueue self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_MakeQueueDestroySystem : DestroySystem<ES_MakeQueue> 
	{
		protected override void Destroy(ES_MakeQueue self)
		{
			self.DestroyWidget();
		}
	}
}
