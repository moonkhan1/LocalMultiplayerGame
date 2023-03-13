using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityProject3.Abstracts.Inputs;
using UnityProject3.Controllers;

namespace UnityProject3.Inputs
{

    public class InputReader : MonoBehaviour, IInputReader
    {
        public Vector3 Direction { get; private set; }
        public Vector2 Rotation { get; private set; }
        public bool IsAttackButtonPress { get; private set; }
        public bool IsInventoryButtonPressed { get; private set; }
        public bool IsPauseMenuButtonPressed { get; private set; }

        int _inventoryIndex;

        public void OnMove(InputAction.CallbackContext context)
        {
            Vector2 oldDirection = context.ReadValue<Vector2>();
            Direction = new Vector3(oldDirection.x, 0f, oldDirection.y);
        }

        public void OnRotator(InputAction.CallbackContext context)
        {
            Rotation = context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            IsAttackButtonPress = context.ReadValueAsButton();
        }

        public void OnInventory(InputAction.CallbackContext context)
        {
            if (IsInventoryButtonPressed && context.action.triggered) return;

            StartCoroutine(WaitFrameForWeaponSwitch());
        }
        public void OnPauseMenu(InputAction.CallbackContext context)
        {
            IsPauseMenuButtonPressed = context.ReadValueAsButton();
        }
        
        IEnumerator WaitFrameForWeaponSwitch()
        {
            IsInventoryButtonPressed = true && _inventoryIndex % 2 == 0;
            yield return new WaitForEndOfFrame();
            IsInventoryButtonPressed = false;
            _inventoryIndex ++;
        }


    }
}