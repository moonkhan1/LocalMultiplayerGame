using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Controllers;
using UnityProject3.Abstracts.Movements;

namespace UnityProject3.Movements
{
    

public class MoveWithCharacterController : IMover
{
    CharacterController _characterController;

    public MoveWithCharacterController(PlayerController playerController )
    {
        _characterController = playerController.GetComponent<CharacterController>();
    }

    public void MoveAction(Vector3 direction, float moveSpeed)
    {
        if(direction.magnitude == 0f) return;

        Vector3 worldPosition = _characterController.transform.TransformDirection(direction);
        Vector3 movement = worldPosition * Time.deltaTime * moveSpeed;

        _characterController.Move(movement);
    }
}
}