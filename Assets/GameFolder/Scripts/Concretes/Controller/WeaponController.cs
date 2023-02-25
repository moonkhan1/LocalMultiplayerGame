using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Combats;
using UnityProject3.Combats;
using UnityProject3.ScriptableObjects;

namespace UnityProject3.Controllers
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] bool _canFire;
        [SerializeField] Transform _transformObject;
        [SerializeField] AttackSO _attackSO;

        float _currentTime = 0f;
        IAttackType _attackType;
        public AttackSO AttackSO => _attackSO;

        private void Awake() {
            _attackType = _attackSO.GetTypeOfAttack(_transformObject);
        }

        void Update()
        {
            _currentTime += Time.deltaTime;
            _canFire = _currentTime > _attackSO.AttackDelayTime;
        }

        public void Attack()
        {
            if (!_canFire) return;

            _attackType.AttackAction();
            _currentTime = 0f;
        }
    }
}