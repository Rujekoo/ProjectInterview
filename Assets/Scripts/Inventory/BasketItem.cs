using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BasketItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static BasketItem instance;

    [Header("UI")]
    public Image image;
    public TextMeshProUGUI icon;
    public GameObject boughtCheck;

    [HideInInspector] public Item item;
    [HideInInspector] public bool bought;
    [HideInInspector] public Transform parentAfterDrag;

    private void Awake() 
    {
        instance = this;
    }

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshBoughtIcon();
    }

    public void RefreshBoughtIcon()
    {
        icon.gameObject.SetActive(bought);
    }

    //Drag and Drop
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        OwnerIndicator.instance.SetOwnerIndicator();
        AudioManager.instance.PlaySFX("Click");
    }

    public Item GetItem()
    {
        return item;
    }
}
