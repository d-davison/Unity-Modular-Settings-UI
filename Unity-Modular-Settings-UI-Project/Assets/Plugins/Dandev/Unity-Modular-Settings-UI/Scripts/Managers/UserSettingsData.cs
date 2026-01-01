using System.Collections.Generic;
using System.Linq;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Managers
{
    [System.Serializable]
    public class UserSettingsData
    {
        [SerializeField] private List<UserSetting> settings;
        private Dictionary<SettingType, UserSetting> _settingsDict;


        public void InitialiseDefaultSettingsData(List<SettingsGroupScriptableObject> settingGroups)
        {
            settings = settingGroups
                .SelectMany(group => group.Settings) 
                .Select(UserSetting.Create)
                .Where(s => s != null)
                .ToList();

            _settingsDict = new Dictionary<SettingType, UserSetting>();
            foreach (UserSetting setting in settings)
            {
                if (!_settingsDict.TryAdd(setting.settingType, setting))
                {
                    Debug.LogError($"Duplicate setting type found: {setting.settingType}");
                    continue;
                }
            }
        }
        
        public UserSetting GetSetting(SettingType settingType) => _settingsDict[settingType];
    }
}
