using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableFlowers : MonoBehaviour
{
    [SerializeField] ShopItem sunflower;
    [SerializeField] ShopItem shrubbery;

    private Dictionary<Flowers, ShopItem> availableFlowers = new Dictionary<Flowers, ShopItem>();
    public Dictionary<int, Flowers> activeFlowers = new Dictionary<int, Flowers>();

    void Start() {
        availableFlowers[Flowers.sunflower] = sunflower;    
        availableFlowers[Flowers.shrubbery] = shrubbery;    

        // TODO this should be set from memory, when active flower selecting is enabled.
        activeFlowers[1] = Flowers.sunflower;
        activeFlowers[2] = Flowers.shrubbery;
    }

    public ShopItem GetFlower(Flowers flower){
        return availableFlowers[flower];
    }

    public ShopItem GetActiveFlowerAtIndex(int idx){
        return GetFlower(activeFlowers[idx]);
    }
}
