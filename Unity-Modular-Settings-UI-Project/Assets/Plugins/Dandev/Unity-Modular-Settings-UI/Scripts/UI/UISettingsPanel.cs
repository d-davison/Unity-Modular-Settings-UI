using System.Collections.Generic;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI
{
    /// <summary>
    /// A modular and self-creating UI panel that displays a list of settings.
    /// </summary>
    public class UISettingsPanel : MonoBehaviour
    {
        [Header("Scene References")]
        [SerializeField] private ScrollRect scrollRect;
        
        [Header("Project References")]
        [SerializeField] private UISettingsHeader headerPrefab;
        [SerializeField] private UISettingsWidget settingPrefab;
        
        [Header("Configuration")]
        [SerializeField] private List<SettingsSection> settingTypes = new List<SettingsSection>();
        
        private readonly bool _configured = false;

        private void OnEnable()
        {
            ConfigurePanel();
        }
        
        private void OnDisable()
        {
            
        }

        private void ConfigurePanel()
        {
            if (_configured)
            {
                return; //We don't want to configure the panel more than once
            }

            foreach (SettingsSection section in settingTypes)
            {
                UISettingsHeader header = Instantiate(headerPrefab, scrollRect.content);
                header.Configure(section.sectionName);

                foreach (var setting in section.settingTypes)
                {
                    UISettingsWidget widget = Instantiate(settingPrefab, scrollRect.content);
                    widget.Configure(setting);
                }
            }
        }
    }

    [System.Serializable]
    public class SettingsSection
    {
        public string sectionName;
        public List<SettingTypeScriptableObject> settingTypes = new List<SettingTypeScriptableObject>();
    }
}
