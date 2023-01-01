using UnityEngine;

namespace Features.Core.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public new string health;
    }
}
