using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityProject3.Combats;

namespace UnityProject3.UIs
{
    public class HealthDisplay : MonoBehaviour
    {
        Image _healthImage;
        [SerializeField] Text _health;

        void Awake()
        {
            _healthImage = GetComponent<Image>();
        }

        void OnEnable() 
        {
            Health health = GetComponentInParent<Health>();
            health.OnHitTaken += HandleHit;
        }

        void OnDisable() 
        {
            Health health = GetComponentInParent<Health>();
            if(health == null) return;
            health.OnHitTaken -= HandleHit;
        }

        void HandleHit(int currentHealth, int maxHealth)
        {
            _healthImage.fillAmount = Convert.ToSingle(currentHealth) / Convert.ToSingle(maxHealth);
            _health.text = currentHealth.ToString();
        }
    }
}