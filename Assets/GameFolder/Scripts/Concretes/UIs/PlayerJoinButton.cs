using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityProject3.Managers;

namespace UnityProject3.UIs
{
    public class PlayerJoinButton : MonoBehaviour
    {
         Button _button;

        void Awake()
        {
            _button = GetComponent<Button>();
        }

        void OnEnable()
        {
            _button.onClick.AddListener(HandelOnClick);
        }

        void OnDisable()
        {
            _button.onClick.RemoveListener(HandelOnClick);
        }

        void HandelOnClick()
        {
            GameManager.Instance.IncreasePlayerCount();
        }
    }
}