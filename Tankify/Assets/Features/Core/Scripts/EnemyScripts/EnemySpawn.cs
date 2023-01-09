using System.Collections;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Features.Core.Scripts.EnemyScripts
{
    public class EnemySpawn : MonoBehaviour
    {
        private GameManager _gameManager;

        [SerializeField] private GameObject[] spawnPoints;
        
        [SerializeField] private GameObject[] enemies;

        [SerializeField] private EnemyData enemyData;

        private float _spawnTimer = 2f;
        private float _spawnRateIncrease = 10f;
        private float _totalSpawnProbability = 0;

        // Start is called before the first frame update
        void Start()
        {
            _gameManager = GameManager.Instance;
            
            StartCoroutine(SpawnNextEnemy());
            StartCoroutine(SpawnRateIncrease());
        }

        IEnumerator SpawnNextEnemy()
        {
            int nextSpawnLocation = Random.Range(0, spawnPoints.Length);
            Enemy nextEnemyName = RandomEnemy();
            Instantiate(nextEnemyName.prefab, spawnPoints[nextSpawnLocation].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_spawnTimer);

            if (!_gameManager.gameOverState && !_gameManager.gameIsPaused)
            {
                StartCoroutine(SpawnNextEnemy());
            }
        }
    
        IEnumerator SpawnRateIncrease()
        {
            yield return new WaitForSeconds(_spawnRateIncrease);
            if (_spawnTimer >= 0.5f)
            {
                _spawnTimer -= 0.15f;
                StartCoroutine(SpawnRateIncrease());
            }
        }

        public void ResumeSpawn()
        {
            StartCoroutine(SpawnNextEnemy());
            StartCoroutine(SpawnRateIncrease());
        }
        
        public void PauseSpawn()
        {
            StopAllCoroutines();
        }
        
        private Enemy RandomEnemy()
        {
            TotalSpawnProbabilityCalculator();

            if (_totalSpawnProbability == 0)
            {
                return enemyData.Enemies[Random.Range(0, enemyData.Enemies.Count)];
            }
            
            Unity.Mathematics.Random random = new Unity.Mathematics.Random();
            float enemyProb = random.NextFloat(0, _totalSpawnProbability);

            float probabilityLocator = 0;
            foreach (var enemy in enemyData.Enemies)
            {
                probabilityLocator += enemy.spawnProbability;
                
                if (enemyProb < probabilityLocator)
                {
                    return enemy;
                }
            }

            return null;
        }

        private void TotalSpawnProbabilityCalculator()
        {
            _totalSpawnProbability = 0;
            
            foreach (var enemy in enemyData.Enemies)
            {
                _totalSpawnProbability += enemy.spawnProbability;
            }

            
        }
    }
}