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
    private Coroutine _spawnerCoroutine;

    public void ToggleRunning(bool run)
    {
        Debug.Log("TAG ToggleRunning");
        isRunning = run;
        if (isRunning)
        {
            Debug.Log("TAG Inside toggle" + isRunning);
            _spawnerCoroutine = StartCoroutine(Spawner());
        }
        else
        {
            if(_spawnerCoroutine != null)
                StopCoroutine(_spawnerCoroutine);
        }
    }

    private IEnumerator Spawner()
    {
        while (isRunning)
        {
            for (int i = 0; i < numToSpawn; i++)
            {
                Vector3 spawnPosition = transform.position + spawnOffset * i;
                Instantiate(SpawnThing, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnInterval);
            }

            yield return null;
        }
    }
}