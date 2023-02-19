using System;
using Features.Menu.Main.Scripts;
using RTLTMPro;
using UnityEngine;

public class CurrencyController :  MonoBehaviour
{
    [SerializeField] private CurrencyControllerUI _currencyControllerUI;

    private DataController _dataController;

    private static CurrencyController _instance;
    
    public static event Action OnCurrencyChange;

    
    private CurrencyController(){}

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _dataController = DataController.GetInstance();
    }

    public static CurrencyController GetInstance(){
        return _instance;
    }
    
    public int GetGemCount()
    {
        return _dataController.GetGemCount();
    }
    
    public int GetCoinCount()
    {
        return _dataController.GetCoinCount();
    }

    public bool AddGem(int amount)
    {
        _dataController.SetGemCount(GetGemCount() + amount);
        // _currencyControllerUI.UpdateDisplayData();
        OnCurrencyChange?.Invoke();
        return true;
    }
    

    public void PurchaseCoinWithGem(int coinAmount, int gemAmount)
    {
        int availableGemCount = GetGemCount();
        int availableCoinCount = GetCoinCount();

        if (gemAmount > availableGemCount)
        {
            Debug.Log("LOW ON GEMS");
        }
        else
        {
            _dataController.SetCoinCount(availableCoinCount + coinAmount);
            _dataController.SetGemCount(availableGemCount - gemAmount);
            // _currencyControllerUI.UpdateDisplayData();
            OnCurrencyChange?.Invoke();
        }
    }

}
