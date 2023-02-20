using System.Threading.Tasks;
using Bazaar.Data;
using Bazaar.Poolakey;
using Bazaar.Poolakey.Data;
using UnityEngine;

public class Cafe : Market
{
    private SecurityCheck _securityCheck;
    private Payment _payment;

    private readonly string _key =
        "MIHNMA0GCSqGSIb3DQEBAQUAA4G7ADCBtwKBrwCayAFaNOAQhNojebyAiJPPSqcCKltD/3Oe0XUHq7Ay5v/pWS+Fif2m76pvPe+ogA8Njs2LbgmTnSUL7KZPO+YlCFuvMA6kSU0OeZ/R3rJfWFBL4tLL74jE3pgD0ujEZwjuFQqaqI6cMsP93FRta4dR7L/gLS/bbpP9bEQ+ykLlB/c6kIehB3po8sDo99BxsyhwXJUwReRMS0FUL3JcbQYFnr5r4EvwKCdg4nCxLDsCAwEAAQ==";
    
    public override async Task Initialize()
    {
        Debug.Log(_key);
        
        _securityCheck = SecurityCheck.Enable(_key);
        
        Debug.Log(_securityCheck.rsaPublicKey);
        
        PaymentConfiguration paymentConfiguration = new PaymentConfiguration(_securityCheck);
        
        Debug.Log(paymentConfiguration.securityCheck);
        
        _payment = new Payment(paymentConfiguration);
        
        Debug.Log(_payment.version);
        
        await PaymentConnect(_payment);
        
        Debug.Log("INIT CAFE");
    }

    public override async Task<Result<PurchaseInfo>> Purchase(string id)
    {
        #if UNITY_EDITOR
            return new Result<PurchaseInfo>(Status.Success, "string message", "string stackTrace = null");
        #endif
        
        if (_payment != null)
        {
            
            Debug.Log("_payment is not null and we are in IF in Purchase in CAFE");
            
            var result = await _payment.Purchase(id);
            Debug.Log($"{result.message}, {result.stackTrace}");
            if (result.status == Status.Success)
            {
                Debug.Log("second IF in Purchase in CAFE");

                var purchase = result.data;
                Debug.Log(purchase);
                Debug.Log(purchase.ToString());

                Debug.Log("Purchase-CAFE");
                Debug.Log(result);

                return result;
            }
        }
        
        Debug.Log("Purchase in CAFE returning null");
        
        return null;
    }

    static async Task PaymentConnect(Payment payment)
    {
        Debug.Log("Connecting to payment");
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

    public override async Task<bool> Consume(string purchaseToken)
    {
        #if UNITY_EDITOR
            return true;
        #endif
        
        var result = await _payment.Consume(purchaseToken);
        Debug.Log("Consumed");
        Debug.Log(result);
        return true;
    }

}
