using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlowerPlacement : MonoBehaviour
{
    GameObject flower;
    Flower flowerInstance;
    Vector3 mousePosition;
    FlowerManager myFlowerManager;

    private bool isHorizontal;

    void Start(){
        myFlowerManager = FindObjectOfType<FlowerManager>();
    }

    void Update(){
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        ManageFlowerPlacement();
    }

    public void Rotate(){
        if(FlowerIsBeingPlaced()){
            isHorizontal = !isHorizontal;
            flower.transform.Rotate(0, 0 , 90);
        }
    }

    public void StartFlowerPlacement(GameObject flowerPrefab){
        isHorizontal = true;
        flower = Instantiate(flowerPrefab, transform);
        flowerInstance = flower.GetComponent<Flower>();
        flowerInstance.ToggleFlowerCollider();
        flowerInstance.ToggleFlowerRangeSprite();
    }

    public bool FlowerIsBeingPlaced(){
        if (flower){
            return true;
        }
        return false;
    }
    
    void ManageFlowerPlacement(){
        if(FlowerIsBeingPlaced()){
            flower.transform.position = SnapCoordinates(mousePosition);
            if(Mouse.current.leftButton.wasPressedThisFrame){
                myFlowerManager.AddFlower(flower);
                flowerInstance.isHorizontal = isHorizontal;
                flowerInstance.ToggleFlowerRangeSprite();
                flowerInstance.UpdateFlowerSprite();
                flower = null;
                flowerInstance = null;
            }
        }
    }

    Vector3 SnapCoordinates(Vector3 mousePosition){
        float y = (Mathf.RoundToInt(mousePosition.y * 3.125f) / 3.125f);
        float x = (Mathf.RoundToInt(mousePosition.x * 3.125f) / 3.125f);
        return new Vector3(x, y, 0f);
    }
}
