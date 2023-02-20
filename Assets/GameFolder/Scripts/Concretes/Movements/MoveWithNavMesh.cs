using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityProject3.Abstracts.Controllers;
using UnityProject3.Abstracts.Movements;

public class MoveWithNavMesh : IMover
{
    NavMeshAgent _navMeshAgent;
    public MoveWithNavMesh(IEntityController entityController)
    {
        _navMeshAgent = entityController.transform.GetComponent<NavMeshAgent>();
    }

    public void MoveAction(Vector3 direction, float moveSpeed)
    {
        _navMeshAgent.SetDestination(direction);
    }
}
