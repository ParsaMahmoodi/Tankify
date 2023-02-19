using UnityEngine;

namespace Features.Data
{
    [CreateAssetMenu(fileName = "Resources Data", menuName = "ResourcesData")]
    public class ResourcesData : ScriptableObject
    {
        public int gem;
        public int coin;
    }
}