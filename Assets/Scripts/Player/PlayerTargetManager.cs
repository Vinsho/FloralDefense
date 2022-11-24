using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetManager: MonoBehaviour
{
    GUI myGUI;
    Enemy target;

    void Start(){
        myGUI = FindObjectOfType<GUI>();
    }

    void Update(){
        if(target){
           myGUI.SetTargetHealth(target.getHealth(), target.maxHealth);
        }else{
            myGUI.UnsetTarget();
        }
    }

    public void SetTarget(Enemy newTarget){
        myGUI.SetNewTarget(newTarget.portrait);
        target = newTarget;
    }
}
