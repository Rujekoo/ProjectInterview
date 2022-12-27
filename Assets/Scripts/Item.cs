using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor.Animations;

[CreateAssetMenu(menuName ="Scriptable object/Item")]
public class Item : ScriptableObject
{
    
    [Header("Only gameplay")]
    public double cost;
    public ItemType type;
    public AnimatorController animation;

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

