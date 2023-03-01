using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Controllers;
using UnityProject3.Abstracts.States;

namespace UnityProject3.States.EnemyStates
{
    public class ChaseState : IState
    {
        float _speed = 10f;
        IEnemyController _enemyController;

        public ChaseState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }
        public void OnEnter()
        {
            Debug.Log($"{nameof(ChaseState)} {nameof(OnEnter)}");
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(ChaseState)} {nameof(OnExit)}");
        }

        public void Tick()
        {
            _enemyController.Mover.MoveAction(_enemyController.Target.position, _speed);
        }
        public void FixedTick()
        {
        }
        public void LateTick()
        {
            _enemyController.Animation.MoveAnimation(_enemyController.Magnitude);
        }
    }
}