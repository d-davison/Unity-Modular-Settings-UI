using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    public class UISettingsWidget_Dropdown : UISettingsWidget
    {
        [SerializeField] private TMP_Dropdown dropdown;
        
        public override void Configure(SettingTypeScriptableObject setting)
        {
            base.Configure(setting);

            dropdown.value = 0;
            dropdown.ClearOptions();
            //TODO
            //dropdown.AddOptions();
        }
    }
}
