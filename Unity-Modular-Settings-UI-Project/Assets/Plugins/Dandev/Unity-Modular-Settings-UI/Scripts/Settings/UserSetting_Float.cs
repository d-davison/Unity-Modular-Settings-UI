using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Settings
{
    public class UserSetting_Float : UserSetting
    {
        public float Value;
        
        public override void InitialiseFromScriptableObject(SettingTypeScriptableObject settingTypeScriptableObject)
        {
            base.InitialiseFromScriptableObject(settingTypeScriptableObject);
            
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
