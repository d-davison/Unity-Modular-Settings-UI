using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Managers
{
    public class UserSetting_String : UserSetting
    {
        public string Value;
        
        public UserSetting_String(SettingTypeScriptableObject settingTypeScriptableObject) : base(settingTypeScriptableObject)
        {
            Value = settingTypeScriptableObject.AsString;
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