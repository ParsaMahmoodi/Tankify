using System.Threading.Tasks;
using Bazaar.Data;
using Bazaar.Poolakey;
using UnityEngine;

public class Cafe : Market
{
    private SecurityCheck _securityCheck;
    private Payment _payment;

    private readonly string _key =
        "MIHNMA0GCSqGSIb3DQEBAQUAA4G7ADCBtwKBrwCayAFaNOAQhNojebyAiJPPSqcCKltD/3Oe0XUHq7Ay5v/pWS+Fif2m76pvPe+ogA8Njs2LbgmTnSUL7KZPO+YlCFuvMA6kSU0OeZ/R3rJfWFBL4tLL74jE3pgD0ujEZwjuFQqaqI6cMsP93FRta4dR7L/gLS/bbpP9bEQ+ykLlB/c6kIehB3po8sDo99BxsyhwXJUwReRMS0FUL3JcbQYFnr5r4EvwKCdg4nCxLDsCAwEAAQ==";
    
    public override void Initialize()
    {
        _securityCheck = SecurityCheck.Enable(_key);
        PaymentConfiguration paymentConfiguration = new PaymentConfiguration(_securityCheck);
        
        _payment = new Payment(paymentConfiguration);
        
        PaymentConnect(_payment);
        Debug.Log("INIT CAFE");
    }

    public override async Task<bool> Purchase(string id)
    {
        #if UNITY_EDITOR
            return true;
        #endif
        
        if (_payment != null)
        {
            var result = await _payment.Purchase(id);
            Debug.Log($"{result.message}, {result.stackTrace}");
            if (result.status == Status.Success)
            {
                var purchase = result.data;
                Debug.Log(purchase.ToString());

                Debug.Log("Purchase-CAFE");
                return true;
            }
        }

        return false;
    }

    static async void PaymentConnect(Payment payment)
    {
        var result = await payment.Connect();
        Debug.Log("connection to CAFE: " + result.ToString());
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
        // if (Application.platform == RuntimePlatform.WindowsEditor)
        // {
        //     
        // }
        // #if UNITY_EDITOR
        //
        // #endif
        
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

    public override async Task<bool> Consume(string id)
    {
        #if UNITY_EDITOR
            return true;
        #endif
        
        var result = await _payment.Consume("PURCHASE_TOKEN");
        return true;
    }

}
