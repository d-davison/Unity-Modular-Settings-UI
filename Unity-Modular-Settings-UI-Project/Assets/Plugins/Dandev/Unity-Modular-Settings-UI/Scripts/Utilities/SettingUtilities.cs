using Dandev.Unity_Modular_Settings_UI.Scripts.Settings;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Utilities
{
    public static class SettingUtilities
    {
        public static System.Type GetClassType(SettingDataType dataType)
        {
            return dataType switch
            {
                SettingDataType.Bool => typeof(UserSetting_Bool),
                SettingDataType.Float => typeof(UserSetting_Float),
                SettingDataType.Int => typeof(UserSetting_MultipleChoice),
                SettingDataType.String => typeof(UserSetting_String),
                _ => typeof(UserSetting)
            };
        } 
    }
}
