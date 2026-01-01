using System;
using Dandev.Unity_Modular_Settings_UI.Scripts.Managers;
using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    public class UISettingsWidget_Slider : UISettingsWidget
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_Text sliderLabel;
        
        private SettingSwitchMethod _settingSwitchMethod;
        private UserSetting_Float _userSettingFloat;
        
        public override void Configure(UserSetting setting)
        {
            base.Configure(setting);
            
            _userSettingFloat = setting as UserSetting_Float;
            if (_userSettingFloat == null)
            {
                Debug.LogError($"UserSetting_Float is null for {setting.settingType}");
                return;
            }
            
            _settingSwitchMethod = setting.SettingTypeScriptableObject.SwitchMethod;
            int maxValue = _settingSwitchMethod switch
            {
                SettingSwitchMethod.Slider_1_to_100 => 100,
                SettingSwitchMethod.Slider_0_to_1   => 1,
    
                SettingSwitchMethod.Toggle or 
                SettingSwitchMethod.Options_Dropdown or 
                SettingSwitchMethod.Options_Selector => 0,
    
                _ => throw new ArgumentOutOfRangeException()
            };
            slider.maxValue = maxValue;
            slider.value = setting.SettingTypeScriptableObject.AsFloat;
            
            slider.onValueChanged.RemoveAllListeners();
            slider.onValueChanged.AddListener(OnSliderValueChanged);
            
            OnSliderValueChanged(setting.SettingTypeScriptableObject.AsFloat);
        }
        
        private void OnDestroy()
        {
            slider.onValueChanged.RemoveAllListeners();
        }

        private void OnSliderValueChanged(float value)
        {
            string sliderText = "";
            
            sliderText = _settingSwitchMethod switch
            {
                SettingSwitchMethod.Slider_1_to_100 => Mathf.RoundToInt(value) + "%",
                SettingSwitchMethod.Slider_0_to_1   => value.ToString("P1"), // Using the 1 decimal place percentage from before
    
                SettingSwitchMethod.Toggle or 
                SettingSwitchMethod.Options_Dropdown or 
                SettingSwitchMethod.Options_Selector => LogWarningAndReturnEmpty(value),
    
                _ => throw new ArgumentOutOfRangeException()
            };
            sliderLabel.text = sliderText;
        }
        
        string LogWarningAndReturnEmpty(float val) 
        {
            Debug.LogWarning("Slider is not compatible with this setting type.");
            return "";
        }
        
    }
}
