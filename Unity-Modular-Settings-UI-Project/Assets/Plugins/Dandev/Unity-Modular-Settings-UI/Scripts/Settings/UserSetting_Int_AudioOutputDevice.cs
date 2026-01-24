using System.Collections.Generic;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Settings
{
    public class UserSetting_Int_AudioOutputDevice : UserSetting_Int
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
            return base.GetOptions();
        }
    }
}
