using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Enemy clickedEnemy;
    PlayerTargetManager playerTargetManager;
    FlowerPlacement flowerPlacement;
    EnemyManager myEnemyManager;
    QuickBuyManager quickBuyManager;
    Player player;
    GUI myGUI;
    AvailableSpells availableSpells;

    void Start()
    {
        playerTargetManager = FindObjectOfType<PlayerTargetManager>();
        myEnemyManager = FindObjectOfType<EnemyManager>();
        player = FindObjectOfType<Player>();
        myGUI = FindObjectOfType<GUI>();
        availableSpells = FindObjectOfType<AvailableSpells>();
        flowerPlacement = FindObjectOfType<FlowerPlacement>();
        quickBuyManager = FindObjectOfType<QuickBuyManager>();
    }

    void OnMove(InputValue value){
        Vector2 moveInput = value.Get<Vector2>();
        player.StopActions();
        player.SetMoveInput(moveInput);
    }

    void OnClick(){
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        
        if( hit.collider != null && hit.collider.tag == "Enemy")
        {
            clickedEnemy = hit.collider.gameObject.GetComponent<Enemy>();
            playerTargetManager.SetTarget(clickedEnemy);
        }
    }

    void OnEscape(){
        quickBuyManager.ToggleQuickBuy(false);
    }

    void OnRotate(){
        flowerPlacement.Rotate();
    }

    void OnCastE(){
        player.playerCasting.Cast(availableSpells.GetActiveSpellAtIndex(2));
    }

    void OnCastQ(){
        player.playerCasting.Cast(availableSpells.GetActiveSpellAtIndex(1));
    }

    void OnAttack(){
        if (!clickedEnemy){
            myGUI.SendNotification("No target");
        }else{
            player.SetAttackedEnemy(clickedEnemy);
        }
    }

    void OnFindClosestTarget(){
        if(myEnemyManager.NoEnemyAlive()){return;}
        clickedEnemy = myEnemyManager.GetClosestEnemy(player.transform.position).GetComponent<Enemy>();
        playerTargetManager.SetTarget(clickedEnemy);
    }

    void OnBuy(){
        quickBuyManager.ToggleQuickBuy(true);
    }

    void OnOne(){
        quickBuyManager.BuyAtGivenIndex(1);
    }
    
    void OnTwo(){
        quickBuyManager.BuyAtGivenIndex(2);
    }
        
    void OnThree(){
        quickBuyManager.BuyAtGivenIndex(3);
    }
        
    void OnFour(){
        quickBuyManager.BuyAtGivenIndex(4);
    }
        
    void OnFive(){
        quickBuyManager.BuyAtGivenIndex(5);
    }
        
    void OnSix(){
        quickBuyManager.BuyAtGivenIndex(6);
    }
}
