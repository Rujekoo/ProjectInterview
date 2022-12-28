using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoreManager : MonoBehaviour
{
    public static StoreManager instance;
    [SerializeField] private GameObject torsoShopUi;
    [SerializeField] private GameObject headgearShopUi;
    [SerializeField] private GameObject feetShopUi;
    [SerializeField] private GameObject legsShopUi;
    [SerializeField] private GameObject changingRoomShopUi;
    [SerializeField] public GameObject pauseMenu;

    private void Awake() 
    {
        instance = this;
    }

    public void OpenTorsoShopUI ()
    {
        if(PlayerAction.instance.triggerZoneName.Equals("TorsoActivationZone"))
        {
            torsoShopUi.SetActive(true);
            InventoryManager.instance.PausePlayer();
        }
    }

    public void OpenHeadgearShopUI ()
    {
        if(PlayerAction.instance.triggerZoneName.Equals("HeadgearActivationZone"))
        {
            headgearShopUi.SetActive(true);
            InventoryManager.instance.PausePlayer();
        }
    }

    public void OpenFeetShopUI ()
    {
        if(PlayerAction.instance.triggerZoneName.Equals("FeetActivationZone"))
        {
            feetShopUi.SetActive(true);
            InventoryManager.instance.PausePlayer();
        }
    }
    public void OpenLegsShopUI ()
    {
        if(PlayerAction.instance.triggerZoneName.Equals("LegsActivationZone"))
        {
            legsShopUi.SetActive(true);
            InventoryManager.instance.PausePlayer();
        }
    }

    public void OpenChangingRoomUI ()
    {
        if(PlayerAction.instance.triggerZoneName.Equals("ChangingRoomActivationZone"))
        {
            changingRoomShopUi.SetActive(true);
            InventoryManager.instance.PausePlayer();
        }
    }

    public void CloseTorsoShopUI ()
    {
        torsoShopUi.SetActive(false);
        InventoryManager.instance.ResumePlayer();
    }

    public void CloseHeadgearShopUI ()
    {
        headgearShopUi.SetActive(false);
        InventoryManager.instance.ResumePlayer();
    }

    public void CloseFeetShopUI ()
    {
        feetShopUi.SetActive(false);
        InventoryManager.instance.ResumePlayer();
    }

    public void CloseLegsShopUI ()
    {
        legsShopUi.SetActive(false);
        InventoryManager.instance.ResumePlayer();
    }

    public void CloseChangingRoomUI ()
    {
        changingRoomShopUi.SetActive(false);
        InventoryManager.instance.ResumePlayer();
    }

    public void ClosePauseMenu ()
    {
        pauseMenu.SetActive(false);
        InventoryManager.instance.ResumePlayer();
    }
}
