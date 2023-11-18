using UnityEngine;

public class PrefabChanger : MonoBehaviour
{
    public GameObject newPrefab;
    public string targetTag = "item";
    public bool toggle = true;
    public float yOffset = 0.5f; // Offset to raise the new prefab

    private void OnTriggerEnter(Collider other)
    {
        if (toggle && other.gameObject.CompareTag(targetTag))
        {
            // Instantiate the new prefab at the same position as the old GameObject, but slightly higher on the y-axis
            Vector3 newPosition = other.transform.position + new Vector3(0, yOffset, 0);
            GameObject newObject = Instantiate(newPrefab, newPosition, other.transform.rotation);
            newObject.tag = other.tag;
            newObject.transform.localScale = other.transform.localScale;

            // Copy the material
            MeshRenderer oldRenderer = other.gameObject.GetComponent<MeshRenderer>();
            MeshRenderer newRenderer = newObject.GetComponent<MeshRenderer>();
            if (oldRenderer != null && newRenderer != null)
            {
                newRenderer.material = oldRenderer.material;
            }

            // Copy the velocity
            Rigidbody oldRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Rigidbody newRigidbody = newObject.GetComponent<Rigidbody>();
            if (oldRigidbody != null && newRigidbody != null)
            {
                newRigidbody.velocity = oldRigidbody.velocity;
            }

            Destroy(other.gameObject);
        }
    }
}