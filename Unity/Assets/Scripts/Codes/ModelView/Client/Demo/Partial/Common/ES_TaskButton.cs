using UnityEngine.UI;

namespace ET.Client
{
    public partial class ES_TaskButton
    {
        private Toggle _ET_On_Toggle;

        public Toggle ET_On_Toggle
        {
            get
            {
                if (this._ET_On_Toggle != null)
                {
                    return this._ET_On_Toggle;
                }

                this._ET_On_Toggle = this.uiTransform.GetComponent<Toggle>();
                return this._ET_On_Toggle;
            }
        }
    }
}