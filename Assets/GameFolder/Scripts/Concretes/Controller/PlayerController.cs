using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Inputs;
using UnityProject3.Abstracts.Movements;
using UnityProject3.Movements;
using UnityProject3.Animation;
using UnityProject3.Abstracts.Controllers;
using UnityProject3.Abstracts.Combats;
using UnityProject3.Managers;

namespace UnityProject3.Controllers
{ 

    public class PlayerController : MonoBehaviour, IEntityController
    {
        [Header("Movement Information")] 
        [SerializeField] float _moveSpeed = 5f;
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] Transform _turnTransform;
        InventoryController _inventory;
        CharacterAnimation _animation;
        IInputReader _input;
        Vector3 _direction;
        IRotator _xRotator;
        IRotator _yRotator;
        IHealth _health;
        IMover _mover;

        [Header("UI Information")] 
        [SerializeField] GameObject _gameOverPanel;

        public delegate void IsKilled();
        public event IsKilled isEnemyKilled;
        public Transform TurnTransform => _turnTransform;


        void Awake()
        {
            _input = GetComponent<IInputReader>();
            _health = GetComponent<IHealth>();
            _mover = new MoveWithCharacterController(this);
            _animation = new CharacterAnimation(this);
            _xRotator = new RotatorX(this);
            _yRotator = new RotatorY(this);
            _inventory = GetComponent<InventoryController>();
        }

        void OnEnable() 
        {
            
            _health.OnDead += () =>
            {
                _animation.DeadAnimation("Death");
                // _gameOverPanel.SetActive(true);
                GameManager.Instance.ReturnMenuOnAllPlayerDead();
                StartCoroutine(WhenPlayerDead());
            };
            EnemyManager.Instance.Targets.Add(this.transform);
        }

        private void OnDisable()
        {
            EnemyManager.Instance.Targets.Remove(this.transform);
        }

        void Update() 
        {
            if(_health.IsDead) return;
            _direction = _input.Direction;
            _xRotator.RotationAction(_input.Rotation.x, _turnSpeed);
            _yRotator.RotationAction(_input.Rotation.y, _turnSpeed);


            if (_input.IsAttackButtonPress)
            {
                _inventory.CurrentWeapon.Attack();
            }
            if(_input.IsInventoryButtonPressed)
            {
                _inventory.ChangeWeapon();
            }
        }
        void FixedUpdate()
        {
            if(_health.IsDead) return;
            _mover.MoveAction(_direction, _moveSpeed);    
        }

        void LateUpdate() 
        {
            if(_health.IsDead) return;
            _animation.MoveAnimation(_direction.magnitude);    
            _animation.AttackAnimation(_input.IsAttackButtonPress);
        }

        IEnumerator WhenPlayerDead()
        {
            yield return new WaitForSeconds(5f);
            transform.gameObject.SetActive(false);
        }
        
        public void RaiseOnEnemyKilled()
        {
            if (isEnemyKilled != null)
            {
                isEnemyKilled();
            }
        }
    }
    
}