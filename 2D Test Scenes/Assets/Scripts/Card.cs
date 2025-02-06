using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Dog")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;

    //public Sprite artwork;

    public int speedChange;
    public int strengthChange;
}
