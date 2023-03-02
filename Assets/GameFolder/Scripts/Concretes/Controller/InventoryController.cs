using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace UnityProject3.Controllers
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] WeaponController[] _weapons;
        public WeaponController CurrentWeapon { get; private set; }
        Animator _animator;
        // [SerializeField] AvatarMask RunAttack;
        // [SerializeField] AvatarMask Normal;
        // [SerializeField] AnimatorController animC;
        byte _index = 0;

        private void Awake() {
            // animC.layers[1].avatarMask = Normal;
            _weapons = GetComponentsInChildren<WeaponController>();
            foreach (WeaponController weapon in _weapons)
            {
                weapon.gameObject.SetActive(false);
            }
            _animator = GetComponentInChildren<Animator>();
        }

        private void Start() {
            CurrentWeapon = _weapons[_index];
            CurrentWeapon.gameObject.SetActive(true);
        }

        public void ChangeWeapon()
        {
            _index++;

            if(_index >= _weapons.Length)
            {
                _index = 0;
            }
            CurrentWeapon = _weapons[_index];

            foreach (WeaponController weapon in _weapons)
            {
                if(CurrentWeapon == weapon)
                {
                    // animC.layers[1].avatarMask = RunAttack;
                    weapon.gameObject.SetActive(true);
                    _animator.runtimeAnimatorController = CurrentWeapon.AttackSO.AnimatorOverrideController;
                }
                else
                {
                    weapon.gameObject.SetActive(false);
                }
            }
        }
    }
}