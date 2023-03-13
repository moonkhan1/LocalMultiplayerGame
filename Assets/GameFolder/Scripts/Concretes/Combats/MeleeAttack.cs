using UnityEngine;
using UnityProject3.Abstracts.Combats;
using UnityProject3.Controllers;
using UnityProject3.Managers;
using UnityProject3.ScriptableObjects;

namespace UnityProject3.Combats
{
    public class MeleeAttack : IAttackType
    {
        Transform _transformObject;
        AttackSO _attackSO;
        private PlayerController _player;
        public MeleeAttack(AttackSO attackSO, Transform transformObject)
        {
            _transformObject = transformObject;
            _attackSO = attackSO;
            _player = Object.FindObjectOfType<PlayerController>();
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
                    SoundManager.Instance.MetalCrackSoundSword.Play();
                    if (health.IsDead)
                    {
                        _player?.RaiseOnEnemyKilled();
                        Health tempHealth = collider.transform.GetComponent<Health>();
                        Object.Destroy(tempHealth);
                    }
                    
                }
            }
        
        }

        
    }
}