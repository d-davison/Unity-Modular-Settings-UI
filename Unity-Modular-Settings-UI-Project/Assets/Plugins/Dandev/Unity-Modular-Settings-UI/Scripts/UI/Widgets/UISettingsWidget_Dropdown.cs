using Dandev.Unity_Modular_Settings_UI.Scripts.Settings;
using TMPro;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    public class UISettingsWidget_Dropdown : UISettingsWidget
    {
        [SerializeField] private TMP_Dropdown dropdown;
        
        private UserSetting_Int _userSettingInt;
        
        public override void Configure(UserSetting setting)
        {
            if (setting == null)
            {
                Debug.LogError("Setting is null in UISettingsWidget_Dropdown");
                return;
            }
            
            base.Configure(setting);

            dropdown.value = 0;
            dropdown.ClearOptions();
            
            _userSettingInt = setting as UserSetting_Int;
            if (_userSettingInt == null)
            {
                Debug.LogError($"UserSetting_MultipleChoice is null for {setting.settingType}");
                return;
            }
            
            var options = _userSettingInt.GetOptions();
            dropdown.AddOptions(options);
            
            dropdown.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(int value)
        {
            _userSettingInt.ChangeSetting(dropdown.value);
        }
    }
}
