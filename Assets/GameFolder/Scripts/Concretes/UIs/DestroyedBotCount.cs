using TMPro;
using UnityEngine;
using UnityProject3.Controllers;

namespace UnityProject3.Helpers
{
    public class DestroyedBotCount : MonoBehaviour
    {
        private TMP_Text _killText;
        private int _killCount;
        private PlayerController _player;
        private void Awake()
        {
            _player = GetComponentInParent<PlayerController>();
            _killText = GetComponent<TMP_Text>();
        }
        
        private void OnEnable()
        {
            _player.isEnemyKilled += HandleOnEnemyKilled;
        }

        private void OnDisable()
        {
            _player.isEnemyKilled -= HandleOnEnemyKilled;
        }

        private void HandleOnEnemyKilled()
        {
            _killCount++;
            _killText.text = _killCount.ToString();
        }
    }
}