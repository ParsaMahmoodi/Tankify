using UnityEngine;

namespace Features.Core.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public bool _gameOver = false;
        public bool _gameIsPaused = false;

        [SerializeField]
        private GameOverScreen _gameOverScreen;

        public void GameOver(int score)
        {
            _gameOverScreen.Setup(score);
        }

    }
}
