
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class Scroll_Item_RoleInfoDestroySystem : DestroySystem<Scroll_Item_RoleInfo> 
	{
		protected override void Destroy( Scroll_Item_RoleInfo self )
		{
			self.DestroyWidget();
		}
	}
}
