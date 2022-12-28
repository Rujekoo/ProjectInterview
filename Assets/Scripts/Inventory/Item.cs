using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Scriptable object/Item")]
public class Item : ScriptableObject
{
    
    [Header("Only gameplay")]
    public double cost;
    public int count;
    public ItemType type;
    public ActionType state;
    public RuntimeAnimatorController animation;

    [Header("Both")]
    public Sprite image;
}

public enum ItemType
{
    Headgear,
    Torso,
    Legs,
    Feet
}

public enum ActionType
{
    Owned,
    NotOwned
}

