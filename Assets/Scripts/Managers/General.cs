using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class General : MonoBehaviour
{
    public Vector2 GetMousePosition(){
        return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    public Vector2 GetMouseDirection(Vector2 position){
        return GetDirectionToPosition(position, GetMousePosition());
    }
    
    public Vector2 GetDirectionToPosition(Vector2 originPosition, Vector2 targetPosition){
        return (targetPosition - originPosition).normalized;
    }
}
