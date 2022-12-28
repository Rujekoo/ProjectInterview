using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerZone : MonoBehaviour
{
    public static EventTriggerZone instance;
    public bool triggerZoneEntered;

    private void Awake() 
    {
        instance = this;
    }

    //Check if the player is in the activation zone to enable access to stores 
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other)
        {
            triggerZoneEntered = true;
        }
    }
    
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other)
        {
            triggerZoneEntered = true;
        }
    }
}
