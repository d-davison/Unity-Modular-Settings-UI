using Dandev.Unity_Modular_Settings_UI.Scripts.Settings;
using TMPro;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    public class UISettingsWidget_Dropdown : UISettingsWidget
    {
        [SerializeField] private TMP_Dropdown dropdown;
        
        private UserSetting_MultipleChoice _userSettingMultipleChoice;
        
        public override void Configure(UserSetting setting)
        {
            base.Configure(setting);

            dropdown.value = 0;
            dropdown.ClearOptions();
            
            _userSettingMultipleChoice = setting as UserSetting_MultipleChoice;
            if (_userSettingMultipleChoice == null)
            {
                Debug.LogError($"UserSetting_MultipleChoice is null for {setting.settingType}");
                return;
            }
            
            var options = _userSettingMultipleChoice.GetOptions();
            dropdown.AddOptions(_userSettingMultipleChoice.GetOptions());
        }
    }
}
