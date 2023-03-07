using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityProject3.Managers;

namespace UnityProject3.Helpers
{
    public class WaveDisplay : MonoBehaviour
    {
        private TMP_Text _waveText;

        private void Awake()
        {
            _waveText = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            GameManager.Instance.NextWave += HandleOnNextWave;
        }

        private void OnDestroy()
        {
            GameManager.Instance.NextWave -= HandleOnNextWave;
        }

        private void HandleOnNextWave(int waveCount)
        {
            _waveText.text = waveCount.ToString();
        }
    }
}