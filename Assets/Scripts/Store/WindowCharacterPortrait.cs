using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCharacterPortrait : MonoBehaviour
{
    private Transform cameraTransform;
    private Transform followTransform;
    private float correction = -0.3f;
    private void Awake()
    {
        cameraTransform = transform.Find("camera");
    }

    //Live Character Portrait UI
    private void Update() 
    {
        cameraTransform.position = new Vector3(followTransform.position.x, followTransform.position.y + correction, Camera.main.transform.position.z);
    }

    public void Show(Transform followTransform)
    {
        gameObject.SetActive(true);
        this.followTransform = followTransform;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
