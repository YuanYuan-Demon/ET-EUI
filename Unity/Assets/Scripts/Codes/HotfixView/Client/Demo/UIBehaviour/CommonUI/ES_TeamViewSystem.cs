
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class ES_TeamAwakeSystem : AwakeSystem<ES_Team,Transform> 
	{
		protected override void Awake(ES_Team self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_TeamDestroySystem : DestroySystem<ES_Team> 
	{
		protected override void Destroy(ES_Team self)
		{
			self.DestroyWidget();
		}
	}
}
