using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using TMPro;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    public class UISettingsWidget : MonoBehaviour
    {
        [Header("References")]
        public TMP_Text headerText;

        public void Configure(SettingTypeScriptableObject setting)
        {
            headerText.text = setting.DisplayName;
        }
    }
}
