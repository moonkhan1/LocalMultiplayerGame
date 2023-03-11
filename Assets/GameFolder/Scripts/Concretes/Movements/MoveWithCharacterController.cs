using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Controllers;
using UnityProject3.Abstracts.Movements;
using UnityProject3.Abstracts.Controllers;
using UnityProject3.Managers;

namespace UnityProject3.Movements
{
    

public class MoveWithCharacterController : IMover
{
    CharacterController _characterController;

    public MoveWithCharacterController(IEntityController entityController )
    {
        _characterController = entityController.transform.GetComponent<CharacterController>();
    }

    public void MoveAction(Vector3 direction, float moveSpeed)
    {
        if (direction.magnitude == 0f)
        {
            SoundManager.Instance.PlayerMoveSound.Play();
            return;
        }
        Vector3 worldPosition = _characterController.transform.TransformDirection(direction);
        Vector3 movement = worldPosition * Time.deltaTime * moveSpeed;

        _characterController.Move(movement);
        if(SoundManager.Instance.PlayerMoveSound.isPlaying) return;
        
    }
}
}