using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material newMaterial;
    public string targetTag = "item";
    public bool toggle = true;

    private void OnTriggerEnter(Collider other)
    {
        if (toggle && other.gameObject.CompareTag(targetTag))
        {
            MeshRenderer renderer = other.gameObject.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.material = newMaterial;
            }
        }
    }
}