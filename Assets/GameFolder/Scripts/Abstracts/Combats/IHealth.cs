using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject3.Abstracts.Combats
{
    public interface IHealth
    {
        bool IsDead{get;}
        void TakeDamage(int damage);
    }
}