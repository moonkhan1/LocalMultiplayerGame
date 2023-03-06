using UnityEngine;
using UnityProject3.Abstracts.Helpers;
using UnityProject3.Controllers;
using UnityEngine.SceneManagement;
using System.Collections;

namespace UnityProject3.Managers
{
    public class GameManager : SingletonBase<GameManager>
    {

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
    }
}