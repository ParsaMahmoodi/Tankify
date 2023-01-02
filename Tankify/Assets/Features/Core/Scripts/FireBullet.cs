using UnityEngine;
using Unity.Mathematics;
using System.Collections;

namespace Features.Core.Scripts
{
    public class FireBullet : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPreFabObject;
        [SerializeField] private GameObject _bulletSpawn;
        
        private float _bulletSpeed = 15f;

        private GameObject _bullet;

        public void Fire(Vector2 offset)
        {

            _bullet = Instantiate(_bulletPreFabObject, _bulletSpawn.transform.position, quaternion.identity);

            _bullet.GetComponent<Rigidbody2D>().velocity = offset * _bulletSpeed;

            StartCoroutine(FireIEnumerator());
        }
        
        IEnumerator FireIEnumerator()
        {
            yield return new WaitForSeconds(3);
            Destroy(_bullet);
        }
    }
}
