using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;
    private bool result;

    public void PickipItem(int id)
    {
        Debug.Log (itemsToPickup[id].count);
        if (itemsToPickup[id].count < 1)
        {
            inventoryManager.AddItem(itemsToPickup[id]);
            itemsToPickup[id].count++;   
        }
    }
}
