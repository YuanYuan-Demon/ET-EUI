
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class DlgItemPopUpViewComponentAwakeSystem : AwakeSystem<DlgItemPopUpViewComponent> 
	{
		protected override void Awake(DlgItemPopUpViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgItemPopUpViewComponentDestroySystem : DestroySystem<DlgItemPopUpViewComponent> 
	{
		protected override void Destroy(DlgItemPopUpViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
