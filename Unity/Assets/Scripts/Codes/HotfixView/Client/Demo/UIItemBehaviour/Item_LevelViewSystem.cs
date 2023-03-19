
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class Scroll_Item_LevelDestroySystem : DestroySystem<Scroll_Item_Level> 
	{
		protected override void Destroy( Scroll_Item_Level self )
		{
			self.DestroyWidget();
		}
	}
}
