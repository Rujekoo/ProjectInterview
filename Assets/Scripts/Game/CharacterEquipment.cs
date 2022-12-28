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
    public bool equipCheck;
    public RuntimeAnimatorController[] anim;
    public GameObject[] equipmentSlots;


    private void Awake() 
    {
        instance = this;
    }

    //Check to see if the item place in each slot corresponds with the correct slot, then change equipment if true
    public void SetHeadItem()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            if(UICharacterEquipment.instance.controllerName.Equals(anim[i].name))
            {
                equipmentSlots[0].GetComponent<Animator>().runtimeAnimatorController = anim[i] as RuntimeAnimatorController;
            }
        }
        AudioManager.instance.PlaySFX("Equip");
    }

    public void SetTorsoItem()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            if(UICharacterEquipment.instance.controllerName.Equals(anim[i].name))
            {
                equipmentSlots[1].GetComponent<Animator>().runtimeAnimatorController = anim[i] as RuntimeAnimatorController;
            }
        }
        AudioManager.instance.PlaySFX("Equip");
    }

    public void SetLegsItem()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            if(UICharacterEquipment.instance.controllerName.Equals(anim[i].name))
            {
                equipmentSlots[2].GetComponent<Animator>().runtimeAnimatorController = anim[i] as RuntimeAnimatorController;
            }
        }
        AudioManager.instance.PlaySFX("Equip");
    }

    public void SetFeetItem()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            if(UICharacterEquipment.instance.controllerName.Equals(anim[i].name))
            {
                equipmentSlots[3].GetComponent<Animator>().runtimeAnimatorController = anim[i] as RuntimeAnimatorController;
            }
        }
        AudioManager.instance.PlaySFX("Equip");
    }

    //Check if the item has been bought or not
    public void TryEquipItem(ItemType equipSlot, Item item)
    {
        if(equipSlot == item.type && item.state == ActionType.Owned)
        {
            equipCheck = true;
        }
    }
}
