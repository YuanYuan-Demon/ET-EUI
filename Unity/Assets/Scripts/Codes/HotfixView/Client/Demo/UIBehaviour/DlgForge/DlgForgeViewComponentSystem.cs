
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class DlgForgeViewComponentAwakeSystem : AwakeSystem<DlgForgeViewComponent> 
	{
		protected override void Awake(DlgForgeViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgForgeViewComponentDestroySystem : DestroySystem<DlgForgeViewComponent> 
	{
		protected override void Destroy(DlgForgeViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
