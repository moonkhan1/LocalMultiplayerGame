using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityProject3.Abstracts.Combats;
using UnityProject3.Controllers;
using UnityProject3.Managers;
using UnityProject3.ScriptableObjects;

namespace UnityProject3.Combats
{
    public class RangeAttack : IAttackType
    {
        Camera _camera;
        AttackSO _attackSO;
        private PlayerController _player;

        public RangeAttack(Transform transformObject, AttackSO attackSO)
        {
            _camera = transformObject.GetComponent<Camera>();
            _attackSO = attackSO;
            _player = Object.FindObjectOfType<PlayerController>();
        }
        public void AttackAction()
        {
            Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f); // Ray tam olaraq ekranin ortasinda gorunsun

            SoundManager.Instance.Play("Laser");
            if (Physics.Raycast(ray, out RaycastHit hit, _attackSO.ValueForDistance, _attackSO.LayerMask))
            {
                if (hit.collider.TryGetComponent(out IHealth health))
                {
                    health.TakeDamage(_attackSO.Damage);
                    SoundManager.Instance.MetalCrackSoundBullet.Play();
                    if (health.IsDead)
                    {
                        _player?.RaiseOnEnemyKilled();
                        Health tempHealth = hit.transform.GetComponent<Health>();
                        Object.Destroy(tempHealth);
                    }
                }
            }
        }
    }
}
