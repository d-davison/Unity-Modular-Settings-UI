using TMPro;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    public class UISettingsHeader : MonoBehaviour
    {
        [SerializeField] private TMP_Text headerText;
        
        public void Configure(string header)
        {
            headerText.text = header;
        }
    }
}
