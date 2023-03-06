using UnityEngine;
using UnityProject3.Abstracts.Helpers;
using UnityProject3.Controllers;
using UnityEngine.SceneManagement;
using System.Collections;

namespace UnityProject3.Managers
{
    public class GameManager : SingletonBase<GameManager>
    {
        [SerializeField] int _waveMaxCount = 100;
        public bool IsWaveFinished => _waveMaxCount <= 0;
        void Awake()
        {
            MakeSingleton(this);
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
            if(IsWaveFinished) return;

            _waveMaxCount--;
        }
    }
}