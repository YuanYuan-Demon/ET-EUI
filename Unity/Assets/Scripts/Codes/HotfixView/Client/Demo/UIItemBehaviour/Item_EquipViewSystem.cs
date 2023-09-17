
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class Scroll_Item_EquipDestroySystem : DestroySystem<Scroll_Item_Equip> 
	{
		protected override void Destroy( Scroll_Item_Equip self )
		{
			self.DestroyWidget();
		}
	}
}
