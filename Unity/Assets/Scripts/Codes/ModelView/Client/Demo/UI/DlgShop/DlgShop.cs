namespace ET.Client
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgShop :Entity,IAwake,IUILogic
	{

		public DlgShopViewComponent View { get => this.GetComponent<DlgShopViewComponent>();} 

		 

	}
}
