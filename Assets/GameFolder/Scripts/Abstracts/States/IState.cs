using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject3.Abstracts.States
{
    public interface IState
    {
        void OnEnter();
        void Tick();
        void OnExit();
        void FixedTick();
        void LateTick();
    }
}