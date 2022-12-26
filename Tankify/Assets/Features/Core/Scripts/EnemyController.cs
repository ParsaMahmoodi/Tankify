using System;
using NavMeshComponents.Extensions;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

namespace Features.Core.Scripts
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private EnemyHealthBarController _healthBar; 

        private GameManager _gameManager;
        
        private GameObject _player;

        private PlayerController _playerController;
        
        private NavMeshAgent _agent;

        private float _enemyMaxHealth = 100f;

        private float _enemyCurrentHealth;

        private float _enemyDamage = 20f;

        private float _enemyMoveSpeed = 2f;

        private Quaternion _targetRotation;

        private bool _disableEnemy = false;
        
        private Vector2 _moveDirection;

    
        // Start is called before the first frame update
        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");

            _playerController = _player.GetComponent<PlayerController>();

            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateUpAxis = false;
            // _agent.updateRotation = false;

            _enemyCurrentHealth = _enemyMaxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            MoveEnemy();
            RotateEnemy();
        }
        
        private void MoveEnemy()
        {
            _agent.SetDestination(_player.transform.position);
        }
        
        void RotateEnemy()
        {
            _moveDirection = _player.transform.position - transform.position;
            _moveDirection.Normalize();
        
            _targetRotation = Quaternion.LookRotation(Vector3.forward, _moveDirection);

            if (transform.rotation != _targetRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                    _targetRotation, 200 * Time.deltaTime);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                StartCoroutine(Damaged());
                
                TakeDamage();
                
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                _playerController.TakeDamage(_enemyDamage);
            }
        }
        
        IEnumerator Damaged()
        {
            _disableEnemy = true;
            yield return new WaitForSeconds(0.5f);
            _disableEnemy = false;
        }

        private void TakeDamage(int dmg = 25)
        {
            _enemyCurrentHealth -= dmg;
            _healthBar.SetHealth(_enemyCurrentHealth);
            
            if (_enemyCurrentHealth <= 0f)
            {
                Destroy(gameObject);
                _playerController.AddPlayerScore();
            }
        }
    }
}
