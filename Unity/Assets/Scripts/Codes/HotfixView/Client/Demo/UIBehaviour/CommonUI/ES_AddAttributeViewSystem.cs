
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class ES_AddAttributeAwakeSystem : AwakeSystem<ES_AddAttribute,Transform> 
	{
		protected override void Awake(ES_AddAttribute self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_AddAttributeDestroySystem : DestroySystem<ES_AddAttribute> 
	{
		protected override void Destroy(ES_AddAttribute self)
		{
			self.DestroyWidget();
		}
	}
}
