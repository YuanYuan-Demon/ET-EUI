
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class DlgRolesViewComponentAwakeSystem : AwakeSystem<DlgRolesViewComponent> 
	{
		protected override void Awake(DlgRolesViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgRolesViewComponentDestroySystem : DestroySystem<DlgRolesViewComponent> 
	{
		protected override void Destroy(DlgRolesViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
