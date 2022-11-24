using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;
    [SerializeField] Sprite leftSprite;
    [SerializeField] Sprite rightSprite;
    [SerializeField] GameObject wrath;


    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    SpriteRenderer mySpriteRenderer;
    Globals globals;

    public DropManager dropManager;
    public PlayerAttributes attributes;
    public PlayerCasting playerCasting;

    private PlayerAnimator playerAnimator;
    private Enemy attackedEnemy;
    private float timeToNextAttack = 0f;
    private bool dead = false;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        playerCasting = FindObjectOfType<PlayerCasting>();
        playerAnimator = FindObjectOfType<PlayerAnimator>();
        globals = FindObjectOfType<Globals>();
        dropManager = FindObjectOfType<DropManager>();
    }

    void Update()
    {
        if (!dead)
        {
            Run();
            playerAnimator.SetIsWalking(!(myRigidBody.velocity == Vector2.zero));
            Die();
        }
    }

    void Die()
    {
        if (!dead && attributes.IsDead())
        {
            playerCasting.StopCasting();
            playerAnimator.Die();
            dead = true;
            attributes.gui.ShowLoseScreen();
        }
    }

    void Attack()
    {
        if (attackedEnemy)
        {
            if (attackedEnemy.DistanceToPlayer() > attributes.attackRange)
            {
                MoveToAttackedEnemy();
            }
            else if (!playerAnimator.animator.GetBool("isAttacking"))
            {
                playerAnimator.animator.SetBool("isAttacking", true);
                StartCoroutine("AttackCoRoutine");
            }
        }
        else
        {
            playerAnimator.animator.SetBool("isAttacking", false);
        }
    }

    IEnumerator AttackCoRoutine()
    {
        StopMoving();
        while (attackedEnemy)
        {
            TurnToTarget();
            yield return new WaitForSeconds(attributes.damageAnimationDuration);
            attackedEnemy.ReceiveDamage(attributes.damage);
            yield return new WaitForSeconds(attributes.afterDamageAnimationDuration);
        }
    }

    Vector2 GetDirectionToTarget()
    {
        Vector2 direction = attackedEnemy.transform.position - transform.position;
        return direction.normalized;
    }

    void MoveToAttackedEnemy()
    {
        SetMoveInput(GetDirectionToTarget());
    }

    public void SetAttackedEnemy(Enemy enemy)
    {
        attackedEnemy = enemy;
    }

    public void SetMoveInput(Vector2 newMoveInput)
    {
        moveInput = newMoveInput;
        playerAnimator.SetMoveInput(newMoveInput);
    }

    void TurnToTarget()
    {
        playerAnimator.SetMoveInput(GetDirectionToTarget());
    }

    private void StopMoving()
    {
        moveInput = new Vector2(0, 0);
    }

    public void StopActions()
    {
        attackedEnemy = null;
        playerCasting.StopCasting();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * attributes.moveSpeed, moveInput.y * attributes.moveSpeed);
        myRigidBody.velocity = playerVelocity;
    }
}
