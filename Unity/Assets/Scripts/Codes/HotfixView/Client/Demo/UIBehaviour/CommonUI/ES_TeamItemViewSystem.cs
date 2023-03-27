
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class ES_TeamItemAwakeSystem : AwakeSystem<ES_TeamItem,Transform> 
	{
		protected override void Awake(ES_TeamItem self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_TeamItemDestroySystem : DestroySystem<ES_TeamItem> 
	{
		protected override void Destroy(ES_TeamItem self)
		{
			self.DestroyWidget();
		}
	}
}
