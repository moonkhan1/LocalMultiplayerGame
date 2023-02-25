using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject3.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Health info", menuName = "Info/Health Information", order = 51)]
    public class HealthSO : ScriptableObject
    {
        [SerializeField] int _maxHealth;
        public int MaxHealth => _maxHealth;
    }
}