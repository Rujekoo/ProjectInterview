using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shopkeeper : MonoBehaviour
{
    public static Shopkeeper instance;
    [SerializeField] private GameObject shopUi;
    public InvnetorySlot[] invnetorySlots;
    private List<BasketItem> products = new List<BasketItem>();
    private InvnetorySlot slot;
    public double totalGold;


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
        for (int i = 0; i < invnetorySlots.Length; i++)
        {
            slot = invnetorySlots[i];
            BasketItem itemInSlot = slot.GetComponentInChildren<BasketItem>();

            if(itemInSlot != null)
            {
                totalGold = totalGold + itemInSlot.item.cost;
                products.Add(itemInSlot);

            }  
        }
        GoldManager.instance.UpdateGoldAmount();
    }  
}
