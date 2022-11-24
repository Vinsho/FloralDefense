using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Flower : MonoBehaviour
{
    [SerializeField] List<int> stageTresholds = new List<int>();
    [SerializeField] List<Sprite> stageSprites = new List<Sprite>();
    [SerializeField] GameObject flowerRangeSprite;
    [SerializeField] bool flowerDoesAttack;
    [SerializeField] bool isConnectable;


    public SpriteRenderer mySpriteRenderer;
    int age = 0;

    public Flowers type;
    public Animator animator;
    public bool isMature = false;
    public bool isHorizontal = false;

    private FlowerConnector flowerConnector;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if(isConnectable){
            flowerConnector = GetComponent<FlowerConnector>();
        }
    }
        
    public void UpdateFlowerSprite(){
        if (!isMature){
            mySpriteRenderer.sprite = stageSprites[GetHighestAgeTreshold()];
            return;
        }

        if(isConnectable){
            gameObject.transform.rotation = Quaternion.identity;
            Sprite newSprite = flowerConnector.GetConnectedSprite(isHorizontal);
            if (newSprite != mySpriteRenderer.sprite){
                mySpriteRenderer.sprite = newSprite;
                Destroy(GetComponent<PolygonCollider2D>());
                gameObject.AddComponent<PolygonCollider2D>();
            }
        }else{
            mySpriteRenderer.sprite = stageSprites[stageTresholds.Last()];
        }
    }

    int GetHighestAgeTreshold(){
        for(int i=0; i < stageTresholds.Count; i++){
            if(stageTresholds[i] >= age){
                return i;
            }
        }
        return 0;
    }

    public void IncreaseFlowerAge(){
        age ++;
        if(age >= stageTresholds.Last() && !isMature){
            isMature = true;
            animator.enabled = true;
            ToggleFlowerCollider();
        }
        UpdateFlowerSprite();
    }

    public void ToggleFlowerCollider(){
        PolygonCollider2D collider = GetComponent<PolygonCollider2D>();
        collider.isTrigger = !collider.isTrigger;
    }

    public void ToggleFlowerRangeSprite(){
        if(flowerDoesAttack){
            flowerRangeSprite.SetActive(!flowerRangeSprite.activeSelf);
        }
    }

    public int X{
        get{return Mathf.FloorToInt(transform.position.x / Constants.gridSize);}
    }

    public int Y{
        get{return Mathf.FloorToInt(transform.position.y / Constants.gridSize);}
    }
}
