using System;
using UnityEngine;
using UnityEngine.UI;

namespace Features.Menu.Shop.Scripts
{
    [Serializable]
    public class Item
    {
        public String idName;
        public int price;
        public int amount;
        public Sprite sprite;
        public ResourceType resourceType;
        
        public String IdName
        {
            get => idName;
            set => idName = value;
        }
        
        public int Price
        {
            get => price;
            set => price = value;
        }
        
        public int Amount
        {
            get => amount;
            set => amount = value;
        }
        
        public Sprite Sprite
        {
            get => sprite;
            set => sprite = value;
        }
        
        public ResourceType ResourceType
        {
            get => resourceType;
            set => resourceType = value;
        }
        
    }

}
