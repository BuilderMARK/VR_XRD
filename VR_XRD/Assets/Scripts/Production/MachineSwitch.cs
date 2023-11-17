using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSwitch : MonoBehaviour
{
    public GameObject targetObject;
    public bool isVisible;

    void Update()
    {
        if (targetObject != null)
        {
            foreach (Transform child in transform)
            {
                MeshRenderer renderer = child.gameObject.GetComponent<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.enabled = isVisible;
                }
            }
        }
    }

    public void ToggleSwitch()
    {
        isVisible = !isVisible;
    }
}
