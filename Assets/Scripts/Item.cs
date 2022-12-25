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
    //public Vector2Int range = new Vector2Int(5, 4);
    
    //[Header("Only UI")]

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

}
