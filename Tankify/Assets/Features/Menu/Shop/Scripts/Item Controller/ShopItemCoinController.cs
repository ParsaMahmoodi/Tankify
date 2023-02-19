using System.Collections.Generic;
using UnityEngine;

namespace Features.Menu.Shop.Scripts
{
    public class ShopItemCoinController : ShopItemController<Coins>
    {

        private CurrencyController _currencyController;
        private ShopManager _shopManager;



        // Start is called before the first frame update
        void Start()
        {
            _currencyController  = CurrencyController.GetInstance();
            _shopManager = ShopManager.GetInstance();
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        protected override void PurchaseFunction(Item data)
        {
            _shopManager.PurchaseCoinWithGem(data);
        }
        
        private void InitializeItem()
        {
            AmountText.text = Data.Amount.ToString() + "\n" + " عدد ";
            Image.sprite = Data.Sprite;
            ButtonText.text = Data.Price.ToString() + "\n" + " الماس ";
        }
        
        public void Setup(Coins data)
        {
            Data = data;
            InitializeItem();
        }

        public void PurchaseButton()
        {
            PurchaseFunction(Data);
        }

    }
}
