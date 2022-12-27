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
            if (_gameManager._gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        public void Pause()
        {
            _pauseMenuUI.SetActive(true);
            _gameManager._gameIsPaused = true;
            _previousHighScoreText.text = "Previous High Score: " + PlayerPrefs.GetInt("HighScore", 0);
        }
        
        public void Resume()
        {
            _pauseMenuUI.SetActive(false);
            _gameManager._gameIsPaused = false;
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
