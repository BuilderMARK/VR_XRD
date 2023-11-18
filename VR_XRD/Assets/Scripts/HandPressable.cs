using UnityEngine;
using System.Collections;
using OculusSampleFramework;

public class HandPressable : MonoBehaviour
{
    public OVRHand hand;
    public OVRInput.Controller controller;
    public float distanceThreshold = 0.1f;

    public ProductionLinker productionLinker; //Maybe rewrite this logic? SKal bare bruges til at gøre x når man trykker
    public bool isStart; //Bare den funktion der skal kører på scriptet over... Ie. samme handpressable script til begge start stop

    private bool isButtonPressed = false; 

    void Update()
    {
        Vector3 handPosition = hand.transform.position;
        Vector3 buttonPosition = this.transform.position;

        if (Vector3.Distance(handPosition, buttonPosition) < distanceThreshold)
        {
            if (!isButtonPressed) 
            {
                Debug.Log("TAG Button pressed");
                if (isStart)
                {
                    productionLinker.ToggleRunning(true);
                } else
                {
                    productionLinker.ToggleRunning(false);
                }
                isButtonPressed = true; 
            }
        }
        else
        {
            isButtonPressed = false; 
        }
    }
}