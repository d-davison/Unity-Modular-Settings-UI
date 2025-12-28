using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Utilities
{
    /// <summary>
    /// This only really applies for settings that are related to graphics.
    /// 
    /// Represents the potential level of impact or effect that a specific setting may have on the system.
    /// For example, turning the texture settings up and down may have a high impact on the usage of the
    /// CPU and/or the GPU but turning on anti-aliasing may have a low impact.
    /// </summary>
    public enum SettingImpact
    {
        None,
        LowImpact,
        
        MediumImpact,
        
        HighImpact,
    }
}
