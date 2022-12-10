﻿namespace ET
{
    public static class ES_AddAttributeSystem
    {
        public static void RegisterNumericType(this ES_AddAttribute self, int numericType)
        {
            self.EB_AddAttributeButton.AddListener(() => self.OnAddAttribute(numericType));
        }

        public static void Refresh(this ES_AddAttribute self, int numericType, bool dirty = false)
        {
            var numericComponent = UnitHelper.GetMyUnitNumericComponentFromCurScene(self.ZoneScene().CurrentScene());
            var value = numericComponent.GetAsLong(numericType);
            PlayerNumericConfig config = PlayerNumericConfigCategory.Instance.Get(numericType);
            self.ET_AttributeNameTextMeshProUGUI.text = $"{config.Name}: ";
            self.ET_AttributeValueTextMeshProUGUI.text = dirty ?
                $"<color=#29BA29>{value}</color>" :
                $"{value}";
        }

        private static void OnAddAttribute(this ES_AddAttribute self, int numericType)
        {
            var numericComponent = UnitHelper.GetMyUnitNumericComponentFromCurScene(self.ZoneScene().CurrentScene());
            var points = numericComponent.GetAsLong(NumericType.AttributePoints);
            if (points > 0)
            {
                Game.EventSystem.Publish(new EventType.AddAttribute()
                {
                    ZoneScene = self.ZoneScene(),
                    NumericType = numericType,
                    AddValue = 1
                });
            }
        }
    }
}