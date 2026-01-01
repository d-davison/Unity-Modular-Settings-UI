using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Managers
{
    public class UserSetting_Bool : UserSetting
    {
        public bool Value;
        
        public UserSetting_Bool(SettingTypeScriptableObject settingTypeScriptableObject) : base(settingTypeScriptableObject)
        {
            Value = settingTypeScriptableObject.AsBool;
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
