using System;
using System.Collections.Generic;
using System.IO;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
using Dandev.Unity_Modular_Settings_UI.Scripts.Settings;
using Dandev.Unity_Modular_Settings_UI.Scripts.Utilities;
using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Managers
{
    public class UserSettings : MonoBehaviour
    {
        #region Singleton
        public static UserSettings Instance;
        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitialiseUserSettingsData();
            }
        }
        #endregion
        
        private static readonly string SettingsFilePath = "UserSettings.json";
        
        [SerializeField] private List<SettingsGroupScriptableObject> settingGroups = new List<SettingsGroupScriptableObject>();
        
        private UserSettingsData _userSettingsData;
        
        public T GetSetting<T>(SettingType settingType) where T : UserSetting
        {
            return _userSettingsData.GetSetting<T>(settingType);
        }

        public bool GetBool(SettingType type) => GetSetting<UserSetting_Bool>(type)?.Value ?? false;
        public float GetFloat(SettingType type) => GetSetting<UserSetting_Float>(type)?.Value ?? 0f;
        public int GetInt(SettingType type) => GetSetting<UserSetting_MultipleChoice>(type)?.Value ?? 0;
        public string GetString(SettingType type) => GetSetting<UserSetting_String>(type)?.Value ?? string.Empty;
        
        private void InitialiseUserSettingsData()
        {
            string filePath = Path.Combine(Application.persistentDataPath, SettingsFilePath);
            Debug.Log($"Loading settings from file: {filePath}");

            if (File.Exists(filePath))
            {
                try
                {
                    _userSettingsData = new UserSettingsData();
                    _userSettingsData.LoadFromJson(File.ReadAllText(filePath), settingGroups);
                }
                catch (Exception e)
                {
                    Debug.LogError("Failed to load settings file.");
                    Console.WriteLine(e);
                    
                    InitialiseDefaultSettingsData();
                    throw;
                }
            }
            else
            {
                InitialiseDefaultSettingsData();
            }
        }
        
        private void InitialiseDefaultSettingsData()
        {
            _userSettingsData = new UserSettingsData();
            _userSettingsData.InitialiseDefaultSettingsData(settingGroups);
            Debug.Log("Default settings data initialised.");
            
            Save();
        }
        
        public void Save()
        {
            string filePath = Path.Combine(Application.persistentDataPath, SettingsFilePath);
            Debug.Log($"Saving settings to file: {filePath}");
            
            File.WriteAllText(filePath, _userSettingsData.ToJson());
        }
    }
}
