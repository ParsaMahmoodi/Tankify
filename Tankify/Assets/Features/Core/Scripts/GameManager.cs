using UnityEngine;

namespace Features.Core.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public bool gameOverState = false;
        public bool gameIsPaused = false;

        [SerializeField]
        private GameOverScreen gameOverScreen;

        [SerializeField]
        private GameObject _player;
        
        public static GameManager Instance { get; private set; }
        
        
        // ONLY ONE DELIGATE?
        public delegate void PauseGameDelegate();
        public event PauseGameDelegate OnPauseGame;
        
        public delegate void GameOverDelegate();
        public event GameOverDelegate OnGameOver;
        
        public delegate void ResumeGameDelegate();
        public event ResumeGameDelegate OnResumeGame;

        private void Awake()
        {
            Instance = this;
        }

        public GameObject Player
        {
            get
            {
                return _player;
            }
        }


        public void GameOver(int score)
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
