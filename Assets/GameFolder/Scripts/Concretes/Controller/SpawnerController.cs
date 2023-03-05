using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.ScriptableObjects;
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

            if(_currnetTime > _maxTime)
            {
                Spawn();
            }    
        }

        private void Spawn()
        {
            Instantiate(_spawnInfo.EnemyPrefab, transform.position, Quaternion.identity);

            _currnetTime = 0f;
            _maxTime = _spawnInfo.RandomSpawnTime;
        }
    }
}

