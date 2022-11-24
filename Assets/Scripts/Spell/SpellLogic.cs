using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLogic : MonoBehaviour
{
    float lifeSpan;
    private Spell spell;
    void Update()
    {
        Destroy(gameObject, lifeSpan);
    }

    private void ApplySlow(Enemy enemy){
        if(spell != null && spell.slowPercentage != 0){
            enemy.ApplySlow(spell.slowPercentage, spell.slowDuration);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Enemy"){
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            ApplySlow(enemy);
        }
    }

    public void Initialize(Spell castedSpell, Vector2 targetPosition){
        spell = castedSpell;
        lifeSpan = castedSpell.duration;

        if(castedSpell.spellType == SpellType.projectile){
            GetComponent<SpellProjectile>().Initialize(castedSpell, targetPosition);
        }else{
            GetComponent<GroundPlacedSpell>().Initialize(targetPosition);
        }
    }
}
