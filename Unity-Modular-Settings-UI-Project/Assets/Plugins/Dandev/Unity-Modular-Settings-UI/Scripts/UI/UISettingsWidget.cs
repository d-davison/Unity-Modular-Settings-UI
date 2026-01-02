using Dandev.Unity_Modular_Settings_UI.Scripts.Settings;
using TMPro;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    public class UISettingsWidget : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text headerText;

        public virtual void Configure(UserSetting setting)
        {
            headerText.text = setting.SettingTypeScriptableObject.DisplayName;
        }
    }
}
