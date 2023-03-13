using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Combats;
using UnityProject3.Combats;

namespace UnityProject3.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Attack info", menuName = "Info/Attack Information", order = 51)]
    public class AttackSO : ScriptableObject
    {
        enum AttackTypeEnum : byte
        {
            Range, Melee
        }
        [SerializeField] AttackTypeEnum _attackType;
        [SerializeField] int _damage = 10;
        [SerializeField] float _valueForDistance = 1f;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] float _attackMaxDelay = 0.25f;
        [SerializeField] AnimatorOverrideController _animatorOverrideController;
        [SerializeField] GameObject _particle;

        public int Damage => _damage;
        public float ValueForDistance => _valueForDistance;
        public LayerMask LayerMask => _layerMask;
        public float AttackDelayTime => _attackMaxDelay;
        public ParticleSystem Particle => _particle.GetComponentInChildren<ParticleSystem>();
        public AnimatorOverrideController AnimatorOverrideController => _animatorOverrideController;

        public IAttackType GetTypeOfAttack(Transform transform)
        {
            if(_attackType == AttackTypeEnum.Range)
            {
                return new RangeAttack(this, transform);
            }
            else
            {
                return new MeleeAttack(this, transform);
            }
        }

    }
}