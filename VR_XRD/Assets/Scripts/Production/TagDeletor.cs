using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagDeletor : MonoBehaviour
{
    public string tag = "item";

    void Start()
    {
        //DeleteObjects();
    }

    /* void DeleteObjects()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            Destroy(other.gameObject);
        }
    }
}
