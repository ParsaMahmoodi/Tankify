using UnityEngine;

namespace Features.Core.Scripts.EnemyScripts
{
    [System.Serializable]
    public class Enemy
    {
        public string name;
        public int health;
        public int damage;
        public float spawnProbability;
        
        public EnemyType type;

        public GameObject prefab;

    }
}