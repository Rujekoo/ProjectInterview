using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    [SerializeField] private int speed = 5;
    private Vector2 movement;
    private Rigidbody2D rb;
    [SerializeField] public Animator []animators;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            for (int i = 0; i < animators.Length; i++)
            {
                if (animators[i] != null)
                {
                    animators[i].SetFloat("X", movement.x);
                    animators[i].SetFloat("Y", movement.y);

                    animators[i].SetBool("IsWalking", true);
                }  
            }
            
        }
        else
        {
            for (int i = 0; i < animators.Length; i++)
            {
                if (animators[i] != null)
                {
                    animators[i].SetBool("IsWalking", false);
                }        
            } 
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
