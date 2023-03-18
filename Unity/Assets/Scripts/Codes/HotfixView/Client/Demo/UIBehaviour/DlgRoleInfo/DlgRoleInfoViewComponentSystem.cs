
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class DlgRoleInfoViewComponentAwakeSystem : AwakeSystem<DlgRoleInfoViewComponent> 
	{
		protected override void Awake(DlgRoleInfoViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgRoleInfoViewComponentDestroySystem : DestroySystem<DlgRoleInfoViewComponent> 
	{
		protected override void Destroy(DlgRoleInfoViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
