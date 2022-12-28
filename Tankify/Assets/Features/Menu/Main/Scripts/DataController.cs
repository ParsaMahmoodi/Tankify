using UnityEngine;

namespace Features.Menu.Main.Scripts
{
    public class DataController
    {
        private int _heartCount = 0;
    
        public int GetHeartCount()
        {
            return _heartCount;
        }
    
        public void ReduceHeart()
        {
            _heartCount--;
        }

        public void IncreaseHeart()
        {
            _heartCount++;
        }

        public static int CheckHeart()
        {
            return PlayerPrefs.GetInt("HeartCount", 3);
        }

    }
}
