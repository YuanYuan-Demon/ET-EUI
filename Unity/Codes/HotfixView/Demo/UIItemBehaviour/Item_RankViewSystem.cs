
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_RankDestroySystem : DestroySystem<Scroll_Item_Rank> 
	{
		public override void Destroy( Scroll_Item_Rank self )
		{
			self.DestroyWidget();
		}
	}
}
