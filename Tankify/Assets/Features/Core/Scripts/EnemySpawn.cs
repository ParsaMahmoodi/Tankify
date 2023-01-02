using System.Collections;
using UnityEngine;

namespace Features.Core.Scripts
{
    public class EnemySpawn : MonoBehaviour
    {

        [SerializeField] private GameManager _gameManager;

        [SerializeField] private GameObject[] _spawnPonints;
        
        [SerializeField] private GameObject[] _enemy;

        private float _spawnTimer = 2f;
        private float _spawnRateIncrease = 10f;
    
        // Start is called before the first frame update
        void Start()
        {
            _gameManager = GameManager.Instance;
            
            StartCoroutine(SpawnNextEnemy());
            StartCoroutine(SpawnRateIncrease());
        }

        IEnumerator SpawnNextEnemy()
        {
            int nextSpawnLocation = Random.Range(0, _spawnPonints.Length);
            int nextEnemyType = Random.Range(0, _enemy.Length);
            Instantiate(_enemy[nextEnemyType], _spawnPonints[nextSpawnLocation].transform.position, Quaternion.identity);
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
            }
            StartCoroutine(SpawnRateIncrease());
        }

        public void ResumeSpawn()
        {
            StartCoroutine(SpawnNextEnemy());
            StartCoroutine(SpawnRateIncrease());
        }
    }
}