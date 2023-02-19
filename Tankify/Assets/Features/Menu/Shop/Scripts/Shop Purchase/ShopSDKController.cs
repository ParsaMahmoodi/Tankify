using System;
using Bazaar.Data;
using Bazaar.Poolakey;
using UnityEngine;

namespace Features.Menu.Shop.Scripts
{
    public class ShopSDKController : MonoBehaviour
    {
        private static ShopSDKController _instance;
        private ShopSDKController(){}

        public static ShopSDKController GetInstance()
        {
            return _instance;
        }

        private void Awake()
        {
            _instance = this;
        }

        private SecurityCheck securityCheck;
        private Payment payment;

        private string KEY =
            "MIHNMA0GCSqGSIb3DQEBAQUAA4G7ADCBtwKBrwCayAFaNOAQhNojebyAiJPPSqcCKltD/3Oe0XUHq7Ay5v/pWS+Fif2m76pvPe+ogA8Njs2LbgmTnSUL7KZPO+YlCFuvMA6kSU0OeZ/R3rJfWFBL4tLL74jE3pgD0ujEZwjuFQqaqI6cMsP93FRta4dR7L/gLS/bbpP9bEQ+ykLlB/c6kIehB3po8sDo99BxsyhwXJUwReRMS0FUL3JcbQYFnr5r4EvwKCdg4nCxLDsCAwEAAQ==";
        
        void Start()
        {
            securityCheck = SecurityCheck.Enable(KEY);
            PaymentConfiguration paymentConfiguration = new PaymentConfiguration(securityCheck);
            
            payment = new Payment(paymentConfiguration);
            
            PaymentConnect(payment);
        }

        void OnApplicationQuit()
        {
            payment.Disconnect();
        }
            
        static async void PaymentConnect(Payment payment)
        {
            var result = await payment.Connect();
            print("connection to bazaar: " + result.ToString());
        }
    
        public static async void GetProductData(Payment payment)
        {
            var result = await payment.GetSkuDetails("productID");
            Debug.Log($"{result.message}, {result.stackTrace}");
            if (result.status == Status.Success)
            {
                foreach (var sku in result.data)
                {
                    Debug.Log(sku.ToString());
                }
            }
        }
    
        public static async void GetPurchases(Payment payment)
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                
            }
            #if UNITY_EDITOR
            
            #endif
            
            var result = await payment.GetPurchases();
            Debug.Log($"{result.message}, {result.stackTrace}");
            if (result.status == Status.Success)
            {
                foreach (var purchase in result.data)
                {
                    Debug.Log(purchase.ToString());
                }
            }
        }
    
        public static async void Subscription(Payment payment)
        {
            var result = await payment.Purchase("PRODUCT_ID");
            Debug.Log($"{result.message}, {result.stackTrace}");
            if (result.status == Status.Success)
            {
                var purchase = result.data;
                Debug.Log(purchase.ToString());
            }
        }
    
        public static async void Consume(Payment payment)
        {
            var result = await payment.Consume("PURCHASE_TOKEN");
        }
    }
}
