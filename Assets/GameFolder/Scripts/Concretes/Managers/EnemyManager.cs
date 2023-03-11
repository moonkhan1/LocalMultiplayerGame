using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject3.Abstracts.Helpers;
using UnityProject3.Controllers;

namespace UnityProject3.Managers
{
    public class EnemyManager : SingletonBase<EnemyManager>
    {
        [SerializeField] int _maxEnemyCountOnRound = 30;
        [SerializeField] List<EnemyController> _enemies;
        
        public List<Transform> Targets { get; private set; }
        public List<EnemyController> Enemies => _enemies;
        public bool IsListEmpty => _enemies.Count <= 0; 
        public bool CanSpawnEnemy => _maxEnemyCountOnRound > _enemies.Count;

        void Awake() 
        {
            MakeSingleton(this);
            _enemies = new List<EnemyController>();
            Targets = new List<Transform>();
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

        public void ClearAllEnemies()
        {
            foreach (EnemyController enemyController in _enemies)
            {
                Destroy(enemyController.gameObject);
            }
            _enemies.Clear();
        }
    }
}