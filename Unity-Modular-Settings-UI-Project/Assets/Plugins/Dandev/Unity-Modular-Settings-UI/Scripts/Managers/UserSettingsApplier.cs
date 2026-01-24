using System;
using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Managers
{
    public class UserSettingsApplier : MonoBehaviour
    {
        private UserSettings _us;
        
        public void Initialise()
        {
            _us = UserSettings.Instance;

            InitializeGraphicsSettings();
        }

        private void InitializeGraphicsSettings()
        {
            _us.AddTrigger(SettingType.VSync, () =>
            {
                QualitySettings.vSyncCount = _us.GetBool(SettingType.VSync) ? 1 : 0;
            });

            _us.AddTrigger(SettingType.FOV, () =>
            {
                float fov = _us.GetFloat(SettingType.FOV);
                Debug.Log($"FOV changed to {fov}");
                Camera.main.fieldOfView = fov;
            });
            
            _us.AddTrigger(SettingType.FrameRateLimit, () =>
            {
                Application.targetFrameRate = Mathf.RoundToInt(_us.GetFloat(SettingType.FrameRateLimit));
            });
            
            _us.AddTrigger(SettingType.AmbientOcclusion, () =>
            {
                Debug.Log("Ambient Occlusion changed");
                //here you would turn off ambient occlusion (need the post proc package for this)
            });
            
            //QualityPreset,ShadowQuality,TextureQuality,
            _us.AddTrigger(SettingType.QualityPreset, () =>
            {
                Debug.Log($"Quality Preset changed to {_us.GetInt(SettingType.QualityPreset)}");
                QualitySettings.SetQualityLevel(_us.GetInt(SettingType.QualityPreset));
            });
            
            _us.AddTrigger(SettingType.ShadowQuality, () =>
            {
                int level = _us.GetInt(SettingType.ShadowQuality);
                Debug.Log($"Shadow Quality changed to {level}");

                switch (level)
                {
                    case 0: // Low
                        QualitySettings.shadows = ShadowQuality.Disable;
                        break;

                    case 1: // Medium
                        QualitySettings.shadows = ShadowQuality.HardOnly;
                        QualitySettings.shadowResolution = ShadowResolution.Low;
                        QualitySettings.shadowDistance = 30f;
                        QualitySettings.shadowCascades = 0;
                        break;

                    case 2: // High
                        QualitySettings.shadows = ShadowQuality.All;
                        QualitySettings.shadowResolution = ShadowResolution.Medium;
                        QualitySettings.shadowDistance = 60f;
                        QualitySettings.shadowCascades = 2;
                        break;

                    case 3: // Ultra
                        QualitySettings.shadows = ShadowQuality.All;
                        QualitySettings.shadowResolution = ShadowResolution.High;
                        QualitySettings.shadowDistance = 100f;
                        QualitySettings.shadowCascades = 4;
                        break;
                }
                
                Debug.Log($"Shadow Quality set to {QualitySettings.shadows}");
            });
            
            _us.AddTrigger(SettingType.TextureQuality, () =>
            {
                Debug.Log($"Texture Quality changed to {_us.GetInt(SettingType.TextureQuality)}");
                int level = _us.GetInt(SettingType.TextureQuality); // 0..3
                QualitySettings.globalTextureMipmapLimit = Mathf.Clamp(level, 0, 3);
            });
        }
    }
}
