using System.Collections.Generic;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Settings
{
    public class UserSetting_Int_WindowMode : UserSetting_Int
    {
        private readonly List<FullScreenMode> _modes = new List<FullScreenMode>();
        
        public override void InitialiseFromScriptableObject(SettingTypeScriptableObject settingTypeScriptableObject, bool setValue)
        {
            base.InitialiseFromScriptableObject(settingTypeScriptableObject, setValue);
            ChangeSetting(Value);
        }

        public override void ChangeSetting<T>(T newValue)
        {
            base.ChangeSetting(newValue);
            
            GetOptions();
            FullScreenMode targetMode = _modes[Value];
            Screen.fullScreenMode = targetMode;
            Debug.Log($"Setting window mode to {targetMode}");
        }

        public override List<string> GetOptions()
        {
            if (_options != null && _options.Count > 0)
                return _options;
            
            _options ??= new List<string>();
            _options.Clear();
            
            _modes.Add(FullScreenMode.ExclusiveFullScreen);
            _modes.Add(FullScreenMode.FullScreenWindow);
            _modes.Add(FullScreenMode.Windowed);

            _options.AddRange(_modes.ConvertAll(mode => mode.ToString()));

            return _options;
        }
    }
}