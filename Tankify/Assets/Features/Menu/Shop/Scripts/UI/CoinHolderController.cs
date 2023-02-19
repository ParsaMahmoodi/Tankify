using System.Collections.Generic;
using UnityEngine;

namespace Features.Menu.Shop.Scripts
{
    public class CoinHolderController : ShopItemHolderController
    {
        
        private List<Coins> _coinsList = new List<Coins>();
        
        [SerializeField] protected ShopItemCoinController itemPrefab;
        
        void Start()
        {
            _coinsList = shopItemsData.Coins;
            
            InstantiateShopItems(_coinsList, itemHolder, itemPrefab);
        }

        private void InstantiateShopItems(List<Coins> cList, GameObject iHolder, ShopItemCoinController iPrefab)
        {
            foreach (var item in cList)
            {
                var instantiatedItem = Instantiate(iPrefab, iHolder.transform);
                instantiatedItem.Setup(item);
            }
        }
        
    }
}