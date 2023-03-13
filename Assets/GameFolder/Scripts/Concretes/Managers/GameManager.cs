using UnityEngine;
using UnityProject3.Abstracts.Helpers;
using UnityProject3.Controllers;
using UnityEngine.SceneManagement;
using System.Collections;

namespace UnityProject3.Managers
{
    public class GameManager : SingletonBase<GameManager>
    {
        [SerializeField] int _waveMaxCount = 25;
        [SerializeField] float _waveMultiplayer = 1.2f;
        [SerializeField] float _waveWaitTime = 7f;
        [SerializeField] int _waveLevelCount = 1;
        [SerializeField] int _playerCount = 0;

        public int PlayerCount => _playerCount;

        int _tempMaxWaveCount;
        public bool IsWaveFinished => _tempMaxWaveCount <= 0;
        public event System.Action<int> NextWave;
        void Awake()
        {
            MakeSingleton(this);
        }

        void Start() 
        {
            _tempMaxWaveCount = _waveMaxCount;
        }

        public void LoadScene(string name)
        {
            StartCoroutine(LoadSceneAsync(name));
        }

        private IEnumerator LoadSceneAsync(string name)
        {
            yield return SceneManager.LoadSceneAsync(name);
        }

        public void DecreaseWaveEnemyCount()
        {
            if(IsWaveFinished)
            {
                if (EnemyManager.Instance.IsListEmpty)
                {
                    StartCoroutine(WaitForNextLevel());  
                }
            } 
            else
            {
                _tempMaxWaveCount--;

            }
        }

        private IEnumerator WaitForNextLevel()
        {
            
            yield return new WaitForSeconds(_waveWaitTime);
            _waveMaxCount = System.Convert.ToInt32( _waveMaxCount * _waveMultiplayer);
            _tempMaxWaveCount = _waveMaxCount;
            _waveLevelCount++;
            NextWave?.Invoke(_waveLevelCount);
        }

        public void IncreasePlayerCount()
        {
            _playerCount++;
        }
        public void DecreasePlayerCount()
        {
            _playerCount--;
        }

        public void ReturnMenuOnAllPlayerDead()
        {
            if (_playerCount > 1)
            {
                _playerCount--;
            }
            else
            {
                _playerCount = 0;
                EnemyManager.Instance.ClearAllEnemies();
                EnemyManager.Instance.Targets.Clear();
                LoadScene("Menu");
            }
        }

        public void ExitGame()
        {
            Application.Quit(0);
        }
        

    }
}