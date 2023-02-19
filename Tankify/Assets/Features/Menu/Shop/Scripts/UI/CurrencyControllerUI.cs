using System.Collections;
using System.Collections.Generic;
using RTLTMPro;
using UnityEngine;

public class CurrencyControllerUI : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro coinCount;
    [SerializeField] private RTLTextMeshPro gemCount;

    private CurrencyController _currencyController;

    
    // Start is called before the first frame update
    void Start()
    {
        _currencyController  = CurrencyController.GetInstance();
        CurrencyController.OnCurrencyChange += UpdateDisplayData;
        UpdateDisplayData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateDisplayData()
    {
        coinCount.text = _currencyController.GetCoinCount().ToString();
        gemCount.text = _currencyController.GetGemCount().ToString();
    }
    
    

}
