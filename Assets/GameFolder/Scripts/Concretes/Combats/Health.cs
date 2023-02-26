using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Combats;
using UnityProject3.ScriptableObjects;

namespace UnityProject3.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] HealthSO _healthInfo;
        int _currentHealth;
        public bool IsDead => _currentHealth <= 0;
        public event System.Action<int,int> OnHitTaken;

        void Awake() 
        {
            _currentHealth = _healthInfo.MaxHealth;
        }
        public void TakeDamage(int damage)
        {
            if (IsDead) return;

            _currentHealth -= damage;
            OnHitTaken?.Invoke(_currentHealth, _healthInfo.MaxHealth);
        }
    }
}