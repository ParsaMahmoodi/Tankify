using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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
        

        public bool pauseFlag = false;
        public bool gameOverFlag = false;
        
        public event Action<int> PlayerDied;


        void Start()
        {
            _playerHealth = playerData.health;

            _gameManager = GameManager.Instance;

            _fireBullet = gameObject.GetComponent<FireBullet>();
            _agentRotation = gameObject.GetComponent<AgentRotation>();
            _playerInput = gameObject.GetComponent<PlayerInput>();

            _playerInput.OnClicked += Attack;
            
            _gameManager.OnPauseGame += PauseGameController;
            _gameManager.OnResumeGame += ResumeController;
            _gameManager.OnGameOver += GameOverController;

        }

        public void Rotate(Vector2 target)
        {
            if (!pauseFlag && !gameOverFlag)
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
                PlayerDied?.Invoke(_playerScore);
                // _gameManager.gameOverState = true;
                // _gameManager.GameOver(_playerScore);
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
        
        void Attack(Vector2 direction)
        {
            _fireBullet.Fire(direction);
        }

        void PauseGameController()
        {
            pauseFlag = true;
        }
        
        void ResumeController()
        {
            pauseFlag = false;
        }
        
        void GameOverController()
        {
            gameOverFlag = true;
        }

    }
}
