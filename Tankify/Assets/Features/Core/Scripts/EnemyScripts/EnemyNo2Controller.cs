using System.Collections;
using Features.Core.Scripts.Player;
using UnityEngine;

namespace Features.Core.Scripts.EnemyScripts
{
    public class EnemyNo2Controller : EnemyControllerMain
    {
        private bool _enemyStop = false;
        
        void Start()
        {
            base.Start();
        }
        
        void Update()
        {
            if (!pauseFlag && !gameOverFlag && !_enemyStop)
            {
                MoveEnemy();
                RotateEnemy();
            }
            else
            {
                StopEnemy();
            }
        }

        public override void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                TakeDamage();
                Destroy(collision.gameObject);
                StartCoroutine(StallEnemy());
            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                _playerController.TakeDamage(_enemyDamage);
                _particleSystem.Play();
                StartCoroutine(DestroyEnemy());
            }
        }
        
        IEnumerator StallEnemy()
        {
            _enemyStop = true;
            yield return new WaitForSeconds(3);
            _enemyStop = false;
        }

    }
}
