using System.Collections.Generic;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Settings
{
    public class UserSetting_Int : UserSetting
    {
        public int Value;
        public string ValueAsString;
        
        protected List<string> _options;
        
        public override void InitialiseFromScriptableObject(SettingTypeScriptableObject settingTypeScriptableObject)
        {
            base.InitialiseFromScriptableObject(settingTypeScriptableObject);
            Value = settingTypeScriptableObject.AsInt;
        }

        public override void ChangeSetting<T>(T newValue)
        {
            if (newValue is int value)
            {
                Value = value;

                if (value >= 0 && value < _options.Count)
                {
                    ValueAsString = _options[value];
                }
                else
                {
                    Debug.LogError($"Invalid value for UserSetting_MultipleChoice {settingType}. " +
                                   $"Tried to assign index {value} but only {_options.Count} options are available (valid indices 0 to {_options.Count - 1}).");
                }
            }
            else
            {
                Debug.LogError($"Invalid type for UserSetting_MultipleChoice {settingType}");
            }
            
            base.ChangeSetting(newValue);
        }

        public virtual List<string> GetOptions()
        {
            _options ??= new List<string>();
            return _options;
        }
    }
}
