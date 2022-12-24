using System.Collections;
using UnityEngine;

namespace Features.Core.Scripts
{
    public class EnemySpawn : MonoBehaviour
    {

        [SerializeField] private GameManager _gameManager;

        [SerializeField] private GameObject[] _spawnPonints;
        [SerializeField] private GameObject _enemy;

        private float _spawnTimer = 2f;
        private float _spawnRateIncrease = 5f;
    
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnNextEnemy());
            StartCoroutine(SpawnRateIncrease());
        }

        // Update is called once per frame
        IEnumerator SpawnNextEnemy()
        {
            int nextSpawnLocation = Random.Range(0, _spawnPonints.Length);
            Instantiate(_enemy, _spawnPonints[nextSpawnLocation].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_spawnTimer);

            if (!_gameManager._gameOver)
            {
                StartCoroutine(SpawnNextEnemy());
            }
        }
    
        IEnumerator SpawnRateIncrease()
        {
            yield return new WaitForSeconds(_spawnRateIncrease);
            if (_spawnTimer >= 0.5f)
            {
                _spawnTimer -= 0.2f;
            }
            StartCoroutine(SpawnRateIncrease());
        }
    }
}