using UnityEngine;
using UnityEngine.UI;
using UnityProject3.Managers;
using System;

namespace UnityProject3.UIs
{
    public class StartButton : MonoBehaviour
    {
        Button _button;

        void Awake() 
        {
            _button = GetComponent<Button>();    
        }

        void OnEnable() {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        void OnDisable() {
            _button.onClick.RemoveListener(HandleOnButtonClicked);    
        }

        private void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadScene("Game");
            
        }
    }
}