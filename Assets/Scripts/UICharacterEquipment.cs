using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterEquipment : MonoBehaviour
{
    public static UICharacterEquipment instance;
    public string controllerName;
    private InvnetorySlot headSlot;
    private InvnetorySlot torsoSlot;
    private InvnetorySlot legsSlot;
    private InvnetorySlot feetSlot;
    private CharacterEquipment characterEquipment;

    private void Awake() 
    {
        instance = this;
        headSlot = transform.Find("Head").GetComponent<InvnetorySlot>();
        torsoSlot = transform.Find("Torso").GetComponent<InvnetorySlot>();
        legsSlot = transform.Find("Legs").GetComponent<InvnetorySlot>();
        feetSlot = transform.Find("Feet").GetComponent<InvnetorySlot>();

        headSlot.OnItemDropped += HeadSlot_OnItemDropped;
        torsoSlot.OnItemDropped += TorsoSlot_OnItemDropped;
        legsSlot.OnItemDropped += LegsSlot_OnItemDropped;
        feetSlot.OnItemDropped += FeetSlot_OnItemDropped;
    }

    private void HeadSlot_OnItemDropped(object sender, InvnetorySlot.OnItemDroppedEventArgs e)
    {
        controllerName = e.item.name;
        CharacterEquipment.instance.TryEquipItem(ItemType.Headgear, e.item);
        if(CharacterEquipment.instance.equipCheck)
        {
            CharacterEquipment.instance.SetHeadItem();
            CharacterEquipment.instance.equipCheck = false;
        }
    }
    private void TorsoSlot_OnItemDropped(object sender, InvnetorySlot.OnItemDroppedEventArgs e)
    {
        controllerName = e.item.name;
        CharacterEquipment.instance.TryEquipItem(ItemType.Torso, e.item);
        if(CharacterEquipment.instance.equipCheck)
        {
            CharacterEquipment.instance.SetTorsoItem();
            CharacterEquipment.instance.equipCheck = false;
        }
    }
    private void LegsSlot_OnItemDropped(object sender, InvnetorySlot.OnItemDroppedEventArgs e)
    {
        controllerName = e.item.name;
        CharacterEquipment.instance.TryEquipItem(ItemType.Legs, e.item);
        if(CharacterEquipment.instance.equipCheck)
        {
            CharacterEquipment.instance.SetLegsItem();
            CharacterEquipment.instance.equipCheck = false;
        }
    }
    private void FeetSlot_OnItemDropped(object sender, InvnetorySlot.OnItemDroppedEventArgs e)
    {
        controllerName = e.item.name;
        CharacterEquipment.instance.TryEquipItem(ItemType.Feet, e.item);
        if(CharacterEquipment.instance.equipCheck)
        {
            CharacterEquipment.instance.SetFeetItem();
            CharacterEquipment.instance.equipCheck = false;
        }
    }

    public void SetCharacterEquipment(CharacterEquipment characterEquipment)
    {
        this.characterEquipment = characterEquipment;
    }

    private void UpdateVisual()
    {

    }
}
