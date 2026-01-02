using System;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Settings
{
    [Serializable]
    public class UserSetting
    {
        public SettingType settingType;
        public SettingDataType settingDataType;
        
        [NonSerialized] public SettingTypeScriptableObject SettingTypeScriptableObject;
        
        public UserSetting() { }
        
        public virtual void InitialiseFromScriptableObject(SettingTypeScriptableObject settingTypeScriptableObject)
        {
            SettingTypeScriptableObject = settingTypeScriptableObject;
            settingType = settingTypeScriptableObject.Type;
            settingDataType = settingTypeScriptableObject.SettingDataType;
        }
        
        public virtual void ChangeSetting<T>(T newValue)
        {

        }
        
        public static UserSetting Create(SettingTypeScriptableObject settingSO, string json = null)
        {
            var targetClass = SettingUtilities.GetClassType(settingSO.SettingDataType);

            UserSetting setting;
            if (string.IsNullOrEmpty(json))
            {
                // Scenario 1: Create new instance
                setting = (UserSetting)Activator.CreateInstance(targetClass, settingSO);
                setting.InitialiseFromScriptableObject(settingSO);
            }
            else
            {
                // Scenario 2: Load from JSON
                setting = (UserSetting)UnityEngine.JsonUtility.FromJson(json, targetClass);
            }

            if (setting != null)
            {
                setting.SettingTypeScriptableObject = settingSO;
            }

            return setting;
        }
    }
}
