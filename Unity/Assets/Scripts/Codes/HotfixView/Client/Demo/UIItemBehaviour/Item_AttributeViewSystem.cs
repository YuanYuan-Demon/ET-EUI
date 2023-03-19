
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class Scroll_Item_AttributeDestroySystem : DestroySystem<Scroll_Item_Attribute> 
	{
		protected override void Destroy( Scroll_Item_Attribute self )
		{
			self.DestroyWidget();
		}
	}
}
