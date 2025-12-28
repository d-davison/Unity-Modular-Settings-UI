using UnityEngine;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.Managers
{
    public class Settings : MonoBehaviour
    {
        #region Singleton
        public static Settings Instance;
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
            }
        }
        #endregion
    }
}
