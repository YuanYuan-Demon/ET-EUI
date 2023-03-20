
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class Scroll_Item_EntryDestroySystem : DestroySystem<Scroll_Item_Entry> 
	{
		protected override void Destroy( Scroll_Item_Entry self )
		{
			self.DestroyWidget();
		}
	}
}
