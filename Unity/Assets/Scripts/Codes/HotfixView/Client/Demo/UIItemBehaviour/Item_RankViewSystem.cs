
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class Scroll_Item_RankDestroySystem : DestroySystem<Scroll_Item_Rank> 
	{
		protected override void Destroy( Scroll_Item_Rank self )
		{
			self.DestroyWidget();
		}
	}
}
