
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class DlgRankViewComponentAwakeSystem : AwakeSystem<DlgRankViewComponent> 
	{
		protected override void Awake(DlgRankViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgRankViewComponentDestroySystem : DestroySystem<DlgRankViewComponent> 
	{
		protected override void Destroy(DlgRankViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
