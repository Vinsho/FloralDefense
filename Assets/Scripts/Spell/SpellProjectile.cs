using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SpellProjectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 3f;


    private float damage;

    public void Initialize(Spell castedSpell, Vector2 targetPosition){
        Vector2 direction = FindObjectOfType<General>().GetDirectionToPosition(transform.position, targetPosition);
        damage = FindObjectOfType<PlayerAttributes>().CalculateSpellDamage(castedSpell.damage);
        Kick(direction);
    }

    public void Kick(Vector2 direction){
        GetComponent<Rigidbody2D>().AddForce(direction * projectileSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            other.gameObject.GetComponent<Enemy>().ReceiveDamage(damage);
            Destroy(gameObject);
        }
    }


}
