using System.Collections.Generic;
using UnityEngine;

namespace Features.Core.Scripts.EnemyScripts
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private List<Enemy> enemies = new List<Enemy>();

        public List<Enemy> Enemies => enemies;
    }
}
