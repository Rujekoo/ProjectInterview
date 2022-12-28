using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    public static PlayerAction instance;
    [SerializeField] Camera cam;
    PlayerInput input;
    public bool checkTriggerZone;
    public string triggerZoneName;
    public Vector2 mousePos;
    public Vector2 mouseWorldPos;

    private void Awake() 
    {
        instance = this;
        input = new PlayerInput();
    }
    private void OnEnable() 
    {
        input.Enable();
    }

    private void Update() 
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            mousePos = Mouse.current.position.ReadValue();
            mouseWorldPos = cam.ScreenToWorldPoint(mousePos);
        }
    }

    private string OnTriggerEnter2D(Collider2D other) 
    {
        triggerZoneName = other.name;
        return triggerZoneName;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        triggerZoneName = "";
    }
}
