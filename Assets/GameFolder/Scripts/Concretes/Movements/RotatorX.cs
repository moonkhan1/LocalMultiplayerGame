using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Movements;
using UnityProject3.Controllers;

namespace UnityProject3.Movements
{
public class RotatorX : IRotator
{
    PlayerController _playerController;

    public RotatorX(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public void RotationAction(float direction, float speed)
    {
        _playerController.transform.Rotate(Vector3.up * direction * speed * Time.deltaTime);
    }
}
}
