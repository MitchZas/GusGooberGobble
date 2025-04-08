using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu]
public class Loot: ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;

    public Loot(string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
