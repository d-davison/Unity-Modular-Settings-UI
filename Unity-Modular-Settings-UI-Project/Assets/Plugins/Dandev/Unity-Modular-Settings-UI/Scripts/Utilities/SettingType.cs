namespace Dandev.Unity_Modular_Settings_UI.Scripts.Utilities
{
    /// <summary>
    /// Represents the various types of settings available
    /// </summary>
    public enum SettingType
    {
        //Audio
        MasterVolume,
        MusicVolume,
        UIVolume,
        SFXVolume,
        AudioOutputDevice,
        
        //Voice
        VoiceVolume,
        AudioInputDevice,
        
        //Graphics
        Resolution,
        WindowMode,
        VSync,
        Brightness,
        QualityPreset,
        AntiAliasingLevel,
        ShadowQuality,
        TextureQuality,
        FrameRateLimit,
        FOV,
        MotionBlur,
        Bloom,
        AmbientOcclusion,
        
        //Gameplay
        Difficulty,
        AutoSave,
        Crosshair,
        
        //Controls (Mouse and Keyboard)
        MouseSensitivity,
        
        //Controls (Gamepad)
        GamepadSensitivity,
        GamepadDeadZone,
        GamepadVibration,
        
        //Localisation
        Language,
        
        //Debug
        FramesPerSecond,
        NetworkGraph,
    }
}
