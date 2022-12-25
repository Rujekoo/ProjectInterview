using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] private GameObject shopUi;

    public void OpenShopUI ()
    {
        if(PlayerAction.instance.triggerZoneName.Equals("ShopkeeperActivationZone"))
        {
            Debug.Log ("Clicked Shopkeeper");
            shopUi.SetActive(true);
        }
    }
    
}
