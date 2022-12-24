using UnityEngine;
using Unity.Mathematics;
using System.Collections;


namespace Features.Core.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        
        [SerializeField] private GameManager _gameManager;

        private Rigidbody2D _rb;

        private Camera _mainCamera;

        private Vector2 _mousePositon;
        private Vector2 _offset;

        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject _bulletSpawn;

        private bool _isShooting;
        private float _bulletSpeed = 15f;
        
        // Start is called before the first frame update
        void Start()
        {
            _rb = gameObject.GetComponent<Rigidbody2D>();
            _mainCamera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isShooting = true;
            }
            
            RotatePlayer();
            
            if (_isShooting)
            {
                StartCoroutine(Fire());
            }
            
            
        }
        
        void RotatePlayer()
        {
            _mousePositon = Input.mousePosition;
            Vector3 screePoint = _mainCamera.WorldToScreenPoint(transform.localPosition);
            _offset = new Vector2(_mousePositon.x - screePoint.x, _mousePositon.y - screePoint.y).normalized;

            float angle = Mathf.Atan2(_offset.y, _offset.x)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

        }
        
        IEnumerator Fire()
        {
            _isShooting = false;
            GameObject bullet = Instantiate(_bullet, _bulletSpawn.transform.position, quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = _offset * _bulletSpeed;

            yield return new WaitForSeconds(3);
            Destroy(bullet);
        }
    }
}
