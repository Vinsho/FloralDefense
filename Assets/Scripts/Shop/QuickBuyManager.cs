using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickBuyManager : MonoBehaviour
{
    private ShoppingManager shoppingManager;
    private bool initialized = false;

    private void Start() {
        shoppingManager = FindObjectOfType<ShoppingManager>();
    }

    public void ToggleQuickBuy(bool enabled){
        initialized = enabled;
    }

    public void BuyAtGivenIndex(int idx){
        if (initialized){
            shoppingManager.Buy(idx);
            initialized = false;
        }
    }
    
}
