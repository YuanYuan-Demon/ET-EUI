
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ObjectSystem]
	public class ES_SliderAwakeSystem : AwakeSystem<ES_Slider,Transform> 
	{
		protected override void Awake(ES_Slider self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ES_SliderDestroySystem : DestroySystem<ES_Slider> 
	{
		protected override void Destroy(ES_Slider self)
		{
			self.DestroyWidget();
		}
	}
}
