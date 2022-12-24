using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Scriptable object/Item")]
public class Item : ScriptableObject
{
    

    [Header("Only gameplay")]
    public TileBase tile;
    public double cost;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);
    
    //[Header("Only UI")]

    [Header("Both")]
    public Sprite image;
}

public enum ItemType
{
    Headgear,
    Top,
    Bottom,
    Footwear
}

public enum ActionType
{

}
