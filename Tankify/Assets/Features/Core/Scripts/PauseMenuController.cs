using System;
using Features.Core.Scripts.EnemyScripts;
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
        private GameObject _enemySpawnGameObject;

        private EnemySpawn _enemySpawnComponent;

        private void Start()
        {
            _enemySpawnComponent = _enemySpawnGameObject.GetComponent<EnemySpawn>();
        }

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
            _gameManager.PauseGame();
            _pauseMenuUI.SetActive(true);
            
            // _enemySpawnComponent.PauseSpawn();
            // _gameManager.gameIsPaused = true;
            
            _previousHighScoreText.text = "Previous High Score: " + PlayerPrefs.GetInt("HighScore", 0);
        }
        
        private void Resume()
        {
            _gameManager.ResumeGame();
            _pauseMenuUI.SetActive(false);
            
            // _gameManager.gameIsPaused = false;
            // _enemySpawnComponent.ResumeSpawn();
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
