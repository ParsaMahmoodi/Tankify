using UnityEngine;

namespace Features.Core.Scripts
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public new string name;

        public int health;

        public int damage;

    }
}
