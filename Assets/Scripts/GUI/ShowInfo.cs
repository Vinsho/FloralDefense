using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    private AvailableFlowers availableFlowers;
    private AvailableSpells availableSpells;
    [SerializeField] GameObject infoBox;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI cost;
    [SerializeField] TextMeshProUGUI hotkey;

    // Start is called before the first frame update
    void Start()
    {
        availableFlowers = FindObjectOfType<AvailableFlowers>();
        availableSpells = FindObjectOfType<AvailableSpells>();
    }

    public void ToggleFlowerInfo(int idx){ 
        if(infoBox.activeSelf){
            infoBox.SetActive(false);
        }else{
            ShopItem flower = availableFlowers.GetActiveFlowerAtIndex(idx);
            infoBox.SetActive(true);
            description.text = flower.description;
            cost.text = flower.seedlings.ToString();
        }
    }

    public void ToggleSpellInfo(int idx){ 
        if(infoBox.activeSelf){
            infoBox.SetActive(false);
        }else{
            Spell spell = availableSpells.GetActiveSpellAtIndex(idx);
            infoBox.SetActive(true);
            description.text = spell.description;
            cost.text = spell.manaCost.ToString();
            hotkey.text = Constants.spellHotkeyMap[idx];
        }
    }
}
