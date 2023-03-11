using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Controllers;
using UnityProject3.Abstracts.States;

namespace UnityProject3.States.EnemyStates
{
    public class AttackState : IState
    {
        IEnemyController _enemyController;
        public AttackState(IEnemyController enemyController)
        {
            _enemyController = enemyController;
        }

        public void OnEnter()
        {
            Debug.Log($"{nameof(AttackState)} {nameof(OnEnter)}");
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(AttackState)} {nameof(OnExit)}");
            _enemyController.Animation.AttackAnimation(false);
        }

        public void Tick()
        {
            // Look at target
            _enemyController.transform.LookAt(_enemyController.Target);
            _enemyController.transform.eulerAngles = new Vector3(0f, _enemyController.transform.eulerAngles.y, 0f);
        }
        public void FixedTick()
        {
            _enemyController.Inventory.CurrentWeapon.Attack();
            _enemyController.FindNearestTarget();
        }

        public void LateTick()
        {
            _enemyController.Animation.AttackAnimation(true);
        }
    }
}