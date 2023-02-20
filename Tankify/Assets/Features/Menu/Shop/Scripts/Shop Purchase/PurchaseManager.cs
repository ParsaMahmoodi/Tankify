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
    
    async void Start()
    {

        if (isCafe)
        {
            market = new Cafe();
        }
        else
        {
            
        }
        await market.Initialize();
    }

    public string PurchaseGemFromShop(String id)
    {
        
        Debug.Log("PurchaseGemFromShop in PurchaseManager");
        
        Result<PurchaseInfo> result = market.Purchase(id).Result;
        
        Debug.Log(result);
        Debug.Log(result.data);
        Debug.Log(result.message);
        Debug.Log(result.status);
        Debug.Log(result.stackTrace);
        
        
        if(result.status == Status.Success)
        {
            Debug.Log("IF IN PurchaseGemFromShop in PurchaseManager");
            
            Debug.Log(result.data.purchaseToken);
            
            return result.data.purchaseToken;
        }
        
        Debug.Log("PurchaseGemFromShop in PurchaseManager is returning null");
        
        return "null";
    }

    public void Consume(string pt)
    {
        market.Consume(pt);
    }
    
}
