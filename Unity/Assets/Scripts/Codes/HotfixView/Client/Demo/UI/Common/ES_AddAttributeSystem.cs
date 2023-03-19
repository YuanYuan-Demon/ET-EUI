namespace ET.Client
{
    public static class ES_AddAttributeSystem
    {
        private static void OnAddAttribute(this ES_AddAttribute self, int numericType)
        {
            var numericComponent = self.ClientScene().GetMyNumericComponent();
            var points = numericComponent.GetAsLong(NumericType.AttributePoints);
            if (points > 0)
            {
                EventSystem.Instance.Publish(self.ClientScene(),
                    new EventType.AddAttribute()
                    {
                        ZoneScene = self.ClientScene(),
                        NumericType = numericType,
                        AddValue = 1
                    });
            }
        }

        public static void RegisterNumericType(this ES_AddAttribute self, int numericType)
        {
            self.EB_AddAttributeButton.AddListener(() => self.OnAddAttribute(numericType));
        }

        public static void Refresh(this ES_AddAttribute self, int numericType, bool dirty = false)
        {
            var numericComponent = self.ClientScene().GetMyNumericComponent();
            var value = numericComponent.GetAsLong(numericType);
            PlayerNumericConfig config = PlayerNumericConfigCategory.Instance.Get(numericType);
            self.ET_AttributeNameTextMeshProUGUI.text = $"{config.Name}: ";
            self.ET_AttributeValueTextMeshProUGUI.text = dirty ?
                $"<color=#29BA29>{value}</color>" :
                $"{value}";
        }
    }
}