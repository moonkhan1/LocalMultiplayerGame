using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Helpers;
using UnityProject3.Controllers;

namespace UnityProject3.Managers
{
    public class EnemyManager : SingletonBase<EnemyManager>
    {
        [SerializeField] int _maxEnemyCountOnRound = 50;
        [SerializeField] List<EnemyController> _enemies;

        public List<EnemyController> Enemies => _enemies;
        public bool CanSpawnEnemy => _maxEnemyCountOnRound > _enemies.Count;

        void Awake() 
        {
            MakeSingleton(this);
            _enemies = new List<EnemyController>();    
        }

        public void AddEnemyToList(EnemyController enemyController)
        {
            enemyController.transform.parent = this.transform;
            _enemies.Add(enemyController);
        }

        public void RemoveEnemyFromList(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
            GameManager.Instance.DecreaseWaveEnemyCount();
        }
    }
}