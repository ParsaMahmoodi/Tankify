using System.Collections;
using UnityEngine;
using System;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

namespace Features.Core.Scripts.EnemyScripts
{
    public class EnemySpawn : MonoBehaviour
    {
        private GameManager _gameManager;

        [SerializeField] private GameObject[] spawnPoints;
        
        [SerializeField] private GameObject[] enemies;

        [SerializeField] private EnemyData enemyData;
        
        private AnimationCurve _spawnTimerCurve;
        private AnimationCurve _spawnAmountCurve;

        private float _totalSpawnProbability = 0;
        
        private float _nextWaveTimer;

        private bool _spawnStatus = true;

        private int _waveIndex;

        // Start is called before the first frame update
        void Start()
        {
            _gameManager = GameManager.Instance;

            _gameManager.OnPauseGame += PauseSpawn;
            _gameManager.OnResumeGame += ResumeSpawn;
            _gameManager.OnGameOver += PauseSpawn;

            _spawnTimerCurve = enemyData.spawnTimerCurve;
            _spawnAmountCurve = enemyData.spawnAmountCurve;
        }

        private void Update()
        {
            if (_spawnStatus)
            {
                _waveIndex++;
                _nextWaveTimer -= Time.deltaTime;
                if (_nextWaveTimer <= 0f)
                {
                    _nextWaveTimer = _spawnTimerCurve.Evaluate(_waveIndex);
                    SpawnWave();
                }
            }
        }

        void SpawnWave()
        {
            int spawnAmount = Mathf.RoundToInt(_spawnAmountCurve.Evaluate(_waveIndex));

            for (int i = 0; i < spawnAmount; i++)
            {
                SpawnEnemy();
            }
        }

        void SpawnEnemy()
        {
            int nextSpawnLocation = Random.Range(0, spawnPoints.Length);
            Enemy nextEnemyName = RandomEnemy();
            if (nextEnemyName.prefab!= null && spawnPoints[nextSpawnLocation].transform.position !=null && Quaternion.identity!=null)
                Instantiate(nextEnemyName.prefab, spawnPoints[nextSpawnLocation].transform.position, Quaternion.identity);
        }

        void ResumeSpawn()
        {
            _spawnStatus = true;
        }

        void PauseSpawn()
        {
            _spawnStatus = false;
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