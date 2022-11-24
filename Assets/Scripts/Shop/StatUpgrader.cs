using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StatUpgrader : MonoBehaviour
{
    [SerializeField] Stat stat;
    [SerializeField] TextMeshProUGUI currentAmountText;
    [SerializeField] TextMeshProUGUI upgradeCostText;

    private Player player;
    private int upgradeCost = 2;
    private float currentAmount;
    
    public delegate float IncreaseMethod();
    IncreaseMethod increaseMethod;

    void Start()
    {
        player = FindObjectOfType<Player>();
        SetupUprader();
        currentAmountText.text = System.Math.Round(currentAmount, 1).ToString();
        upgradeCostText.text = upgradeCost.ToString();
    }

    void SetupUprader(){
        if(stat == Stat.maxHealth){
            increaseMethod = player.attributes.IncreaseMaxHealth;
            currentAmount = player.attributes.maxHealth;
        }
        else if(stat == Stat.castSpeed){
            increaseMethod = player.attributes.IncreseCastSpeed;
            currentAmount = player.attributes.castSpeed;
        }
        else if(stat == Stat.spellPower){
            increaseMethod = player.attributes.IncreaseSpellPower;
            currentAmount = player.attributes.spellPower;
        }
        else if(stat == Stat.moveSpeed){
            increaseMethod = player.attributes.IncreaseMoveSpeed;
            currentAmount = player.attributes.moveSpeed;
        }
    }

    public void Upgrade(){
        if(!player.attributes.CanAfford(0, 0, upgradeCost)){return;}

        currentAmount = increaseMethod();
        player.attributes.LoseResources(0, 0, upgradeCost);
        currentAmountText.text = System.Math.Round(currentAmount, 1).ToString();

        upgradeCost *= 2;
        upgradeCostText.text = upgradeCost.ToString();
    }
}
