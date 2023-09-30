namespace ET.Client
{
    [FriendOfAttribute(typeof (ES_Slider))]
    public static class ES_SliderSystem
    {
        public static void InitMax(this ES_Slider self, int max)
        {
            self.Max = max;
            self.SetValue(max);
        }

        public static void ShowDesc(this ES_Slider self, bool show) => self.ET_Desc_TextMeshProUGUI.enabled = show;

        public static void SetValue(this ES_Slider self, int value)
        {
            self.ED_Slider_Slider.value = value;
            self.ET_Desc_TextMeshProUGUI.text = $"{value}/{self.Max}";
        }
    }
}