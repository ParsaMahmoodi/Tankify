using Features.Core.Scripts.Player;
using UnityEngine;
using UnityEngine.AI;

namespace Features.Core.Scripts.EnemyScripts
{
    public class EnemyNo2Controller : MonoBehaviour
    {
        [SerializeField] private EnemyHealthBarController healthBar;
        
        [SerializeField] private NavMeshAgent agent;
        
        [SerializeField] private EnemyData enemyData;
        
        private GameManager _gameManager = GameManager.Instance;

        private GameObject _player;
        private PlayerController _playerController;

        private float _enemyCurrentHealth;
        private float _enemyDamage;
        
        
        void Start()
        {
            // _enemyCurrentHealth = enemyData.health;
            // _enemyDamage = enemyData.damage;
            _enemyCurrentHealth = 100;
            _enemyDamage = 10;
            
            agent.updateUpAxis = false;
            
            _player = _gameManager.Player;
            _playerController = _player.GetComponent<PlayerController>();

        }

        void Update()
        {
            MoveEnemy();
            RotateEnemy();
        }
    
        private void MoveEnemy()
        {
            if (_gameManager.gameIsPaused || _gameManager.gameOverState)
            {
                agent.isStopped = true;
            }
            
            else
            {
                agent.isStopped = false;
                agent.SetDestination(_player.transform.position);
            }
            
        }
        
        private void RotateEnemy()
        {
            Vector2 moveDirection = _player.transform.position - transform.position;
            moveDirection.Normalize();
        
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);

            if (transform.rotation != targetRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    targetRotation, 200 * Time.deltaTime);
            }
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
                DestroyEnemy();
            }
        }
        
        private void TakeDamage(int dmg = 25)
        {
            _enemyCurrentHealth -= dmg;
            healthBar.SetHealth(_enemyCurrentHealth);
            
            gameObject.transform.localScale /= 2;
            
            if (_enemyCurrentHealth <= 0f)
            {
                DestroyEnemy();
                _playerController.AddPlayerScore();
            }
        }
        
        private void DestroyEnemy()
        {
            Destroy(gameObject);
        }


    }
}
