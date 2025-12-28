using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Data
{
    /// <summary>
    /// A ScriptableObject representing a configurable setting within the settings UI.
    /// </summary>
    [CreateAssetMenu(fileName = "New Default Setting", menuName = "Settings/Default/New Setting")]
    public class SettingTypeScriptableObject : ScriptableObject
    {
        public SettingType Type = SettingType.MasterVolume;
        public SettingSwitchMethod SwitchMethod = SettingSwitchMethod.Toggle;
        public SettingSaveMethod SaveMethod = SettingSaveMethod.InstantSave;
        public SettingImpact Impact = SettingImpact.None;
        
        //Replace this for localization tables
        public string DisplayName = "New Setting";
        public string Description = "The Setting Description";
    }
}
