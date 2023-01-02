using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Features.Core.Scripts
{
    public class PauseMenuController : MonoBehaviour
    {
        
        [SerializeField]
        private GameManager _gameManager;
        
        [SerializeField]
        private GameObject _pauseMenuUI;
    
        [SerializeField]
        private Text _previousHighScoreText;

        [SerializeField]
        private GameObject _enemySpawn;
        
        public void PauseButton()
        {
            if (_gameManager.gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        private void Pause()
        {
            _pauseMenuUI.SetActive(true);
            _gameManager.gameIsPaused = true;
            _previousHighScoreText.text = "Previous High Score: " + PlayerPrefs.GetInt("HighScore", 0);
        }
        
        private void Resume()
        {
            _pauseMenuUI.SetActive(false);
            _gameManager.gameIsPaused = false;
            _enemySpawn.GetComponent<EnemySpawn>().ResumeSpawn();
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
