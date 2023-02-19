using System;
using Features.Core.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Features.Core.Scripts
{
    public class GameManager: MonoBehaviour
    {
        public static GameManager instance;
        
        public bool gameOverState = false;
        public bool gameIsPaused = false;

        [SerializeField]
        private GameOverScreen gameOverScreen;

        [SerializeField]
        private GameObject player;
        
        [SerializeField]
        private PlayerController _playerController;
        
        public event Action OnPauseGame;
        public event Action OnGameOver;
        public event Action OnResumeGame;
        
        public GameObject Player
        {
            get
            {
                return player;
            }
        }

        public static GameManager Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            instance = this;
        }


        void Start()
        {
            _playerController.PlayerDied += GameOver;
        }


        void GameOver(int score)
        {
            gameOverState = true;
            gameOverScreen.Setup(score);
            OnGameOver?.Invoke();
        }

        public void PauseGame()
        {
            gameIsPaused = true;
            OnPauseGame?.Invoke(); 
        }
        
        public void ResumeGame()
        {
            gameIsPaused = false;
            OnResumeGame?.Invoke(); 
        }

    }
}
