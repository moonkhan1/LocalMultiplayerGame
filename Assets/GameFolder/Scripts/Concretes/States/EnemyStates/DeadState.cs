using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.States;

namespace UnityProject3.States.EnemyStates
{
    public class DeadState : IState
    {
        public void OnEnter()
        {
            Debug.Log($"{nameof(DeadState)} {nameof(OnEnter)}");
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(DeadState)} {nameof(OnExit)}");
        }

        public void Tick()
        {
            Debug.Log(nameof(DeadState));
        }

        public void FixedTick()
        {

        }
        public void LateTick()
        {
            
        }
    }
}