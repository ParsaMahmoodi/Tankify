using System;
using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Features.Menu.Main.Scripts
{
    public class HeartTimer : MonoBehaviour
    {
        private DataController _dataController = DataController.GetInstance();

        [Space(10)]
        [Header("Heart Secttion")]
        [Tooltip("Timer value should be between 25 and 100.")]
        [Range(25f, 100f)] [SerializeField] private float _timeLimit = 1f * 60f;
        [SerializeField] private RTLTextMeshPro _timeForNextHeart;
        [SerializeField] private RTLTextMeshPro _heartCounterText;


        private float _timer;

        void Start()
        { 
            UpdateHeartCounterText();
            LoadHeartState();
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

            string currentTime = "" + sec + ":" + min;
            _timeForNextHeart.text = currentTime;
        }

        private void UpdateHeartCounterText()
        {
            _heartCounterText.text = "10/" + _dataController.HeartCount.ToString();
        }

        private void AddHeart()
        {
            ResetTimer();
            if (_dataController.HeartCount < 10)
            {
                _dataController.HeartCount += 1;
                UpdateHeartCounterText();
            }
        }

        private void Awake()
        {
            LoadHeartState();
        }

        private void OnEnable()
        {
            LoadHeartState();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            SaveHeartState();
        }

        private void OnApplicationQuit()
        {
            SaveHeartState();
        }

        private void OnDestroy()
        {
            SaveHeartState();
        }

        private void SaveHeartState()
        {
            string remainingTime = _timer.ToString();
            DateTime currentTime = DateTime.Now;
            _dataController.SaveHeartCounterState(remainingTime, currentTime.ToString());
        }

        [UnityEngine.ContextMenu("Load Heart State")]
        private void LoadHeartState()
        {
            _dataController.LoadHeartCounterState();
            float timeDiff = Convert.ToSingle((DateTime.Now - DateTime.Parse(_dataController.LastSystemTime)).TotalSeconds);
            CalculateHearts(timeDiff);
        }

        private void CalculateHearts(float timeDifference)
        {
            float timeElapsed = float.Parse(_dataController.LastRemainingTimeForNextHeart) - timeDifference;

            if (timeElapsed > 0)
            {
                _timer = timeElapsed;
            }

            else
            {
                AddHeart();
                _dataController.LastRemainingTimeForNextHeart = _timeLimit.ToString();
                CalculateHearts(-1 * (timeElapsed));
            }
            

        }
    }
}
