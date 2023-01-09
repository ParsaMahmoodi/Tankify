using UnityEngine;
using Unity.Mathematics;
using System.Collections;

namespace Features.Core.Scripts
{
    public class FireBullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D bulletPreFabObject;
        [SerializeField] private GameObject bulletSpawn;
        
        private float _bulletSpeed = 15f;

        private Rigidbody2D _bullet;

        public void Fire(Vector2 target)
        {

            _bullet = Instantiate(bulletPreFabObject, bulletSpawn.transform.position, quaternion.identity);

            _bullet.velocity = target.normalized * _bulletSpeed;

            StartCoroutine(FireIEnumerator());
        }
        
        IEnumerator FireIEnumerator()
        {
            yield return new WaitForSeconds(3);
            Destroy(_bullet);
        }
    }
}
