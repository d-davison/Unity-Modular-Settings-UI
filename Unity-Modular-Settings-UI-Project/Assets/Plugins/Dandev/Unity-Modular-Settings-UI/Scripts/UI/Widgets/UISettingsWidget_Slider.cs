using System;
using Dandev.Unity_Modular_Settings_UI.Scripts.Settings;
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
            slider.minValue = _userSettingFloat.SettingTypeScriptableObject.AsFloatLowest;
            slider.maxValue = _userSettingFloat.SettingTypeScriptableObject.AsFloatHighest;
            slider.value = _userSettingFloat.Value;
            
            slider.onValueChanged.RemoveAllListeners();
            slider.onValueChanged.AddListener(OnSliderValueChanged);
            
            OnSliderValueChanged(_userSettingFloat.Value);
        }
        
        private void OnDestroy()
        {
            slider.onValueChanged.RemoveAllListeners();
        }

        private void OnSliderValueChanged(float value)
        {
            string sliderText = "";

            sliderText = _userSettingFloat.SettingTypeScriptableObject.AsFloatUsePercentage
                ? Mathf.RoundToInt(value) + "%"
                : Mathf.RoundToInt(value).ToString();
            sliderLabel.text = sliderText;
            
            _userSettingFloat.ChangeSetting(value);
        }
        
        string LogWarningAndReturnEmpty(float val) 
        {
            Debug.LogWarning("Slider is not compatible with this setting type.");
            return "";
        }
        
    }
}
