using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityProject3.Abstracts.Combats;
using UnityProject3.Abstracts.Controllers;
using UnityProject3.Abstracts.Movements;
using UnityProject3.Animation;

namespace UnityProject3.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        // [SerializeField] Transform _playerPref;
        IMover _mover;
        IHealth _health;
        CharacterAnimation _anim;
        InventoryController _inventoryController;
        NavMeshAgent _navMeshAgent;
        Transform _targetTransform;
        Transform _transform;
        private bool _canAttack;

        void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _anim = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            _inventoryController = GetComponent<InventoryController>();

        }
        void Start()
        {
            _transform = GetComponent<Transform>();
            _targetTransform = FindObjectOfType<PlayerController>().transform;
        }

        void Update()
        {
            if (_health.IsDead) return;

            _mover.MoveAction(_targetTransform.position, 10f);
            _canAttack = Vector3.Distance(_targetTransform.position, _transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;

        }

        private void FixedUpdate()
        {
            if (_canAttack)
            {
                _inventoryController.CurrentWeapon.Attack();
            }
        }
        void LateUpdate()
        {
            _anim.MoveAnimation(_navMeshAgent.velocity.magnitude);
            _anim.AttackAnimation(_canAttack);
        }
    }
}