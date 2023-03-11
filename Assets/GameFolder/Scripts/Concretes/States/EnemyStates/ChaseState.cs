using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Controllers;
using UnityProject3.Abstracts.States;
using UnityProject3.Managers;

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
            _enemyController.Mover.MoveAction(_enemyController.transform.position,0f);
            SoundManager.Instance.EnemyMoveSound.Stop();
        }

        public void Tick()
        {
            _enemyController.Mover.MoveAction(_enemyController.Target.position, _speed);
            if(SoundManager.Instance.EnemyMoveSound.isPlaying) return;
            SoundManager.Instance.EnemyMoveSound.Play();
        }
        public void FixedTick()
        {
            _enemyController.FindNearestTarget();
        }
        public void LateTick()
        {
            _enemyController.Animation.MoveAnimation(_enemyController.Magnitude);
        }
    }
}
