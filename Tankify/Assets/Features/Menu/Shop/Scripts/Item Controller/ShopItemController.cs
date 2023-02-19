using System;
using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Menu.Shop.Scripts
{
    public abstract class ShopItemController<T> : MonoBehaviour
    {
        [SerializeField] protected RTLTextMeshPro amountText;
        [SerializeField] protected Image image;
        [SerializeField] protected Button button;
        [SerializeField] protected RTLTextMeshPro buttonText;
        
        protected T Data;


        public RTLTextMeshPro AmountText
        {
            get => amountText;
            set => amountText = value;
        }
        
        public Image Image
        {
            get => image;
            set => image = value;
        }
        
        public Button Button
        {
            get => button;
            set => button = value;
        }
        
        public RTLTextMeshPro ButtonText
        {
            get => buttonText;
            set => buttonText = value;
        }


        protected abstract void PurchaseFunction(Item data);

    }
}