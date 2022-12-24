using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    [SerializeField] Camera cam;
    PlayerInput input;
    public Vector2 mousePos;
    public Vector2 mouseWorldPos;

    private void Awake() 
    {
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
            Debug.Log ("Left Clicked:" + mouseWorldPos);
        }
    }
}
