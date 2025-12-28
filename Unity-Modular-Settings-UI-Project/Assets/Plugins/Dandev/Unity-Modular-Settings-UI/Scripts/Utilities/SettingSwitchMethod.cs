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
        /// Slider for numeric values between 1 and 100
        /// </summary>
        Slider_1_to_100,
        
        /// <summary>
        /// Slider for numeric values between 0 and 1
        /// </summary>
        Slider_0_to_1,
        
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
