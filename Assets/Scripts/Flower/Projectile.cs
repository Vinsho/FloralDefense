using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float ProjectileSpeed = 3f;
    [SerializeField] int damage = 1;

    GameObject myTarget;

    public void InitializeProjectileTarget(GameObject target){
        myTarget = target;
    }

    public void AddForceTowards(Vector3 direction){
        GetComponent<Rigidbody2D>().AddForce(direction * ProjectileSpeed, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            other.gameObject.GetComponent<Enemy>().ReceiveDamage(damage);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(myTarget){
            transform.position = Vector2.MoveTowards(transform.position, myTarget.transform.position, ProjectileSpeed * Time.deltaTime);
            var rotation =  Quaternion.LookRotation(myTarget.transform.position);
            rotation.x = rotation.y = 0;
            transform.rotation = rotation;
        }
        Destroy(gameObject, 1);
    }
}
