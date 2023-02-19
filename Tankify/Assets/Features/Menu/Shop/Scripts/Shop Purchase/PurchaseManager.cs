using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Bazaar.Data;
using Bazaar.Poolakey.Data;
using Features.Menu.Shop.Scripts;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    private static PurchaseManager _instance;
    
    private bool isCafe = true;
    
    public static Market market;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public static PurchaseManager GetInstance(){
        return _instance;
    }
    
    void Start()
    {

        if (isCafe)
        {
            market = new Cafe();
        }
        else
        {
            
        }
        market.Initialize();
    }

    public string PurchaseGemFromShop(String id)
    {
        Result<PurchaseInfo> result = market.Purchase(id).Result;
        
        Debug.Log("Purchase Manager: ");
        Debug.Log(result);
        
        if(result.status == Status.Success)
        {
            return result.data.purchaseToken;
        }

        return "null";
    }

    public void Consume(string pt)
    {
        market.Consume(pt);
    }
    
}
