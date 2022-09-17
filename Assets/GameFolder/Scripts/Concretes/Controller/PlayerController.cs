using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Inputs;
using UnityProject3.Abstracts.Movements;
using UnityProject3.Movements;
using UnityProject3.Animation;


namespace UnityProject3.Controllers
{ 

    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Information")] [SerializeField] float _moveSpeed = 5f;

        IInputReader _input;
        IMover _mover;
        CharacterAnimation _animation;

        Vector3 _direction;

        void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
        }

        void Update() 
        {
            _direction = _input.Direction;
        }
        void FixedUpdate()
        {
            _mover.MoveAction(_direction, _moveSpeed);    
        }

        void LateUpdate() 
        {
            _animation.MoveAnimation(_direction.magnitude);    
        }
    }
    
}