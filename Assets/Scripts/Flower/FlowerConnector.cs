using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerConnector : MonoBehaviour
{
    
    [SerializeField] Sprite middle;
    [SerializeField] Sprite horizontal;
    [SerializeField] Sprite vertical;
    [SerializeField] Sprite up;
    [SerializeField] Sprite down;
    [SerializeField] Sprite left;
    [SerializeField] Sprite right;
    [SerializeField] Sprite upLeftCorner;
    [SerializeField] Sprite upRightCorner;
    [SerializeField] Sprite downLeftCorner;
    [SerializeField] Sprite downRightCorner;

    private FlowerManager flowerManager;
    private Dictionary<FlowerSpriteType, Sprite> sprites = new Dictionary<FlowerSpriteType, Sprite>();

    public Sprite GetConnectedSprite(bool isHorizontal){
        FlowerSpriteType flowerSpriteType = flowerManager.GetSpriteType(gameObject, isHorizontal);
        return sprites[flowerSpriteType];
    }

    // Start is called before the first frame update
    void Start()
    {
        flowerManager = FindObjectOfType<FlowerManager>();

        sprites[FlowerSpriteType.middle] = middle;
        sprites[FlowerSpriteType.horizontal] = horizontal;
        sprites[FlowerSpriteType.vertical] = vertical;
        sprites[FlowerSpriteType.up] = up;
        sprites[FlowerSpriteType.down] = down;
        sprites[FlowerSpriteType.left] = left;
        sprites[FlowerSpriteType.right] = right;
        sprites[FlowerSpriteType.upLeftCorner] = upLeftCorner;
        sprites[FlowerSpriteType.upRightCorner] = upRightCorner;
        sprites[FlowerSpriteType.downLeftCorner] = downLeftCorner;
        sprites[FlowerSpriteType.downRightCorner] = downRightCorner;
    }
}
