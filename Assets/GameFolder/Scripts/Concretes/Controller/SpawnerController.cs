using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.ScriptableObjects;
using UnityProject3.Managers;

namespace UnityProject3.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] SpawnInfoSO _spawnInfo;
        [SerializeField] float _maxTime;

        float _currnetTime = 0f;

        void Start() 
        {
            _maxTime = _spawnInfo.RandomSpawnTime;    
        }

        void Update() 
        {
            _currnetTime += Time.deltaTime;

            if(_currnetTime > _maxTime && EnemyManager.Instance.CanSpawnEnemy)
            {
                Spawn();
            }    
        }

        private void Spawn()
        {
            EnemyController enemy = Instantiate(_spawnInfo.EnemyPrefab, transform.position, Quaternion.identity);
            EnemyManager.Instance.AddEnemyToList(enemy);
            _currnetTime = 0f;
            _maxTime = _spawnInfo.RandomSpawnTime;
        }
    }
}

