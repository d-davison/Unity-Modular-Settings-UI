using Dandev.Unity_Modular_Settings_UI.Scripts.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    public class UISettingsWidget_Toggle : UISettingsWidget
    {
        [SerializeField] private Toggle toggle;
        
        private UserSetting_Bool _userSettingBool;
        
        public override void Configure(UserSetting setting)
        {
            base.Configure(setting);
            
            _userSettingBool = setting as UserSetting_Bool;
            if (_userSettingBool == null)
            {
                Debug.LogError($"UserSetting_Bool is null for {setting.settingType}");
                return;
            }
            
            toggle.isOn = _userSettingBool.Value;
        }
    }
}
