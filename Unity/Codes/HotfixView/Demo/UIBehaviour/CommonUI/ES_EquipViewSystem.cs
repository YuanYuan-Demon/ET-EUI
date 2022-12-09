
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ES_EquipAwakeSystem : AwakeSystem<ES_Equip,Transform> 
	{
		public override void Awake(ES_Equip self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_EquipDestroySystem : DestroySystem<ES_Equip> 
	{
		public override void Destroy(ES_Equip self)
		{
			self.DestroyWidget();
		}
	}
}
