
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_ChatMessageDestroySystem : DestroySystem<Scroll_Item_ChatMessage> 
	{
		public override void Destroy( Scroll_Item_ChatMessage self )
		{
			self.DestroyWidget();
		}
	}
}
