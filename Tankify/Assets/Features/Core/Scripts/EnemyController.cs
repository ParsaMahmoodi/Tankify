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
        private GameManager _gameManager;
        
        private GameObject _player;
        
        private NavMeshAgent _agent;

        private float _enemyHealth = 100f;

        private float _enemyDamage = 20f;

        private float _enemyMoveSpeed = 2f;

        private Quaternion _targetRotation;

        private bool _disableEnemy = false;
        
        private Vector2 _moveDirection;

    
        // Start is called before the first frame update
        void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateUpAxis = false;
            // _agent.updateRotation = false;
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

                _enemyHealth -= 25f;

                if (_enemyHealth <= 0f)
                {
                    Destroy(gameObject);
                }

                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                // PlayerController.TakeDamage(_enemyDamage);
                //
                // if (PlayerController.GetPlayerHealth() < 0)
                // {
                //     _gameManager._gameOver = true;
                //     collision.gameObject.SetActive(false);
                // }
            }
        }
        
        
        IEnumerator Damaged()
        {
            _disableEnemy = true;
            yield return new WaitForSeconds(0.5f);
            _disableEnemy = false;
        }
    }
}
