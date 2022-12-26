using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    public static CharacterEquipment instance;
    private Item headItem;
    private Item torsoItem;
    private Item legsItem;
    private Item feetItem;
    public RuntimeAnimatorController[] anim;
    public GameObject[] equipmentSlots;

    private void Awake() 
    {
        instance = this;
    }
    public Item GetHeadItem()
    {
        return headItem;
    }

    public Item GetTorsoItem()
    {
        return torsoItem;
    }

    public Item GetLegsItem()
    {
        return legsItem;
    }

    public Item GetFeetItem()
    {
        return feetItem;
    }

    public void SetFeetItem()
    {
        //test.GetComponent<Animator>().runtimeAnimatorController = anim as RuntimeAnimatorController;
    }

}
