using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

    public bool PurchaseGemFromShop(String id)
    {
        Debug.Log("Purchse Manager : PurchaseGemFromShop");
        if(market.Purchase(id).Result)
        {
            return true;
        }

        return false;
    }

    public void Consume(string id)
    {
        market.Consume("PURCHASE TOKEN");
    }
    
}
