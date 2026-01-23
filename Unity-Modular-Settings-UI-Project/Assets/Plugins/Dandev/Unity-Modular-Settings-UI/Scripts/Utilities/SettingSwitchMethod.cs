namespace Dandev.Unity_Modular_Settings_UI.Scripts.Utilities
{
    /// <summary>
    /// Represents the methods available for switching or modifying a setting value in the UI.
    /// </summary>
    public enum SettingSwitchMethod
    {
        /// <summary>
        /// Toggles the setting on and off
        /// </summary>
        Toggle,
        
        /// <summary>
        /// Slider for numeric values between 2 values
        /// </summary>
        Slider,
        
        /// <summary>
        /// Dropdown for selecting an option from a list of options
        /// </summary>
        Options_Dropdown,
        
        /// <summary>
        /// Selector for selecting an option from a list of options (scroll left and right)
        /// </summary>
        Options_Selector,
    }
}
