using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject torsoShopUi;
    [SerializeField] private GameObject headgearShopUi;

    public void OpenTorsoShopUI ()
    {
        if(PlayerAction.instance.triggerZoneName.Equals("TorsoActivationZone"))
        {
            torsoShopUi.SetActive(true);
        }
    }

    public void OpenHeadgearShopUI ()
    {
        if(PlayerAction.instance.triggerZoneName.Equals("HeadgearActivationZone"))
        {
            headgearShopUi.SetActive(true);
        }
    }

    public void CloseTorsoShopUI ()
    {
        torsoShopUi.SetActive(false);
    }

    public void CloseHeadgearShopUI ()
    {
        headgearShopUi.SetActive(false);
    }
}
