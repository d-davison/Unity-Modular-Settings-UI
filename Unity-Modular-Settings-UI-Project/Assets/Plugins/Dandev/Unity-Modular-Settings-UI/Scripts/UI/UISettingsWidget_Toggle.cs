using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    public class UISettingsWidget_Toggle : UISettingsWidget
    {
        [SerializeField] private Toggle toggle;
        
        public override void Configure(SettingTypeScriptableObject setting)
        {
            base.Configure(setting);
            
            //toggle.isOn = setting.
        }
    }
}
