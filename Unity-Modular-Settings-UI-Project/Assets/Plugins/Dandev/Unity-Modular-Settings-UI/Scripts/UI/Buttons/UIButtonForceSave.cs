using Dandev.Unity_Modular_Settings_UI.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Dandev.Unity_Modular_Settings_UI.Scripts.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class UIButtonForceSave : MonoBehaviour
    {
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }
        
        private void OnButtonClick()
        {
            UserSettings.Instance.Save();
        }
    }
}
