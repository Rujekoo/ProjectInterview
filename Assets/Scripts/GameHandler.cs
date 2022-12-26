using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private WindowCharacterPortrait windowCharacterPortrait;
    [SerializeField] private Transform characterTransform;

    private void Start() 
    {
        windowCharacterPortrait.Show(characterTransform);
    }
}
