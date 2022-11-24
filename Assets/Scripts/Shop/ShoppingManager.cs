using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingManager : MonoBehaviour
{
    Player player;
    FlowerPlacement flowerPlacement;
    GUI myGUI;
    private AvailableFlowers availableFlowers;

    private void Start() {
        player = FindObjectOfType<Player>();
        flowerPlacement = FindObjectOfType<FlowerPlacement>();
        availableFlowers = FindObjectOfType<AvailableFlowers>();
        myGUI = FindObjectOfType<GUI>();
    }

    public void Buy(int idx){
        if(player.attributes.IsDead()){return;}
        
        ShopItem shopItem = availableFlowers.GetActiveFlowerAtIndex(idx);

        if (player.attributes.CanAfford(shopItem.seedlings, shopItem.mana, shopItem.blood)){
            player.attributes.LoseResources(shopItem.seedlings, shopItem.mana, shopItem.blood);
            if (shopItem.prefab.tag == "Flower"){
                flowerPlacement.StartFlowerPlacement(shopItem.prefab);
            }
        }
    }
}
