using System;
using UnityEngine;
using UnityEngine.Events;
using OculusSampleFramework;
using Unity.VisualScripting;

public class HandPressable : MonoBehaviour
{
    public OVRHand hand;
    public OVRInput.Controller controller;
    public float distanceThreshold = 0.1f;

    public UnityEvent<bool> OnButtonPressed;

    public bool isStart;
    private bool isPressed;

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            OnButtonPressed?.Invoke(isStart);
            isPressed = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (isPressed)
        {
            isPressed = false;
        }
    }
    
}