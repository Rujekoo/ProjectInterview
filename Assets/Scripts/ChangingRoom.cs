using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingRoom : MonoBehaviour
{
    public static ChangingRoom instance;
    [SerializeField] private Animator []animators;
    public SpriteRenderer[] image;
    public GameObject player;

    private void Awake() 
    {
        instance = this;
    }

    public void GetPlayerSprites ()
    {

    }
}
