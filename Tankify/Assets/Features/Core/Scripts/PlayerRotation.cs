using UnityEngine;

namespace Features.Core.Scripts
{
    public class PlayerRotation : MonoBehaviour
    {
        private GameManager _gameManager;
        public float angle = 0;
        
        void Start()
        {
            _gameManager = GameManager.Instance;
        }

        void Update()
        {
            if (!_gameManager.gameIsPaused && !_gameManager.gameOverState)
            {
                Rotate();
            }
        }

        void Rotate()
        {
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
        
    }
}
