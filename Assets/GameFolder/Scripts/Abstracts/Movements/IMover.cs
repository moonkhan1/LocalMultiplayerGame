using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject3.Abstracts.Movements
{

public interface IMover
{
    void MoveAction(Vector3 direction, float moveSpeed);
}

}