using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager instance;

    public InvnetorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public InvnetorySlot slot;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }
    
    public bool AddItem(Item item)
    {
        //Find an empty slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            slot = inventorySlots[i];
            BasketItem itemInSlot = slot.GetComponentInChildren<BasketItem>();

            if(itemInSlot == null && i < 8)
            {
                SpawnNewItem(item, slot);
                OwnerIndicator.instance.SetOwnerIndicator();
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

    public void EmptyBasket ()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            slot = inventorySlots[i];
            BasketItem itemInSlot = slot.GetComponentInChildren<BasketItem>();

            if(itemInSlot != null && itemInSlot.item.state == ActionType.NotOwned)
            {
                itemInSlot.item.count = 0;
                Destroy(itemInSlot.gameObject);
            }       
        }
        OwnerIndicator.instance.SetDefaultIndicator();
        OwnerIndicator.instance.SetOwnerIndicator();
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
