using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Controllers;

namespace UnityProject3.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Spawn info", menuName = "Info/Spawn Information", order = 51)]
    public class SpawnInfoSO : ScriptableObject 
    {
        [SerializeField] EnemyController _enemyPrefab;
        [SerializeField] float _maxSpawnTime = 15f;
        [SerializeField] float _minSpawnTime = 5f;

        public EnemyController EnemyPrefab => _enemyPrefab;
        public float RandomSpawnTime => Random.Range(_minSpawnTime, _maxSpawnTime);
        
    }
}