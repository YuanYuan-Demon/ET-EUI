
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class DlgEquipViewComponentAwakeSystem : AwakeSystem<DlgEquipViewComponent> 
	{
		protected override void Awake(DlgEquipViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgEquipViewComponentDestroySystem : DestroySystem<DlgEquipViewComponent> 
	{
		protected override void Destroy(DlgEquipViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
