using System;
using System.Collections.Generic;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;
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
        [SerializeField] private UISettingsWidget_Dropdown dropdownPrefab;
        [SerializeField] private UISettingsWidget_Slider sliderPrefab;
        [SerializeField] private UISettingsWidget_Toggle togglePrefab;
        [SerializeField] private UISettingsWidget_Selector selectorPrefab;
        
        [Header("Configuration")]
        public List<SettingsGroupScriptableObject> settingGroups = new List<SettingsGroupScriptableObject>();
        
        private bool _configured = false;

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

            _configured = true;

            foreach (SettingsGroupScriptableObject section in settingGroups)
            {
                UISettingsHeader header = Instantiate(headerPrefab, scrollRect.content);
                header.Configure(section.name); //TODO better way to get the name

                foreach (SettingTypeScriptableObject setting in section.Settings)
                {
                    UISettingsWidget prefab = null;
                    
                    switch (setting.SwitchMethod)
                    {
                        case SettingSwitchMethod.Toggle:
                            prefab = togglePrefab;
                            break;
                        case SettingSwitchMethod.Slider_1_to_100:
                            prefab = sliderPrefab;
                            break;
                        case SettingSwitchMethod.Slider_0_to_1:
                            prefab = sliderPrefab;
                            break;
                        case SettingSwitchMethod.Options_Dropdown:
                            prefab = dropdownPrefab;
                            break;
                        case SettingSwitchMethod.Options_Selector:
                            prefab = selectorPrefab;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    
                    UISettingsWidget widget = Instantiate(prefab, scrollRect.content);
                    widget.Configure(setting);
                }
            }
        }
    }
}
