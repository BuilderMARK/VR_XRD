using UnityEngine;
using System.Collections;
using OculusSampleFramework;

public class HandPressable : MonoBehaviour
{
    public OVRHand hand;
    public OVRInput.Controller controller;
    public float distanceThreshold = 0.1f;

    public ProductionLinker productionLinker; //Maybe rewrite this logic? SKal bare bruges til at g�re x n�r man trykker
    public bool isStart; //Bare den funktion der skal k�rer p� scriptet over... Ie. samme handpressable script til begge start stop

    void Update()
    {
        Vector3 handPosition = hand.transform.position;
        Vector3 buttonPosition = this.transform.position;

        if (Vector3.Distance(handPosition, buttonPosition) < distanceThreshold)
        {
            Debug.Log("Button pressed");
            if (isStart)
            {
                productionLinker.ToggleRunning(true);
            } else
            {
                productionLinker.ToggleRunning(false);
            }
        }
    }
}
