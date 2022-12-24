using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvnetorySlot : MonoBehaviour, IDropHandler
{
   
   //Drag and drop
   public void OnDrop(PointerEventData eventData)
   {
        if (transform.childCount == 0)
        {
            BasketItem basketItem = eventData.pointerDrag.GetComponent<BasketItem>();
            basketItem.parentAfterDrag = transform;
        }
   }
}
