using System;
using System.Collections;
using UnityEngine;

namespace Features.Core.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        
        private Camera _mainCamera;
        private PlayerController _playerController;

        private Vector2 _mousePosition;
        private Vector2 _targetPosition;

        public float angle;


        public event Action<Vector2> OnClicked;
        
        
        void Start()
        {
            _mainCamera = Camera.main;

            _playerController = gameObject.GetComponent<PlayerController>();
        }


        void Update()
        {
            _mousePosition = Input.mousePosition;
            Vector3 screenPoint = _mainCamera.WorldToScreenPoint(transform.localPosition);
            _targetPosition = new Vector2(_mousePosition.x - screenPoint.x, _mousePosition.y - screenPoint.y);
            
            _playerController.Rotate(_targetPosition);

            if (Input.GetMouseButtonDown(0) && !_playerController.pauseFlag && !_playerController.gameOverFlag)
            {
                OnClicked?.Invoke(_targetPosition); 
            }
            
        }
        
    }
}
