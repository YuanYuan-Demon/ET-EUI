
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class DlgChatViewComponentAwakeSystem : AwakeSystem<DlgChatViewComponent> 
	{
		protected override void Awake(DlgChatViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgChatViewComponentDestroySystem : DestroySystem<DlgChatViewComponent> 
	{
		protected override void Destroy(DlgChatViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
