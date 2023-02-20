using UnityEngine;

namespace Features.Menu.Shop.Scripts
{
    public class ShopItemGemController : ShopItemController<Gems>
    {

        private ShopManager _shopManager;

        // Start is called before the first frame update
        void Start()
        {
            _shopManager = ShopManager.GetInstance();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        protected override void PurchaseFunction(Item data)
        {
            Debug.Log("PurchaseFunction IN ShopItemGemController");
            Debug.Log(Data);
            _shopManager.PurchaseGem(data);
        }
        
        private void InitializeItem()
        {
            AmountText.text = Data.Amount.ToString() + "\n" + " عدد ";
            Image.sprite = Data.Sprite;
            ButtonText.text = Data.Price.ToString() + "\n" + " تومان ";
        }
        
        public void Setup(Gems data)
        {
            Data = data;
            InitializeItem();
        }
        
        public void PurchaseButton()
        {
            Debug.Log("PurchaseButton clicked");
            Debug.Log(Data);
            PurchaseFunction(Data);
        }
    }
}
