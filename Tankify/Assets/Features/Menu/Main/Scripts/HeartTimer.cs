using System.Collections;
using System.Collections.Generic;
using Features.Core.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class HeartTimer : MonoBehaviour
{
    [SerializeField]
    private DataController _data;

    [SerializeField]
    private float _timeLimit = 1f * 60f;

    private float _timer;

    [SerializeField] private Text _timeForNextHeart;
    
    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            UpdateTimerDisplay(_timer);
        }
        else
        {
            AddHeart();
        }
    }
    
    private void ResetTimer()
    {
        _timer = _timeLimit;
    }

    private void UpdateTimerDisplay(float time)
    {
        float min = Mathf.FloorToInt(time / 60);
        float sec = Mathf.FloorToInt(time % 60);

        string currentTime = "" + min + ":" + sec;
        _timeForNextHeart.text = currentTime;
    }

    private void AddHeart()
    {
        ResetTimer();
    }
}
