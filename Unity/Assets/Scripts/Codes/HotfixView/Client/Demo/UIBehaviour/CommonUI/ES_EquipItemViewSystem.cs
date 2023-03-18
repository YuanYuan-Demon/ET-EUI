
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class ES_EquipItemAwakeSystem : AwakeSystem<ES_EquipItem,Transform> 
	{
		protected override void Awake(ES_EquipItem self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_EquipItemDestroySystem : DestroySystem<ES_EquipItem> 
	{
		protected override void Destroy(ES_EquipItem self)
		{
			self.DestroyWidget();
		}
	}
}
