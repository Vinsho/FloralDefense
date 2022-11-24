using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    private PlayerAttributes playerAttributes;
    
    void Start() {
        playerAttributes = FindObjectOfType<PlayerAttributes>();

        animator.SetFloat("AttackSpeed", playerAttributes.attackSpeed);
        animator.SetFloat("CastingSpeed", playerAttributes.castSpeed);
    }

    public void SetMoveInput(Vector2 newMoveInput){
        animator.SetFloat("XInput", newMoveInput.x);
        animator.SetFloat("YInput", newMoveInput.y);
    }

    public void SetIsWalking(bool isWalking){
        animator.SetBool("isWalking", isWalking);
    }

    public void Die(){
        animator.SetTrigger("Die");
    }
}
