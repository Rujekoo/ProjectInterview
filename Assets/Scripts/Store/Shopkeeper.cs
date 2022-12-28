using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Shopkeeper : MonoBehaviour
{
    public static Shopkeeper instance;
    [SerializeField] public GameObject shopUi;
    public InvnetorySlot[] invnetorySlots;
    private List<BasketItem> products = new List<BasketItem>();
    private InvnetorySlot slot;
    public double totalGold;
    public double sellPenalty;
    public TextMeshProUGUI showTotalGold;


    private void Awake() 
    {
        instance = this;
    }
    public void OpenShopUI ()
    {
        if(PlayerAction.instance.triggerZoneName.Equals("ShopkeeperActivationZone"))
        {
            shopUi.SetActive(true);
            InventoryManager.instance.PausePlayer();
        }
    }

    public void CloseShopUI ()
    {
        shopUi.SetActive(false);
        InventoryManager.instance.ResumePlayer();
    }

    public void BuyProducts ()
    {
        //Check the item added to store inventory, do checks and if correct, buy item
        for (int i = 0; i < invnetorySlots.Length; i++)
        {
            slot = invnetorySlots[i];
            BasketItem itemInSlot = slot.GetComponentInChildren<BasketItem>();

            if(itemInSlot != null && itemInSlot.item.state == ActionType.NotOwned)
            {
                totalGold = totalGold + itemInSlot.item.cost;
                showTotalGold.SetText("- " + totalGold.ToString("F2"));

                if(GoldManager.instance.currentGoldAmount > totalGold)
                {
                    itemInSlot.item.state = ActionType.Owned;
                    products.Add(itemInSlot);
                    Destroy(itemInSlot.gameObject);
                }  

                else
                {
                    totalGold = totalGold - itemInSlot.item.cost;
                    showTotalGold.SetText("- " + totalGold.ToString("F2"));
                }                                
            }  
        }

        GoldManager.instance.UpdateGoldAmount();
        for (int i = 0; i < products.Count; i++)
        {
            InventoryManager.instance.AddItem(products[i].item);
        }
        products.Clear();
    }  

    public void SellProducts ()
    {
        //If item is owned, sell it
        for (int i = 0; i < invnetorySlots.Length; i++)
        {
            slot = invnetorySlots[i];
            BasketItem itemInSlot = slot.GetComponentInChildren<BasketItem>();

            if(itemInSlot != null && itemInSlot.item.state == ActionType.Owned)
            {
                itemInSlot.item.state = ActionType.NotOwned;
                itemInSlot.item.count = 0;
                sellPenalty = itemInSlot.item.cost * 0.8;
                totalGold = totalGold + sellPenalty;
                showTotalGold.SetText("+ " + totalGold.ToString("F2"));
                Destroy(itemInSlot.gameObject);                       
            }  
        }

        totalGold = totalGold - (totalGold * 2);
        GoldManager.instance.UpdateGoldAmount();
    }
}
