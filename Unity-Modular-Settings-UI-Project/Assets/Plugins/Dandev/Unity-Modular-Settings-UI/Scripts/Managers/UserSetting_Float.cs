using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Managers
{
    public class UserSetting_Float : UserSetting
    {
        public float Value;
        
        public UserSetting_Float(SettingTypeScriptableObject settingTypeScriptableObject) : base(
            settingTypeScriptableObject)
        {
            Value = settingTypeScriptableObject.AsFloat;
        }

        public override void ChangeSetting<T>(T newValue)
        {
            if (newValue is float value)
            {
                Value = value;
            }
            else
            {
                Debug.LogError($"Invalid type for UserSetting_Float {settingType}");
            }
            
            base.ChangeSetting(newValue);
        }
    }
}
