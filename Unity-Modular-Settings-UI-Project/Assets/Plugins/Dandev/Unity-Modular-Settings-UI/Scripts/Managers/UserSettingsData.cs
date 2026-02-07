using System.Collections.Generic;
using System.Linq;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using Dandev.Unity_Modular_Settings_UI.Scripts.Settings;
using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Managers
{
    /// <summary>
    /// Represents the user's settings data, encapsulating information about the available settings and their configurations.
    /// Provides functionality to initialize, link, and retrieve user settings.
    ///
    /// Converts to a JSON string for saving.
    /// </summary>
    [System.Serializable]
    public class UserSettingsData
    {
        private Dictionary<SettingType, UserSetting> _settingsDict;
        private List<SettingTypeScriptableObject> _settingsScriptableObjects;
        
        public void InitialiseDefaultSettingsData(List<SettingsGroupScriptableObject> settingGroups)
        {
            _settingsScriptableObjects = settingGroups.SelectMany(group => group.Settings).ToList();

            if (_settingsDict == null)
            {
                _settingsDict = _settingsScriptableObjects 
                    .Select(s => UserSetting.Create(s)) // Unified call
                    .Where(s => s != null)
                    .ToDictionary(s => s.settingType);
            }
        }

        public void LoadFromJson(string json, List<SettingsGroupScriptableObject> settingGroups)
        {
            JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(json);
            _settingsDict = new Dictionary<SettingType, UserSetting>();
            
            var allSettingsSO = settingGroups.SelectMany(group => group.Settings).ToList();

            foreach (string settingJson in wrapper.serializedSettings)
            {
                UserSetting baseData = JsonUtility.FromJson<UserSetting>(settingJson);
                
                var match = allSettingsSO.Find(s => s.Type == baseData.settingType);
                if (match == null) continue;
                
                UserSetting concreteSetting = UserSetting.Create(match, settingJson);

                concreteSetting.SettingTypeScriptableObject = match;

                if (!_settingsDict.TryAdd(concreteSetting.settingType, concreteSetting))
                {
                    Debug.LogError($"Duplicate setting type found: {concreteSetting.settingType}");
                    return;
                }
            }
        }
        
        public string ToJson()
        {
            JsonWrapper wrapper = new JsonWrapper();
            wrapper.serializedSettings = new List<string>();

            foreach (var kvp in _settingsDict)
            {
                wrapper.serializedSettings.Add(JsonUtility.ToJson(kvp.Value));
            }

            return JsonUtility.ToJson(wrapper);
        }
        
        public T GetSetting<T>(SettingType settingType) where T : UserSetting
        {
            if (_settingsDict.TryGetValue(settingType, out var setting))
            {
                return setting as T;
            }

            return null;
            
            Debug.LogWarning($"Tried to retrieve setting {settingType} but it was null, creating new.");
            
            SettingTypeScriptableObject settingSO = _settingsScriptableObjects.Find(s => s.Type == settingType);
            UserSetting newSetting = UserSetting.Create(settingSO);
            _settingsDict.Add(newSetting.settingType, newSetting);
            
            return newSetting as T;
        }
        
        [System.Serializable]
        private class JsonWrapper
        {
            public List<string> serializedSettings;
        }
    }
    
    
}
