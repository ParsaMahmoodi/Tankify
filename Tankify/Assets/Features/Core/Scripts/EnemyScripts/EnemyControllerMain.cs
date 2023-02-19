using System;
using System.Collections;
using Features.Core.Scripts.Player;
using UnityEngine;

namespace Features.Core.Scripts.EnemyScripts
{
    public class EnemyControllerMain : MonoBehaviour
    {
        [SerializeField] protected EnemyHealthBarController _healthBar; 
        
        [SerializeField] public ParticleSystem _particleSystem;

        [NonSerialized] public GameManager _gameManager = GameManager.Instance;

        [NonSerialized] public EnemyData _enemyData;

        [NonSerialized] public GameObject _player;

        [NonSerialized] public PlayerController _playerController;
        
        [NonSerialized] public float _enemyMaxHealth = 100f;

        [NonSerialized] public float _enemyCurrentHealth;

        [NonSerialized] public float _enemyDamage = 20f;

        // private float _enemyMoveSpeed = 2f;

        [NonSerialized] public AgentRotation _agentRotation;

        [NonSerialized] public EnemyMovement _enemyMovement;
        
        [HideInInspector] public bool pauseFlag = false;
        [NonSerialized] public bool gameOverFlag = false;


        public void Start()
        {
            
            _agentRotation = gameObject.GetComponent<AgentRotation>();
            _enemyMovement = gameObject.GetComponent<EnemyMovement>();

            
            _player = _gameManager.Player;
            _player = GameObject.FindGameObjectWithTag("Player");

            _playerController = _player.GetComponent<PlayerController>();

            _enemyCurrentHealth = _enemyMaxHealth;
            
            _gameManager.OnPauseGame += PauseGameController;
            _gameManager.OnResumeGame += ResumeController;
            _gameManager.OnGameOver += GameOverController;

        }
        
        public void Update()
        {
            if (!pauseFlag && !gameOverFlag)
            {
                MoveEnemy();
                RotateEnemy();
            }
            else
            {
                StopEnemy();
            }
        }
        
        public void MoveEnemy()
        {
            _enemyMovement.Move(_player.transform);
        }

        public void StopEnemy()
        {
            _enemyMovement.Stop();
        }
        
        public void RotateEnemy()
        {
            _agentRotation.Rotate(_player.transform.position);
        }

        public virtual void OnCollisionEnter2D(Collision2D collision)
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

        public void TakeDamage(int dmg = 25)
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

        public IEnumerator DestroyEnemy()
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
        }
        
        public void PauseGameController()
        {
            pauseFlag = true;
        }
        
        public void ResumeController()
        {
            pauseFlag = false;
        }
        
        public void GameOverController()
        {
            gameOverFlag = true;
        }
    }
}
