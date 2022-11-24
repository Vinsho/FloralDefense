using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    PlayerAttributes attributes;
    Globals globals;
    GUI myGUI;
    // Start is called before the first frame update
    void Start()
    {
        attributes = FindObjectOfType<PlayerAttributes>();
        globals = FindObjectOfType<Globals>();
        myGUI = FindObjectOfType<GUI>();
    }

    public void AddResources(int amount){
        for(int i = 0; i < amount; i++){
            Resource resource = (Resource)Random.Range(0, 3);
            switch (resource){
                case Resource.seedling:
                    attributes.seedlings += 1;
                    break;
                case Resource.mana:
                    attributes.mana += 1;
                    break;
                case Resource.blood:
                    attributes.blood += 1;
                    break;
            }
        }
        myGUI.SetResources(attributes.seedlings, attributes.mana, attributes.blood);
    }

    public void AddCoins(int amount, float chance){
        float randomFloat = Random.Range(0f, 1f);
        if (randomFloat <= chance){
            globals.AddCoins(amount);
        }
    }

    public void AddXp(int amount){
        globals.AddXp(amount);
    }
}
