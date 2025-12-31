using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Data
{
    /// <summary>
    /// A ScriptableObject representing a configurable setting within the settings UI.
    /// </summary>
    [CreateAssetMenu(fileName = "New Setting", menuName = "Settings/New Setting")]
    public class SettingTypeScriptableObject : ScriptableObject
    {
        [Header("Naming & Description (Localization Support Coming Soon!")]
        //Replace this for localization tables
        public string DisplayName = "New Setting";
        public string Description = "The Setting Description";
        
        [Header("Configuration")]
        public SettingType Type = SettingType.MasterVolume;
        public SettingSwitchMethod SwitchMethod = SettingSwitchMethod.Toggle;
        public SettingSaveMethod SaveMethod = SettingSaveMethod.InstantSave;
        public SettingImpact Impact = SettingImpact.None;
        
        [Header("Values and Default Values")]
        public SettingDataType SettingDataType = SettingDataType.Bool;
        public bool AsBool = true;
        public float AsFloat = 0f;
        public int AsInt = 0;
        public string AsString = "";
    }
}
