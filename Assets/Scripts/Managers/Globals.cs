using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public int coins;
    public int xp;
    public int playerLevel;

    private GUI myGui;

    void Start()
    {
        myGui = FindObjectOfType<GUI>();
        InitCoins();
        InitXp();
        InitPlayerLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitCoins(){
        coins = PlayerPrefs.GetInt("coins", 0);
        myGui.SetCoins(coins);
    }

    void InitXp(){
        xp = PlayerPrefs.GetInt("xp", 0);
        myGui.SetXp(xp, Constants.levelToXpNeeded[playerLevel+1]);
    }

    void InitPlayerLevel(){
        playerLevel = PlayerPrefs.GetInt("playerLevel", 0);
        myGui.SetPlayerLevel(playerLevel);
    }

    public void AddCoins(int amount){
        coins += amount;
        PlayerPrefs.SetInt("coins", coins);
        myGui.SetCoins(coins);
    }

    public void AddXp(int amount){
        xp += amount;
        int xpNeeded = Constants.levelToXpNeeded[playerLevel+1];
        if (xp >= xpNeeded){
            IncreasePlayerLevel();
            xp -= xpNeeded;
        }
        myGui.SetXp(xp, Constants.levelToXpNeeded[playerLevel+1]);
        PlayerPrefs.SetInt("xp", xp);
    }

    public void IncreasePlayerLevel(){
        playerLevel += 1;
        myGui.SetPlayerLevel(playerLevel);
        PlayerPrefs.SetInt("playerLevel", playerLevel);
    }
}
