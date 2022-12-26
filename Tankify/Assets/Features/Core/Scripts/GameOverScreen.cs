using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Features.Core.Scripts
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField]
        private Text _scoreText;
        
        [SerializeField]
        private Text _highScoreText;
    
        public void Setup(int score = 0)
        {
            gameObject.SetActive(true);
            _scoreText.text = "Score: " + score.ToString();
            _highScoreText.text = "Previous High Score: " + PlayerPrefs.GetInt("HighScore", 0);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void ExitGame()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
