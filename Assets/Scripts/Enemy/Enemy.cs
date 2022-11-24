using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float attackDamage = 1;
    [SerializeField] float attackDelay = 1f;
    [SerializeField] int resourceDrop = 1;
    [SerializeField] int coinDrop = 1;
    [SerializeField] float coinDropChance = 0.25f;
    [SerializeField] int xpDrop = 1;

    public float maxHealth = 4;
    public Sprite portrait;
    
    Player player;
    EnemyManager myEnemyManager;
    Animator myAnimator;
    SpriteRenderer mySpriteRenderer;
    ParticleSystem particles;

    private float timeToNextAttack = 0f;
    private float distanceToPlayer;
    private float health;
    private float slow = 1;

    float step;

    void Start(){
        player = FindObjectOfType<Player>();
        myEnemyManager = FindObjectOfType<EnemyManager>();
        myAnimator = FindObjectOfType<Animator>();
        mySpriteRenderer = FindObjectOfType<SpriteRenderer>();
        particles = GetComponent<ParticleSystem>();        
        health = maxHealth;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > 0.4){
            Walk();
        }else if(timeToNextAttack < 0f){
            Attack();
        }

        UpdateTimers();
        FlipSprite();
    }

    void UpdateTimers(){
        timeToNextAttack -= Time.deltaTime;
    }

    void Walk(){
        step = movementSpeed * slow * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }

    void FlipSprite(){
        if (player.transform.position.x < transform.position.x){
            mySpriteRenderer.flipX = true;
        }else{
            mySpriteRenderer.flipX = false;
        }
    }

    void Attack(){
        myAnimator.SetTrigger("Attack");
        player.attributes.RecieveDamage(attackDamage);
        timeToNextAttack = attackDelay;
    }
    
    public float DistanceToPlayer(){
        return distanceToPlayer;
    }

    void Die(){
        if (health <= 0){
            player.dropManager.AddResources(resourceDrop);
            player.dropManager.AddCoins(coinDrop, coinDropChance);
            player.dropManager.AddXp(xpDrop);
            myEnemyManager.DestroyEnemy(gameObject);
        }
    }

    public void ReceiveDamage(float damage){
        particles.Play();
        health -= damage;
        Die();
    }

    public void ApplySlow(float slowPercentage, float slowDuration){
        if(slow == 1f){
            StartCoroutine(SlowCoRoutine(slowPercentage, slowDuration));
        }

    }

    private IEnumerator SlowCoRoutine(float slowPercentage, float slowDuration){
        slow = 1f - slowPercentage;
        yield return new WaitForSeconds(slowDuration);
        slow = 1f;
    }

    public float getHealth(){
        return health;
    }
}
