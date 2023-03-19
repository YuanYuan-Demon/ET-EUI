
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class DlgAdventureViewComponentAwakeSystem : AwakeSystem<DlgAdventureViewComponent> 
	{
		protected override void Awake(DlgAdventureViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgAdventureViewComponentDestroySystem : DestroySystem<DlgAdventureViewComponent> 
	{
		protected override void Destroy(DlgAdventureViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
