using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();
    
    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if (possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("No loot dropped");
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();
        if(droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefab,spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;


            //float dropForce = 50f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            //lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
        }
    }
}
