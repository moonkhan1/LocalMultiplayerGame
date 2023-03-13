using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityProject3.Managers
{
    public class PlayerJoinManager : MonoBehaviour
    {
        [SerializeField] GameObject[] _playerPrefebs;
        PlayerInputManager _playerInputManager;
        int _playerIndex;
        private void Awake()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerInputManager.playerPrefab = _playerPrefebs[_playerIndex];
        }


        private void OnEnable()
        {
            StartCoroutine(PlayerJoinAsync());
        }

        IEnumerator PlayerJoinAsync()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
            for (int i = 0; i < GameManager.Instance.PlayerCount; i++)
            {
                _playerInputManager.JoinPlayer(_playerIndex);
                yield return waitForSeconds;
            }
        }

        public void HandleOnJoin()
        {
            _playerIndex++;
            if (_playerIndex >= _playerPrefebs.Length)
            {
                _playerIndex = _playerPrefebs.Length - 1;
            }
            _playerInputManager.playerPrefab = _playerPrefebs[_playerIndex];
            _playerInputManager.splitScreen = true;
        }
        
        public void HandleOnLeft()
        {
            _playerIndex--;
            if (_playerIndex < 0)
            {
                _playerIndex = 0;
            }
            _playerInputManager.playerPrefab = _playerPrefebs[_playerIndex];
            _playerInputManager.splitScreen = false;
        }
    }
}