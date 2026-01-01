using System;
using System.Collections.Generic;
using System.IO;
using Dandev.Unity_Modular_Settings_UI.Scripts.Data;
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
        
        [SerializeField] private List<SettingsGroupScriptableObject> settingGroups = new List<SettingsGroupScriptableObject>();
        
        private UserSettingsData _userSettingsData;

        public UserSetting GetSetting(SettingType settingType)
        {
            return _userSettingsData.GetSetting(settingType);
        }

        private void InitialiseUserSettingsData()
        {
            string fileName = "UserSettings.json";
            string filePath = Path.Combine(Application.persistentDataPath, fileName);
            Debug.Log($"Loading settings from file: {filePath}");

            if (File.Exists(filePath))
            {
                try
                {
                    _userSettingsData = JsonUtility.FromJson<UserSettingsData>(File.ReadAllText(filePath));
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
            
            SaveSettingsToFile();
        }
        
        private void SaveSettingsToFile()
        {
            string fileName = "UserSettings.json";
            string filePath = Path.Combine(Application.persistentDataPath, fileName);
            Debug.Log($"Saving settings to file: {filePath}");
            
            File.WriteAllText(filePath, JsonUtility.ToJson(_userSettingsData));
        }
    }
}
