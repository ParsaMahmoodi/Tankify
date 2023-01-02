using UnityEngine;
using System.Collections;


namespace Features.Core.Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        
        private Camera _mainCamera;
        private GameManager _gameManager;
        private PlayerController _playerController;

        private Vector2 _mousePosition;
        private Vector2 _offset;

        public float angle;
        

        void Start()
        {
            _mainCamera = Camera.main;

            _gameManager = GameManager.Instance;

            _playerController = gameObject.GetComponent<PlayerController>();
        }


        void Update()
        {
            
            _mousePosition = Input.mousePosition;
            Vector3 screenPoint = _mainCamera.WorldToScreenPoint(transform.localPosition);
            _offset = new Vector2(_mousePosition.x - screenPoint.x, _mousePosition.y - screenPoint.y).normalized;
            angle = Mathf.Atan2(_offset.y, _offset.x) * Mathf.Rad2Deg;

            if (Input.GetMouseButtonDown(0) && !_gameManager.gameIsPaused && !_gameManager.gameOverState)
            {
                _playerController.Attack(_offset);
            }
        }

    }
}
