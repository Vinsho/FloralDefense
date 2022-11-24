using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] float attackDelay = 1f;

    List<GameObject> enemiesInRange = new List<GameObject>();
    GameObject target;

    private Flower flower;

    bool isAttacking = false;

    void Start(){
        flower = GetComponent<Flower>();
    }

    void Update(){
        if(!isAttacking && target && flower.isMature){
            StartCoroutine(Attack());
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            AddEnemy(other.gameObject);
        }
    }

    void AddEnemy(GameObject enemy){
        enemiesInRange.Add(enemy);    
        if (!target){
            target = GetClosestEnemy();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Enemy"){
            RemoveEnemy(other.gameObject);
        }
    }

    void RemoveEnemy(GameObject enemy){
        enemiesInRange.Remove(enemy);
        if(enemy == target){
            if(enemiesInRange.Count != 0){
                target = GetClosestEnemy();
            }
        }
    }

    GameObject GetClosestEnemy(){
        GameObject closestEnemy = enemiesInRange[0];
        float closestDistance = 100f;

        foreach (GameObject enemy in enemiesInRange)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance < closestDistance){
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }

    IEnumerator Attack(){
        isAttacking = true;
        while(target){
            Shoot();
            yield return new WaitForSeconds(attackDelay);
        }
        isAttacking = false;
    }

    void Shoot(){
        flower.animator.SetTrigger("Attack");
        GameObject newProjectile = Instantiate(projectile, spawnPoint.transform);
        newProjectile.GetComponent<Projectile>().InitializeProjectileTarget(target);
    }
}
