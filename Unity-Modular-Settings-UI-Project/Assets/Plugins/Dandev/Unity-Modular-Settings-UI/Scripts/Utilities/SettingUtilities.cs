using Dandev.Unity_Modular_Settings_UI.Scripts.Settings;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Utilities
{
    public static class SettingUtilities
    {
        public static System.Type GetClassType(SettingDataType dataType, SettingType settingType)
        {
            //We have some special cases for the settings
            switch (settingType)
            {
                case SettingType.Resolution:
                    return typeof(UserSetting_Int_Resolution);
                case SettingType.WindowMode:
                    return typeof(UserSetting_Int_WindowMode);
            }
            
            //Defaults
            return dataType switch
            {
                SettingDataType.Bool => typeof(UserSetting_Bool),
                SettingDataType.Float => typeof(UserSetting_Float),
                SettingDataType.Int => typeof(UserSetting_Int),
                SettingDataType.String => typeof(UserSetting_String),
                _ => typeof(UserSetting)
            };
        } 
    }
}
