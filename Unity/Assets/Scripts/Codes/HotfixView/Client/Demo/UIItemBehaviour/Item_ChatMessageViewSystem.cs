
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class Scroll_Item_ChatMessageDestroySystem : DestroySystem<Scroll_Item_ChatMessage> 
	{
		protected override void Destroy( Scroll_Item_ChatMessage self )
		{
			self.DestroyWidget();
		}
	}
}
