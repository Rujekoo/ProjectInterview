using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnerIndicator : MonoBehaviour
{
    public static OwnerIndicator instance;
    [SerializeField] private Image[] image;
    private Color32 red = new Color32(255, 0, 0, 200);
    private Color32 green = new Color32(0, 255, 0, 200);
    private Color32 black = new Color32(0, 0, 0, 255);
    private InvnetorySlot slot;

    private void Awake() 
    {
        instance = this;
    }
    public void SetOwnerIndicator ()
    {
        //Handle the indicators to show if you bought or have yet to buy an item
        for (int i = 0; i < InventoryManager.instance.inventorySlots.Length; i++)
        {
            slot = InventoryManager.instance.inventorySlots[i];
            BasketItem itemInSlot = slot.GetComponentInChildren<BasketItem>();

            if(itemInSlot != null)
            {
                if(itemInSlot.item.state == ActionType.Owned)
                {
                    image[i].GetComponent<Image>().color = green;
                }

                if(itemInSlot.item.state == ActionType.NotOwned)
                {
                    image[i].GetComponent<Image>().color = red;
                }
            }

            else
            {
                image[i].GetComponent<Image>().color = black;
            }
        }
    }

    public void SetDefaultIndicator ()
    {
        for (int i = 0; i < InventoryManager.instance.inventorySlots.Length; i++)
        {
            image[i].GetComponent<Image>().color = black;
        }
    }
}
