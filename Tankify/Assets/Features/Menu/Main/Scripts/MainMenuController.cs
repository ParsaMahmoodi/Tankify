using System.Collections;
using System.Collections.Generic;
using Features.Core.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    [SerializeField]
    private DataController _data;
    
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
