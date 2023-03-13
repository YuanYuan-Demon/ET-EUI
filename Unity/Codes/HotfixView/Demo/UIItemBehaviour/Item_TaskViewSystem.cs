
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_TaskDestroySystem : DestroySystem<Scroll_Item_Task> 
	{
		public override void Destroy( Scroll_Item_Task self )
		{
			self.DestroyWidget();
		}
	}
}
