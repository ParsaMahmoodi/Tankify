using System.Collections.Generic;
using UnityEngine;

namespace Features.Core.Scripts.EnemyScripts
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField] private List<Enemy> enemies = new List<Enemy>();
        
        [SerializeField] public AnimationCurve spawnTimerCurve;
        [SerializeField] public AnimationCurve spawnAmountCurve;
        
        public List<Enemy> Enemies => enemies;
    }
}
