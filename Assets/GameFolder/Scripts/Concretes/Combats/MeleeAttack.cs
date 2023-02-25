using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Combats;
using UnityProject3.ScriptableObjects;

namespace UnityProject3.Combats
{
    public class MeleeAttack : IAttackType
    {
        Transform _transformObject;
        AttackSO _attackSO;
        public MeleeAttack(Transform transformObject, AttackSO attackSO)
        {
            _transformObject = transformObject;
            _attackSO = attackSO;
        }
        public void AttackAction()
        {
            Vector3 attackArea = _transformObject.position;
            Collider[] colliders = Physics.OverlapSphere(attackArea, _attackSO.ValueForDistance, _attackSO.LayerMask);

            foreach (Collider collider in colliders)
            {
                if(collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSO.Damage);
                }
            }
        
        }
    }
}