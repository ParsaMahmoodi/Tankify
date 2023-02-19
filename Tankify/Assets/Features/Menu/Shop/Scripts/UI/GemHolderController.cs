using System.Collections.Generic;
using UnityEngine;

namespace Features.Menu.Shop.Scripts
{
    public class GemHolderController : ShopItemHolderController
    {

        private List<Gems> _gemsList = new List<Gems>();
        
        [SerializeField] protected ShopItemGemController itemPrefab;

        void Start()
        {
             _gemsList = shopItemsData.Gems;
            
            InstantiateShopItems(_gemsList, itemHolder, itemPrefab);
        }
        
        void InstantiateShopItems(List<Gems> list, GameObject iHolder, ShopItemGemController iPrefab)
        {
            foreach (var item in list)
            {
                
                var instantiatedItem = Instantiate(iPrefab, iHolder.transform);
                instantiatedItem.Setup(item);
            }
        }
    }
}