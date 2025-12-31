using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Managers
{
    public class UserSetting
    {
        public SettingType SettingType;
        public SettingDataType SettingDataType;
        public SettingTypeScriptableObject SettingTypeScriptableObject;
        
        public bool AsBool { get; private set; }
        public float AsFloat  { get; private set; }
        public int AsInt  { get; private set; }
        public string AsString  { get; private set; }
        
        public void ChangeSetting<T>(T newValue)
        {
            // Map the generic type T to our internal SettingDataType enum
            SettingDataType expectedType = typeof(T) switch
            {
                var t when t == typeof(bool) => SettingDataType.Bool,
                var t when t == typeof(float) => SettingDataType.Float,
                var t when t == typeof(int) => SettingDataType.Int,
                var t when t == typeof(string) => SettingDataType.String,
                _ => throw new System.ArgumentException($"Unsupported type: {typeof(T)}")
            };

            // Validate that we are trying to set the correct type for this setting
            if (SettingDataType != expectedType)
            {
                Debug.LogError($"SettingDataType mismatch! Expected {SettingDataType}, but received {expectedType} ({SettingType})");
                return;
            }

            // Perform equality check and assignment
            // We use object.Equals to handle generic comparison safely
            bool hasChanged = expectedType switch
            {
                SettingDataType.Bool => !AsBool.Equals(newValue),
                SettingDataType.Float => !AsFloat.Equals(newValue),
                SettingDataType.Int => !AsInt.Equals(newValue),
                SettingDataType.String => !Equals(AsString, newValue),
                _ => false
            };

            if (!hasChanged) return;

            // Apply the new value to the specific property
            switch (newValue)
            {
                case bool b: AsBool = b; break;
                case float f: AsFloat = f; break;
                case int i: AsInt = i; break;
                case string s: AsString = s; break;
            }

            // Trigger events here!
            Debug.Log($"Setting {SettingType} changed to {newValue}");
        }


        public UserSetting(SettingTypeScriptableObject settingTypeScriptableObject)
        {
            SettingTypeScriptableObject = settingTypeScriptableObject;
            SettingType = settingTypeScriptableObject.Type;
            SettingDataType = settingTypeScriptableObject.SettingDataType;
            AsBool = settingTypeScriptableObject.AsBool;
            AsFloat = settingTypeScriptableObject.AsFloat;
            AsInt = settingTypeScriptableObject.AsInt;
            AsString = settingTypeScriptableObject.AsString;
        }
    }
}
