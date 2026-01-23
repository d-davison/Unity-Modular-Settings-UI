using System;
using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Managers
{
    public class UserSettingsApplier : MonoBehaviour
    {
        private UserSettings _us;
        
        private void Awake()
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
                //Add your implementation here
                throw new NotImplementedException();
            });
        }
    }
}
