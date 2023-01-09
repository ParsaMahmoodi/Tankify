using System;
using System.Collections;
using UnityEngine;

namespace Features.Core.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        
        private Camera _mainCamera;
        private GameManager _gameManager;
        private PlayerController _playerController;

        private Vector2 _mousePosition;
        private Vector2 _targetPosition;

        public float angle;


        public event EventHandler<Vector2> OnClicked;
        
        
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
            _targetPosition = new Vector2(_mousePosition.x - screenPoint.x, _mousePosition.y - screenPoint.y);
            
            _playerController.Rotate(_targetPosition);

            if (Input.GetMouseButtonDown(0) && !_gameManager.gameIsPaused && !_gameManager.gameOverState)
            {
                OnClicked?.Invoke(this, _targetPosition); 
            }
            
        }
        
    }
}
