using System.Collections.Generic;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Managers
{
    [System.Serializable]
    public class UserSettingsData
    {
        public List<UserSetting> Settings = new List<UserSetting>();

        public void InitialiseDefaultSettingsData(List<SettingsGroupScriptableObject> settingGroups)
        {
            foreach (SettingsGroupScriptableObject settingGroup in settingGroups)
            {
                foreach (SettingTypeScriptableObject setting in settingGroup.Settings)
                {
                    UserSetting newSetting = new UserSetting(setting);
                    Settings.Add(newSetting);
                }
            }
        }
    }
}
