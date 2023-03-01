using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityProject3.Abstracts.Combats;
using UnityProject3.Abstracts.Controllers;
using UnityProject3.Abstracts.Movements;
using UnityProject3.Animation;
using UnityProject3.Combats;
using UnityProject3.States;
using UnityProject3.States.EnemyStates;

namespace UnityProject3.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        IHealth _health;
        NavMeshAgent _navMeshAgent;
        Transform _transform;
        StateMachine _stateMachine;
        public IMover Mover {get; private set;}
        public InventoryController Inventory {get; private set;}
        public CharacterAnimation Animation {get; private set;}
        public Transform Target {get; private set;}
        public Dead Dead {get; private set;}
        public float Magnitude => _navMeshAgent.velocity.magnitude;
        public bool CanAttack => Vector3.Distance(Target.position, _transform.position) <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity == Vector3.zero;


        void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            _stateMachine = new StateMachine();
            Animation = new CharacterAnimation(this);
            Inventory = GetComponent<InventoryController>();
            Mover = new MoveWithNavMesh(this);
            Dead = GetComponent<Dead>();

        }
        void Start()
        {
            Target = FindObjectOfType<PlayerController>().transform;
            _transform = GetComponent<Transform>();
        
            ChaseState chaseState = new ChaseState(this);
            AttackState attackState = new AttackState(this);
            DeadState deadState = new DeadState(this);

            _stateMachine.AddState(chaseState, attackState, () => CanAttack);
            _stateMachine.AddState(attackState, chaseState, () => !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.IsDead);

            _stateMachine.SetState(chaseState);
        }

        void Update()
        {
            _stateMachine.Tick();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedTick();
        }
        void LateUpdate()
        {
            _stateMachine.LateTick();            
        }
    }
}