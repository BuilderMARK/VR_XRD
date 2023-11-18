using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MachineSwitch : MonoBehaviour
{
    public GameObject targetObject;
    public bool isVisible;

    public UnityEvent<bool> OnButtonPressed;
    
    //Bad manners sku have brugt interface her'
    public MaterialChanger MaterialChanger;
    public PrefabChanger PrefabChanger;
        
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
        if (MaterialChanger)
            MaterialChanger.toggle = !MaterialChanger.toggle;
        if (PrefabChanger)
            PrefabChanger.toggle = !PrefabChanger.toggle;
        
        OnButtonPressed?.Invoke(isVisible);
    }
}
