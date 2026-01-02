using Dandev.Unity_Modular_Settings_UI.Scripts.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    public class UISettingsWidget_Selector : UISettingsWidget
    {
        [SerializeField] private TMP_Text currentOptionLabel;
        [SerializeField] private Button leftArrowButton;
        [SerializeField] private Button rightArrowButton;
        
        public override void Configure(UserSetting setting)
        {
            base.Configure(setting);
            
            
        }
    }
}
