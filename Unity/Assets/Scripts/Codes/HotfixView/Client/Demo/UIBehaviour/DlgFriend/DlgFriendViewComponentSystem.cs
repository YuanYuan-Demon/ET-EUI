
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class DlgFriendViewComponentAwakeSystem : AwakeSystem<DlgFriendViewComponent> 
	{
		protected override void Awake(DlgFriendViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgFriendViewComponentDestroySystem : DestroySystem<DlgFriendViewComponent> 
	{
		protected override void Destroy(DlgFriendViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
