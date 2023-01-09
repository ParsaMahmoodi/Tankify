using UnityEngine;
using UnityEngine.UI;

namespace Features.Core.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {

        private GameManager _gameManager;

        [SerializeField] private Text _currentScoreText;
        
        [SerializeField] private PlayerHealthBarController _healthBar;
        
        [SerializeField]  private PlayerData playerData;

        private FireBullet _fireBullet;
        private AgentRotation _agentRotation;
        private PlayerInput _playerInput;

        private float _playerHealth = 100f;
        private int _playerScore = 0;
        
        private float _rotationAngle = 0;

        private bool _pauseFlag = false;
        private bool _gameOverFlag = false;


        void Start()
        {
            _playerHealth = playerData.health;

            _gameManager = GameManager.Instance;

            _fireBullet = gameObject.GetComponent<FireBullet>();
            _agentRotation = gameObject.GetComponent<AgentRotation>();
            _playerInput = gameObject.GetComponent<PlayerInput>();

            _playerInput.OnClicked += Attack;
            
            _gameManager.OnPauseGame += PauseGameController;
            // _gameManager.OnPauseGame += () => _pauseFlag = true;
            
            _gameManager.OnResumeGame += ResumeController;
            // _gameManager.OnResumeGame += () => _pauseFlag = false;
            
            _gameManager.OnGameOver += GameOverController;
            // _gameManager.OnGameOver += () => _gameOverFlag = true;

        }

        void Update()
        {
        }

        public void Rotate(Vector2 target)
        {
            if (!_pauseFlag && !_gameOverFlag)
            {
                _agentRotation.Rotate(target);
            }
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
        
        void Attack(object sender, Vector2 direction)
        {
            _fireBullet.Fire(direction);
        }

        void PauseGameController()
        {
            _pauseFlag = true;
        }
        
        void ResumeController()
        {
            _pauseFlag = false;
        }
        
        void GameOverController()
        {
            _gameOverFlag = true;
        }

    }
}
