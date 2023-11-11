using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject SpawnThing;
    public int numToSpawn = 1;
    public float spawnInterval = 1.0f;
    public Vector3 spawnOffset = new Vector3(0, 0, 0);
    private bool _running = false;
    private Coroutine _spawnerCoroutine;

    public bool Running //er lavet så det stadig bare er en simpel bool.. dyrk fancy set
    {
        get { return _running; }
        set
        {
            _running = value;
            if (_running)
            {
                if (_spawnerCoroutine != null)
                {
                    StopCoroutine(_spawnerCoroutine);
                }
                _spawnerCoroutine = StartCoroutine(Spawner());
            }
            else
            {
                if (_spawnerCoroutine != null)
                {
                    StopCoroutine(_spawnerCoroutine);
                }
            }
        }
    }

    void Start()
    {
        _spawnerCoroutine = StartCoroutine(Spawner());
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