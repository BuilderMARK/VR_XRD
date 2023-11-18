using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject SpawnThing;
    public int numToSpawn = 1;
    public float spawnInterval = 1.0f;
    public Vector3 spawnOffset = new Vector3(0, 0, 0);
    public bool isRunning = false;

    private float timeSinceLastSpawn;

    private void Start()
    {
        timeSinceLastSpawn = 0;
    }

    private void Update()
    {
        if (isRunning)
        {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= spawnInterval)
            {
                SpawnObjects();
                timeSinceLastSpawn = 0;
            }
        }
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < numToSpawn; i++)
        {
            Vector3 spawnPosition = transform.position + spawnOffset * i;
            Instantiate(SpawnThing, spawnPosition, Quaternion.identity);
        }
    }

    public void ToggleRunning(bool run)
    {
        isRunning = run;
    }
}