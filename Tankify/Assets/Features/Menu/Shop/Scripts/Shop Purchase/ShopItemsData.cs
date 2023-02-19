using System.Collections.Generic;
using Features.Menu.Main.Scripts;
using UnityEngine;

namespace Features.Menu.Shop.Scripts
{
    [CreateAssetMenu(fileName = "ShopItemData", menuName = "ShopItemData")]
    public class ShopItemsData : ScriptableObject
    {
        [SerializeField] private List<Coins> coins = new List<Coins>();
        [SerializeField] private List<Gems> gems = new List<Gems>();
        [SerializeField] private List<Chests> chests = new List<Chests>();

        public List<Coins> Coins => coins;
        public List<Gems> Gems => gems;
        public List<Chests> Chests => chests;

        public int freeHeart;
        public int freeHeartTime;

        public int freeCoin;
        public int freeCoinTime;
    }
}
