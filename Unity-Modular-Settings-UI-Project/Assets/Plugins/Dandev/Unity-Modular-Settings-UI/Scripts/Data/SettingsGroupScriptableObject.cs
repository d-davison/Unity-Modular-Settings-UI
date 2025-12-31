using System.Collections.Generic;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Data
{
    /// <summary>
    /// Represents a group of settings for use within a modular settings UI system in Unity.
    /// </summary>
    [CreateAssetMenu(fileName = "New Settings Group", menuName = "Settings/New Settings Group")]
    public class SettingsGroupScriptableObject : ScriptableObject
    {
        public List<SettingTypeScriptableObject> Settings = new List<SettingTypeScriptableObject>();
    }
}