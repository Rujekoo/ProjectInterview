using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager instance;

    public InvnetorySlot[] invnetorySlots;
    public GameObject inventoryItemPrefab;
    public InvnetorySlot slot;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }
    
    public bool AddItem(Item item)
    {
        //Check if item has been bought and if so add icon
        /*for (int i = 0; i < invnetorySlots.Length; i++)
        {
            InvnetorySlot slot = invnetorySlots[i];
            BasketItem itemInSlot = slot.GetComponentInChildren<BasketItem>();

            if()
            {
                itemInSlot.bought = true;
                itemInSlot.RefreshBoughtIcon();
                return true;
            }
        }*/

        //Find an empty slot
        for (int i = 0; i < invnetorySlots.Length; i++)
        {
            slot = invnetorySlots[i];
            BasketItem itemInSlot = slot.GetComponentInChildren<BasketItem>();

            if(itemInSlot == null && i < 8)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    void SpawnNewItem(Item item, InvnetorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform); 
        BasketItem basketItem = newItemGo.GetComponent<BasketItem>();

        basketItem.InitialiseItem(item);
    }

    public void PausePlayer ()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    public void ResumePlayer ()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
