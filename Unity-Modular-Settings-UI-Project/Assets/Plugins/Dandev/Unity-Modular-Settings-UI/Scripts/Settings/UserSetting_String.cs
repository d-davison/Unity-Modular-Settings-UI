using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Settings
{
    public class UserSetting_String : UserSetting
    {
        public string Value;
        
        public override void InitialiseFromScriptableObject(SettingTypeScriptableObject settingTypeScriptableObject, bool setValue)
        {
            base.InitialiseFromScriptableObject(settingTypeScriptableObject, setValue);
            Value = settingTypeScriptableObject.AsString;
            ChangeSetting(Value);
        }

        public override void ChangeSetting<T>(T newValue)
        {
            if (newValue is string value)
            {
                Value = value;
            }
            else
            {
                Debug.LogError($"Invalid type for UserSetting_String {settingType}");
            }
            
            base.ChangeSetting(newValue);
        }
    }
}