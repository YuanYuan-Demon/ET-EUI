
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class Scroll_Item_FriendDestroySystem : DestroySystem<Scroll_Item_Friend> 
	{
		protected override void Destroy( Scroll_Item_Friend self )
		{
			self.DestroyWidget();
		}
	}
}
