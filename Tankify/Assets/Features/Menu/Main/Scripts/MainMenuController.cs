using System;
using Features.Core.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Features.Menu.Main.Scripts
{
    public class MainMenuController : MonoBehaviour
    {

        [SerializeField]
        private Text _highScoreText;

        private DataController _dataController = DataController.GetInstance();

        private int _heartCount;
        
        [SerializeField]
        private Text _heartCounterText;

        private void Start()
        {
            RefreshData();
        }

        public void StartGame()
        {
            Debug.Log(_heartCount);

            if (_heartCount <= 0)
            {
                ShowError();
            }
            else
            {
                _dataController.HeartCount -= 1;
                SceneManager.LoadScene("GameScene");
            }
        }
    
        void ShowError()
        {
            Debug.Log("NO HEARTS LEFT");
        }

        public void ResetProgressData()
        {
            _dataController.HeartCount = 3;
            PlayerPrefs.SetInt("HeartCount", 3);
            PlayerPrefs.SetInt("HighScore", 0);
            RefreshData();
        }

        private void RefreshData()
        {
            _heartCount = PlayerPrefs.GetInt("HeartCount", 1);
            _heartCounterText.text = _dataController.HeartCount.ToString() + "/10";
            _highScoreText.text = "Best Score: " + PlayerPrefs.GetInt("HighScore", 0);
        }
        
    }
}
