using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    private PlayerAnimator playerAnimator;
    private PlayerAttributes attributes;
    private GUI myGui;
    private General general;

    public bool isCasting;

    private float castTime;
    private Spell castedSpell;
    private float spellCastDuration;
    private GameObject groundMark;

    // Start is called before the first frame update
    void Start()
    {
        attributes = FindObjectOfType<PlayerAttributes>();
        playerAnimator = FindObjectOfType<PlayerAnimator>();
        myGui = FindObjectOfType<GUI>();
        general = FindObjectOfType<General>();
    }

    void Update(){
        if(isCasting){
            castTime += Time.deltaTime;
            myGui.SetCastBar(castTime/spellCastDuration);
        }
    }

    public void Cast(Spell spell){
        if(!isCasting && !playerAnimator.animator.GetBool("isWalking") && !attributes.IsDead()){
            if(!attributes.CanAfford(0, spell.manaCost, 0)){return;}

            castedSpell = spell;
            spellCastDuration = attributes.GetCastDuration(spell.castDuration);
            isCasting = true;
            StartCoroutine("Casting");
        }
    }

    public void StopCasting(){
        if(isCasting){
            isCasting = false;
            myGui.ToggleCastBar(false);
            StopCoroutine("Casting");
            if(groundMark){
                Destroy(groundMark);
            }
        }
    }

    private void CreateGroundMark(){
        groundMark = Instantiate(castedSpell.groundMark, general.GetMousePosition(), Quaternion.identity);
    }

    private IEnumerator Casting(){
        Vector2 direction = general.GetMouseDirection(transform.position);
        Vector2 position = general.GetMousePosition();

        playerAnimator.SetMoveInput(direction);
        playerAnimator.animator.SetTrigger(castedSpell.animationTrigger);

        CreateGroundMark();

        castTime = 0f;
        myGui.ToggleCastBar(true);

        yield return new WaitForSeconds(spellCastDuration);

        Instantiate(castedSpell.prefab, transform).GetComponent<SpellLogic>().Initialize(castedSpell, position);

        attributes.LoseResources(0, castedSpell.manaCost, 0);

        StopCasting();
    }
}
