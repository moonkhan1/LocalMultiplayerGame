using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Movements;
using UnityProject3.Animation;
using UnityProject3.Combats;
using UnityProject3.Controllers;

namespace UnityProject3.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        IMover Mover { get; }
        InventoryController Inventory {get;}
        CharacterAnimation Animation {get;}
        Transform Target {get;}
        float Magnitude {get;}
        Dead Dead {get;}
        void FindNearestTarget();
    }
}