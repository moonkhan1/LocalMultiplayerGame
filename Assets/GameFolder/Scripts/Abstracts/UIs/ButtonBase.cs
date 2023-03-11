using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityProject3.Abstracts.UIs
{
    public abstract class ButtonBase : MonoBehaviour
    {
        protected Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandeOnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandeOnClick);
        }

        protected abstract void HandeOnClick();
    }
}