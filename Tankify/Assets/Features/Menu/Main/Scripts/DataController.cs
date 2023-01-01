using UnityEngine;

namespace Features.Menu.Main.Scripts
{
    public class DataController
    {
        public int HeartCount;
        public string LastRemainingTimeForNextHeart;
        public string LastSystemTime;
        
        private static DataController _instance = new DataController();
        private DataController(){}
    
        public int GetHeartCount()
        {
            return HeartCount;
        }
    
        public void ReduceHeart()
        {
            HeartCount--;
        }

        public void IncreaseHeart()
        {
            HeartCount++;
        }

        public static int CheckHeart()
        {
            return PlayerPrefs.GetInt("HeartCount", 3);
        }
        
        public static DataController GetInstance(){
            return _instance;
        }

        public void SaveHeartCounterState(string remainingTime, string currentTime)
        {
            PlayerPrefs.SetInt("HeartCount", HeartCount);
            PlayerPrefs.SetString("RemainingTimeForNextHeart", remainingTime);
            PlayerPrefs.SetString("LastSystemTime", currentTime);
        }

        public void LoadHeartCounterState()
        { 
            HeartCount = PlayerPrefs.GetInt("HeartCount", 0);
            LastRemainingTimeForNextHeart = PlayerPrefs.GetString("RemainingTimeForNextHeart", "0");
            LastSystemTime = PlayerPrefs.GetString("LastSystemTime", "0");
        }

    }
}
