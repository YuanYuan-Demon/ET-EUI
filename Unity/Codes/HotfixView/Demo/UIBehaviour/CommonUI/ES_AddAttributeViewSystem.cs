
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ES_AddAttributeAwakeSystem : AwakeSystem<ES_AddAttribute,Transform> 
	{
		public override void Awake(ES_AddAttribute self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_AddAttributeDestroySystem : DestroySystem<ES_AddAttribute> 
	{
		public override void Destroy(ES_AddAttribute self)
		{
			self.DestroyWidget();
		}
	}
}
