// using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;


namespace Features.Menu.Shop.Scripts
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private float targetValueGem;
        [SerializeField] private float targetValueCoin;

        void Start()
        {
            
        }
        
        public void SetupShopMenu()
        {
            gameObject.SetActive(true);
        }

        public void CloseShopMenu()
        {
            gameObject.SetActive(false);
        }

        public void AddGemFromTopBar()
        {
            SetupShopMenu();
            scrollRect.verticalNormalizedPosition = targetValueGem;
        }
        
        public void AddCoinFromTopBar()
        {
            SetupShopMenu();
            scrollRect.verticalNormalizedPosition = targetValueCoin;
        }
        
    }
}
