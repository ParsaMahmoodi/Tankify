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
            gameOverScreen.Setup(score);
        }

    }
}
