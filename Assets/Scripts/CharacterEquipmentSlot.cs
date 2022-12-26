using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterEquipmentSlot : MonoBehaviour, IDropHandler
{
    /*public void OnDrop(PointerEventData eventData)
    {
        Item item = BasketItem.instance.GetItem();
        Debug.Log(item);
    }*/
    public void OnDrop(PointerEventData eventData)
   {
        if (transform.childCount == 0)
        {
            BasketItem basketItem = eventData.pointerDrag.GetComponent<BasketItem>();
            basketItem.parentAfterDrag = transform;
        }
   }
}
