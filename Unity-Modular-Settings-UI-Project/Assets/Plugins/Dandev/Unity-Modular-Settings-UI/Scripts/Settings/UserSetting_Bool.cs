using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Settings
{
    public class UserSetting_Bool : UserSetting
    {
        public bool Value;
        
        public override void InitialiseFromScriptableObject(SettingTypeScriptableObject settingTypeScriptableObject, bool setValue)
        {
            base.InitialiseFromScriptableObject(settingTypeScriptableObject, setValue);
            if (!setValue) return;
            Value = settingTypeScriptableObject.AsBool;
            
            ChangeSetting(Value);
        }

        public override void ChangeSetting<T>(T newValue)
        {
            if (newValue is bool value)
            {
                Value = value;
            }
            else
            {
                Debug.LogError($"Invalid type for UserSetting_Bool {settingType}");
            }
            
            base.ChangeSetting(newValue);
        }
    }
}
