using System;
using System.Collections;
using System.Collections.Generic;
using Features.Menu.Shop.Scripts;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    
    private PurchaseManager _purchaseManager;
    
    private CurrencyController _currencyController;

    private static ShopManager _instance;
    
    private ShopManager(){}
    
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _purchaseManager = PurchaseManager.GetInstance();
        _currencyController = CurrencyController.GetInstance();
    }

    public static ShopManager GetInstance(){
        return _instance;
    }

    public void PurchaseGem(Item data)
    {
        string resultPurchaseToken = _purchaseManager.PurchaseGemFromShop(data.IdName);
        Debug.Log("SHOP MANAGE RES: ");
        Debug.Log(resultPurchaseToken);
        if (resultPurchaseToken != "null")
        {
            if (_currencyController.AddGem(data.amount))
            {
                _purchaseManager.Consume(resultPurchaseToken);
            }
        }
    }

    public void PurchaseCoinWithGem(Item data)
    {
        _currencyController.PurchaseCoinWithGem(data.amount, data.price);
    }
    
}
