using System.Collections;
using Features.Core.Scripts.Player;
using UnityEngine;

namespace Features.Core.Scripts.EnemyScripts
{
    public class EnemyControllerMain : MonoBehaviour
    {
        [SerializeField] private EnemyHealthBarController _healthBar; 
        
        [SerializeField] private ParticleSystem _particleSystem;
        
        private GameManager _gameManager = GameManager.Instance;

        private EnemyData _enemyData;

        private GameObject _player;

        private PlayerController _playerController;
        
        private float _enemyMaxHealth = 100f;

        private float _enemyCurrentHealth;

        private float _enemyDamage = 20f;

        // private float _enemyMoveSpeed = 2f;

        private AgentRotation _agentRotation;

        private EnemyMovement _enemyMovement;
        
        
        void Start()
        {
            
            _agentRotation = gameObject.GetComponent<AgentRotation>();
            _enemyMovement = gameObject.GetComponent<EnemyMovement>();

            
            _player = _gameManager.Player;
            _player = GameObject.FindGameObjectWithTag("Player");

            _playerController = _player.GetComponent<PlayerController>();

            _enemyCurrentHealth = _enemyMaxHealth;
        }
        
        void Update()
        {
            if (!_gameManager.gameIsPaused && !_gameManager.gameOverState)
            {
                MoveEnemy();
                RotateEnemy();
            }
            else
            {
                StopEnemy();
            }
        }
        
        void MoveEnemy()
        {
            _enemyMovement.Move(_player.transform);
        }

        void StopEnemy()
        {
            _enemyMovement.Stop();
        }
        
        void RotateEnemy()
        {
            _agentRotation.Rotate(_player.transform.position);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                TakeDamage();
                
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                _playerController.TakeDamage(_enemyDamage);
                _particleSystem.Play();
                StartCoroutine(DestroyEnemy());
            }
        }

        private void TakeDamage(int dmg = 25)
        {
            _enemyCurrentHealth -= dmg;
            _healthBar.SetHealth(_enemyCurrentHealth);
            
            if (_enemyCurrentHealth <= 0f)
            {
                _particleSystem.Play();
                StartCoroutine(DestroyEnemy());
                _playerController.AddPlayerScore();
            }
        }

        IEnumerator DestroyEnemy()
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }

    }
}
