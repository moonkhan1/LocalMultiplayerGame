using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Controllers;

namespace UnityProject3.Animation
{
public class CharacterAnimation
{
    Animator _animator;

    public CharacterAnimation(PlayerController entity)
    {
        _animator = entity.GetComponentInChildren<Animator>();
    }

    public void MoveAnimation()
    {

    }
}
}
