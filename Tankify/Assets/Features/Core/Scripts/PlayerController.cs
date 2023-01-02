using UnityEngine;
using UnityEngine.UI;


namespace Features.Core.Scripts
{
    public class PlayerController : MonoBehaviour
    {

        private GameManager _gameManager;

        [SerializeField] private Text _currentScoreText;
        
        [SerializeField] private PlayerHealthBarController _healthBar;
        
        [SerializeField]  private PlayerData playerData;

        private FireBullet _fireBullet;
        private PlayerRotation _playerRotation;
        private PlayerInput _playerInput;

        private float _playerHealth = 100f;
        private int _playerScore = 0;

        void Start()
        {
            _playerHealth = playerData.health;

            _gameManager = GameManager.Instance;

            _fireBullet = gameObject.GetComponent<FireBullet>();
            _playerRotation = gameObject.GetComponent<PlayerRotation>();
            _playerInput = gameObject.GetComponent<PlayerInput>();
        }

        void Update()
        {
            SetRotationAngle();
        }
        
        public void TakeDamage(float damage = 25)
        {
            _playerHealth -= damage;
            
            _healthBar.SetHealth(_playerHealth);
            
            if (_playerHealth <= 0)
            {
                SaveScore(_playerScore);
                _gameManager.gameOverState = true;
                _gameManager.GameOver(_playerScore);
            }
        }

        public void AddPlayerScore()
        {
            _playerScore += 1;
            _currentScoreText.text = "Score: " + _playerScore.ToString();
        }
        
        private void SaveScore(int score)
        {
            int previousHighScore = PlayerPrefs.GetInt("HighScore", 0);
            
            if(score > previousHighScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }

        public void Attack(Vector2 direction)
        {
            _fireBullet.Fire(direction);
        }

        void SetRotationAngle()
        {
            _playerRotation.angle = _playerInput.angle;
        }
    }
}
