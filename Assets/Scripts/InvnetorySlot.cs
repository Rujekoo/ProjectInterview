using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvnetorySlot : MonoBehaviour, IDropHandler
{
   
   public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;
   public class OnItemDroppedEventArgs : EventArgs {
        public Item item;
   }
   //Drag and drop
   public void OnDrop(PointerEventData eventData)
   {
        if (transform.childCount == 0)
        {
            BasketItem basketItem = eventData.pointerDrag.GetComponent<BasketItem>();
            basketItem.parentAfterDrag = transform;

            Item item = basketItem.GetItem();
            OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs { item = item });

            if (basketItem.item.type == ItemType.Feet)
            {
                Debug.Log ("Feet Dropped");
            }
        }
   }
}
