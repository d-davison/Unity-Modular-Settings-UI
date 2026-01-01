using System;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Managers
{
    [Serializable]
    public class UserSetting
    {
        public SettingType settingType;
        public SettingDataType settingDataType;
        
        [NonSerialized] public SettingTypeScriptableObject SettingTypeScriptableObject;
        
        public UserSetting(SettingTypeScriptableObject settingTypeScriptableObject)
        {
            SettingTypeScriptableObject = settingTypeScriptableObject;
            settingType = settingTypeScriptableObject.Type;
            settingDataType = settingTypeScriptableObject.SettingDataType;
        }
        
        public virtual void ChangeSetting<T>(T newValue)
        {

        }
        
        public static UserSetting Create(SettingTypeScriptableObject setting)
        {
            return setting.SettingDataType switch
            {
                SettingDataType.Bool => new UserSetting_Bool(setting),
                SettingDataType.Float => new UserSetting_Float(setting),
                SettingDataType.Int => new UserSetting_MultipleChoice(setting),
                SettingDataType.String => new UserSetting(setting),
                _ => null
            };
        }
    }
}
