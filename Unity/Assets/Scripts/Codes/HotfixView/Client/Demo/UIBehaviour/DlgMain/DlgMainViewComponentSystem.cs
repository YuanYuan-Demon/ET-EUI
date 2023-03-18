
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class DlgMainViewComponentAwakeSystem : AwakeSystem<DlgMainViewComponent> 
	{
		protected override void Awake(DlgMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgMainViewComponentDestroySystem : DestroySystem<DlgMainViewComponent> 
	{
		protected override void Destroy(DlgMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
