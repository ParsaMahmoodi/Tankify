using System;
using Features.Core.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Menu.Main.Scripts
{
    public class MainMenuController : MonoBehaviour
    {
    
        [SerializeField]
        private DataController _data;
    
        [SerializeField]
        private Text _highScoreText;

        private void Start()
        {
            _highScoreText.text = "Best Score: " + PlayerPrefs.GetInt("HighScore", 0);
        }

        public void StartGame()
        {
            Debug.Log(PlayerPrefs.GetInt("HeartCount"));

            // if (heartCount <= 0)
            // {
            //     ShowError();
            // }
            // else
            // {
            //     SceneManager.LoadScene("GameScene");
            // }

        }
    
        void ShowError()
        {
        
        }

    }
}
