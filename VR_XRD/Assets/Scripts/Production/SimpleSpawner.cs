using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject SpawnThing;
    public int numToSpawn = 1;
    public float spawnInterval = 1.0f;
    public Vector3 spawnOffset = new Vector3 (0, 0, 0);
    public bool Running = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (Running)
        {
            for (int i = 0; i < numToSpawn; i++)
            {
                Vector3 spawnPosition = transform.position + spawnOffset * i;
                Instantiate(SpawnThing, spawnPosition, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
