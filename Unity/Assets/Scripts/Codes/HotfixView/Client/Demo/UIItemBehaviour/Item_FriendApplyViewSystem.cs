
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class Scroll_Item_FriendApplyDestroySystem : DestroySystem<Scroll_Item_FriendApply> 
	{
		protected override void Destroy( Scroll_Item_FriendApply self )
		{
			self.DestroyWidget();
		}
	}
}
