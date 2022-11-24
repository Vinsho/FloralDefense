using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlowerManager : MonoBehaviour
{
    List<GameObject> flowers = new List<GameObject>();
    [SerializeField] int xSize;
    [SerializeField] int ySize;

    Flower[][] flowerMatrix;

    private void Start()
    {
        InitializeFlowerMatrix();
        AddExistingFlowers();
        foreach (GameObject FlowerGO in flowers)
        {
            FlowerGO.GetComponent<Flower>().UpdateFlowerSprite();
        }
    }

    void InitializeFlowerMatrix()
    {
        flowerMatrix = new Flower[ySize][];

        for (int i = 0; i < ySize; i++)
        {
            flowerMatrix[i] = new Flower[xSize];
        }
    }

    void AddExistingFlowers()
    {
        Flower[] flowerScripts = FindObjectsOfType<Flower>();
        foreach (Flower flower in flowerScripts)
        {
            AddFlower(flower.gameObject);
        }
    }

    public void AddFlower(GameObject flowerGO)
    {
        Flower flower = flowerGO.GetComponent<Flower>();
        flowers.Add(flowerGO);
        flowerMatrix[flower.Y][flower.X] = flower;

    }

    public void IncreaseFlowersAge()
    {
        foreach (GameObject flower in flowers)
        {
            flower.GetComponent<Flower>().IncreaseFlowerAge();
        }
    }

    bool HasUpFlower(Flower flower)
    {
        if ((flower.Y + 1) < ySize)
        {
            if (flowerMatrix[flower.Y + 1][flower.X] && (flowerMatrix[flower.Y + 1][flower.X].type == flower.type))
            {
                return true;
            }
        }
        return false;
    }

    bool HasDownFLower(Flower flower)
    {
        if ((flower.Y - 1) >= 0)
        {
            if (flowerMatrix[flower.Y - 1][flower.X] && (flowerMatrix[flower.Y - 1][flower.X].type == flower.type))
            {
                return true;
            }
        }
        return false;
    }

    bool HasRightFlower(Flower flower)
    {
        if ((flower.X + 1) < xSize)
        {
            if (flowerMatrix[flower.Y][flower.X + 1] && (flowerMatrix[flower.Y][flower.X + 1].type == flower.type))
            {
                return true;
            }
        }
        return false;
    }

    bool HasLeftFlower(Flower flower)
    {
        if ((flower.X - 1) >= 0)
        {
            if (flowerMatrix[flower.Y][flower.X - 1] && (flowerMatrix[flower.Y][flower.X - 1].type == flower.type))
            {
                return true;
            }
        }
        return false;
    }

    public FlowerSpriteType GetSpriteType(GameObject flowerGO, bool isHorizontal)
    {
        Flower flower = flowerGO.GetComponent<Flower>();

        bool up = HasUpFlower(flower);
        bool down = HasDownFLower(flower);
        bool left = HasLeftFlower(flower);
        bool right = HasRightFlower(flower);

        if (up)
        {
            if (down && left && right) { return FlowerSpriteType.middle; }
            if (left && right) { return FlowerSpriteType.up; }
            if (left && down) { return FlowerSpriteType.left; }
            if (right && down) { return FlowerSpriteType.right; }
            if (left) { return FlowerSpriteType.downRightCorner; }
            if (right) { return FlowerSpriteType.downLeftCorner; }
            if (down) { return FlowerSpriteType.vertical; }
        }
        else if (down)
        {
            if (left && right) { return FlowerSpriteType.down; }
            if (left) { return FlowerSpriteType.upRightCorner; }
            if (right) { return FlowerSpriteType.upLeftCorner; }
        }
        else if (isHorizontal)
        {
            if (up) { return FlowerSpriteType.up; }
            else if (down) { return FlowerSpriteType.down; }
            return FlowerSpriteType.horizontal;
        }
        else if (!isHorizontal)
        {
            if (left && right) { return FlowerSpriteType.vertical; }
            if (left) { return FlowerSpriteType.left; }
            if (right) { return FlowerSpriteType.right; }
        }
        return FlowerSpriteType.vertical;
    }
}
