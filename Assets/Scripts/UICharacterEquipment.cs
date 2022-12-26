using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterEquipment : MonoBehaviour
{
    public static UICharacterEquipment instance;
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
        Debug.Log("Equip head: " + e.item); 
    }
    private void TorsoSlot_OnItemDropped(object sender, InvnetorySlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip torso: " + e.item); 
    }
    private void LegsSlot_OnItemDropped(object sender, InvnetorySlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip legs: " + e.item); 
    }
    private void FeetSlot_OnItemDropped(object sender, InvnetorySlot.OnItemDroppedEventArgs e)
    {
        Debug.Log("Equip feet: " + e.item); 
        //CharacterEquipment.instance.SetFeetItem();
    }

    public void SetCharacterEquipment(CharacterEquipment characterEquipment)
    {
        this.characterEquipment = characterEquipment;
    }

    private void UpdateVisual()
    {

    }
}
