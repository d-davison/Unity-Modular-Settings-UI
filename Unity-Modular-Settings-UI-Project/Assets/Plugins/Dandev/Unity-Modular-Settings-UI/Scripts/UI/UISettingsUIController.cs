using System.Collections.Generic;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    /// <summary>
    /// Controls the opening and closing of the settings panels.
    /// </summary>
    public class UISettingsUIController : MonoBehaviour
    {
        [SerializeField] private List<UISettingsPanel> panels = new List<UISettingsPanel>();

        private void OnEnable()
        {
            OpenPanel(0);
        }

        public void OpenPanel(int panelIndex)
        {
            foreach (var panel in panels)
            {
                panel.gameObject.SetActive(false);
            }
            
            panels[panelIndex].gameObject.SetActive(true);
        }
    }
}
