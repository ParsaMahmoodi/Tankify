using UnityEngine;

namespace Features.Core.Scripts.Player
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public float health;
    }
}
