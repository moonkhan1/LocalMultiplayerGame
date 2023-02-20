using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Controllers;
using UnityProject3.Abstracts.Movements;

namespace UnityProject3.Controllers
{ 
public class EnemyController : MonoBehaviour, IEntityController
{
    [SerializeField] Transform _playerPref;
    IMover _mover;
    
    void Awake() {
        _mover = new MoveWithNavMesh(this);    
    }

    void Update()
    {
        _mover.MoveAction(_playerPref.position, 10f);
    }
}
}