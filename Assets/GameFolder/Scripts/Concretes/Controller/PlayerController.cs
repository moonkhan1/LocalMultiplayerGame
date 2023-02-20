using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Inputs;
using UnityProject3.Abstracts.Movements;
using UnityProject3.Movements;
using UnityProject3.Animation;
using UnityProject3.Abstracts.Controllers;

namespace UnityProject3.Controllers
{ 

    public class PlayerController : MonoBehaviour, IEntityController
    {
        [Header("Movement Information")] [SerializeField] float _moveSpeed = 5f;
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] Transform _turnTransform;
        [SerializeField] WeaponController _currentWeapon;

        IInputReader _input;
        IMover _mover;
        CharacterAnimation _animation;
        IRotator _xRotator;
        IRotator _yRotator;

        Vector3 _direction;

        public Transform TurnTransform => _turnTransform;

        void Awake()
        {
            _input = GetComponent<IInputReader>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
        }

        void Update() 
        {
            _direction = _input.Direction;
            _xRotator.RotationAction(_input.Rotation.x, _turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y, _turnSpeed);

            Debug.Log(_input.IsAttackButtonPress);

            if (_input.IsAttackButtonPress)
            {
                _currentWeapon.Attack();
            }
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