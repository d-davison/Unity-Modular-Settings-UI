using System.Collections.Generic;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Settings
{
    public class UserSetting_Int_Resolution : UserSetting_Int
    {
        private Resolution[] _resolutions;
        
        public override void InitialiseFromScriptableObject(SettingTypeScriptableObject settingTypeScriptableObject, bool setValue)
        {
            base.InitialiseFromScriptableObject(settingTypeScriptableObject, setValue);
        }

        public override void ChangeSetting<T>(T newValue)
        {
            base.ChangeSetting(newValue);
            
            Resolution targetResolution = _resolutions[Value];
            
            Debug.Log($"Setting resolution to {targetResolution.width} x {targetResolution.height}");
            Screen.SetResolution(targetResolution.width, targetResolution.height, Screen.fullScreen);
        }

        public override List<string> GetOptions()
        {
            _resolutions = Screen.resolutions;
            
            _options ??= new List<string>();
            _options.Clear();

            foreach (Resolution res in _resolutions)
            {
                string resOption = res.width + " x " + res.height + " (" + res.refreshRateRatio + "Hz)";
                _options.Add(resOption);
            }

            return _options;
        }
    }
}