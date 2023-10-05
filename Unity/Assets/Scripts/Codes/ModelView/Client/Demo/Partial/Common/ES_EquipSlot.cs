using UnityEngine.UI;

namespace ET.Client
{
    public partial class ES_EquipSlot
    {
        private Button _EB_Click;
        public Item Equip;
        public EquipPosition EquipPosition;
        public long LastClick;

        public Button EB_Click_Button
        {
            get
            {
                if (this._EB_Click != null)
                {
                    return this._EB_Click;
                }

                this._EB_Click = this.uiTransform.GetComponent<Button>();
                return this._EB_Click;
            }
        }
    }
}