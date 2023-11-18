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

    // Use UnityEvent<bool> instead of a custom delegate and event
    public UnityEvent<bool> OnButtonPressed;

    public bool isStart;

    private bool isButtonPressed = false; 

    /*
    void Update()
    {
        Vector3 handPosition = hand.transform.position;
        Vector3 buttonPosition = this.transform.position;

        if (Vector3.Distance(handPosition, buttonPosition) < distanceThreshold)
        {
            Debug.Log("TAG Button pressed");
            // Invoke the UnityEvent
            OnButtonPressed?.Invoke(isStart);
        }
        else
        {
            isButtonPressed = false; 
        }
    }*/

    private bool isPressed;
    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            Debug.Log("TAG Button pressed: ");
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