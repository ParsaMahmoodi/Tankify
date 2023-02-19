using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Menu.Shop.Scripts
{
    public abstract class ShopItemHolderController : MonoBehaviour
    {
        
        [SerializeField] protected ShopItemsData shopItemsData;

        [SerializeField] protected GameObject itemHolder;



    }
}