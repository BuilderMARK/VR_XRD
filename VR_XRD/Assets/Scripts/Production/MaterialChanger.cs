using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material newMaterial;
    public string targetTag = "item";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            MeshRenderer renderer = other.gameObject.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.material = newMaterial;
            }
        }
    }
}