
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class Scroll_Item_ProductionDestroySystem : DestroySystem<Scroll_Item_Production> 
	{
		protected override void Destroy( Scroll_Item_Production self )
		{
			self.DestroyWidget();
		}
	}
}
