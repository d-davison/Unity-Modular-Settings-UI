using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    public class UISettingsWidget_Slider : UISettingsWidget
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_Text sliderLabel;
        
        public override void Configure(SettingTypeScriptableObject setting)
        {
            base.Configure(setting);
        }
    }
}
