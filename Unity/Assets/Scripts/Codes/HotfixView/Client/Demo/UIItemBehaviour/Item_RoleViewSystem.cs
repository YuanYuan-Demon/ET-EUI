
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class Scroll_Item_RoleDestroySystem : DestroySystem<Scroll_Item_Role> 
	{
		protected override void Destroy( Scroll_Item_Role self )
		{
			self.DestroyWidget();
		}
	}
}
