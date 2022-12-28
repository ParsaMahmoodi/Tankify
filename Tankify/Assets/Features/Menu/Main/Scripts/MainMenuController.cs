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
        private DataController _data;
    
        [SerializeField]
        private Text _highScoreText;

        private int _heartCount;

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
                SceneManager.LoadScene("GameScene");
            }

        }
    
        void ShowError()
        {
            Debug.Log("NO HEARTS LEFT");
        }


        public void ResetProgressData()
        {
            PlayerPrefs.SetInt("HeartCount", 3);
            PlayerPrefs.SetInt("HighScore", 0);
            
            RefreshData();
        }

        private void RefreshData()
        {
            _heartCount = PlayerPrefs.GetInt("HeartCount", 1);
            _highScoreText.text = "Best Score: " + PlayerPrefs.GetInt("HighScore", 0);
        }
        
    }
}
