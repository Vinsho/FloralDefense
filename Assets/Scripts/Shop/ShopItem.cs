using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New ShopItem", menuName = "ShopItem")]
public class ShopItem: ScriptableObject
{
    public int seedlings = 0;
    public int mana = 0;
    public int blood = 0;
    public GameObject prefab;
    public GameObject portrait;
    public string description = "Tis' a sunflower that shoots.";
}
