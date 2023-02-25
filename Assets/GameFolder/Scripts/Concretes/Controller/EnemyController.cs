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
    [SerializeField] Transform _playerPref;
    IMover _mover;
    IHealth _health;
    CharacterAnimation _anim;
    NavMeshAgent _navMeshAgent;

    void Awake() {
        _mover = new MoveWithNavMesh(this);    
        _anim = new CharacterAnimation(this);
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _health = GetComponent<IHealth>();
    }

    void Update()
    {
        if(_health.IsDead) return;
        
        _mover.MoveAction(_playerPref.position, 10f);
    }
    void LateUpdate() 
    {
        _anim.MoveAnimation(_navMeshAgent.velocity.magnitude);
    }
}
}