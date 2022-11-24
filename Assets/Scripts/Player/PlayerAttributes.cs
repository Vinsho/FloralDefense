using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    Globals globals;
    public GUI gui;

    // Attack animation takes 0.33s
    // attackSpeed 0.5 means it takes 0.66s to attack
    private const float attackAnimationDuration = 0.33f;
    private const float castingAnimationDuration = 0.66f * 2f;

    public float damage = 1;
    public float maxHealth = 5;
    public float castSpeed = 1f;
    public float moveSpeed = 1f;
    public float spellPower = 1f;

    public int seedlings = 8;
    public int mana = 2;
    public int blood = 0;

    public float attackRange = 0.5f;
    public float attackSpeed;
    public float step;

    private float health;


    void Start()
    {
        health = maxHealth;
        gui = FindObjectOfType<GUI>();
        gui.SetResources(seedlings, mana, blood);
        globals = FindObjectOfType<Globals>();
    }

    public void RecieveDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        gui.SetPlayerHealth(health, maxHealth);
    }

    public float IncreaseMaxHealth()
    {
        maxHealth += 1;
        health += 1;
        gui.SetPlayerHealth(health, maxHealth);
        return maxHealth;
    }

    public float IncreaseSpellPower()
    {
        spellPower += 0.1f;
        return spellPower;
    }

    public float IncreseCastSpeed()
    {
        castSpeed += 0.1f;
        return castSpeed;
    }

    public float IncreaseMoveSpeed()
    {
        moveSpeed += 0.2f;
        return moveSpeed;
    }

    public void LoseResources(int lostSeedlings = 0, int lostMana = 0, int lostBlood = 0)
    {
        seedlings -= lostSeedlings;
        mana -= lostMana;
        blood -= lostBlood;
        gui.SetResources(seedlings, mana, blood);
    }

    public bool CanAfford(int seedlingsAmount, int manaAmount, int bloodAmount)
    {
        bool canAfford = (seedlingsAmount <= seedlings) && (manaAmount <= mana) && (bloodAmount <= blood);
        if (!canAfford)
        {
            gui.SendNotification("Not enough resources!");
        }
        return canAfford;
    }

    public float GetCastDuration(float spellCastDuration)
    {
        return ((castingAnimationDuration / castSpeed) * spellCastDuration);
    }

    public float afterDamageAnimationDuration
    {
        get { return ((attackAnimationDuration / attackSpeed) * (1 / 4f)); }
    }

    public float damageAnimationDuration
    {
        get { return ((attackAnimationDuration / attackSpeed) * (3 / 4f)); }
    }

    public float CalculateSpellDamage(float damage)
    {
        return damage * spellPower;
    }

    public bool IsDead(bool sendNotification = true)
    {
        if (health == 0 && sendNotification)
        {
            gui.SendNotification("Dead man doesn't move!");
        }
        return health == 0;
    }
}
