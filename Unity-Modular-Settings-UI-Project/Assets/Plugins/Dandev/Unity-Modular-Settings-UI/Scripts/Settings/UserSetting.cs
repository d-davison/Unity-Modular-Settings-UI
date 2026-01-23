using System;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using Dandev.Unity_Modular_Settings_UI.Scripts.Managers;
using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Settings
{
    [Serializable]
    public class UserSetting
    {
        public SettingType settingType;
        public SettingDataType settingDataType;
        
        //TODO: Remove this once we have a better way of handling this data. We don't want this hanging around.
        [NonSerialized] public SettingTypeScriptableObject SettingTypeScriptableObject;
        
        public UserSetting() { }
        
        /// <summary>
        /// Initialise the setting from the SettingTypeScriptableObject. Used when we want to create a new instance of the setting.
        /// </summary>
        /// <param name="settingTypeScriptableObject"></param>
        public virtual void InitialiseFromScriptableObject(SettingTypeScriptableObject settingTypeScriptableObject)
        {
            SettingTypeScriptableObject = settingTypeScriptableObject;
            settingType = settingTypeScriptableObject.Type;
            settingDataType = settingTypeScriptableObject.SettingDataType;
        }

        /// <summary>
        /// Get data from the SettingTypeScriptableObject. Used when we want to load a setting from JSON.
        /// </summary>
        /// <param name="settingTypeScriptableObject"></param>
        public virtual void GetDataFromScriptableObject(SettingTypeScriptableObject settingTypeScriptableObject)
        {
            SettingTypeScriptableObject = settingTypeScriptableObject;
            settingType = settingTypeScriptableObject.Type;
            settingDataType = settingTypeScriptableObject.SettingDataType;
        }
        
        public virtual void ChangeSetting<T>(T newValue)
        {
            UserSettings.Instance.TriggerCallbacks(settingType);
        }
        
        public static UserSetting Create(SettingTypeScriptableObject settingSO, string json = null)
        {
            var targetClass = SettingUtilities.GetClassType(settingSO.SettingDataType, settingSO.Type);

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
