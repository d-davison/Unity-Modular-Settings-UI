using System.Collections.Generic;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Settings
{
    public class UserSetting_Int_Fidelity : UserSetting_Int
    {
        public override void InitialiseFromScriptableObject(SettingTypeScriptableObject settingTypeScriptableObject, bool setValue)
        {
            base.InitialiseFromScriptableObject(settingTypeScriptableObject, setValue);
        }

        public override void ChangeSetting<T>(T newValue)
        {
            base.ChangeSetting(newValue);
        }

        public override List<string> GetOptions()
        {
            _options ??= new List<string>();
            _options.Clear();
            
            _options.Add("Low");
            _options.Add("Medium");
            _options.Add("High");
            _options.Add("Ultra High");
            
            return base.GetOptions();
        }
    }
}