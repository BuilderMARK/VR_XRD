using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionLinker : MonoBehaviour
{


    public ApiService apiService;
    public SimpleSpawner spawner;
    public DisplayScript display;

    private MachineData machineDataReffrence;


    public bool isRunning = false; //Should be toggable though the machine buttons
    private float calculateSpawnInterval;



    // Start is called before the first frame update
    void Start()
    {
        //spawner.Running = true;
        InvokeRepeating("FetchMachine", 1.0f, 2.0f);
        InvokeRepeating("UpdateMachine", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async void FetchMachine()
    {
        machineDataReffrence = new MachineData();
        machineDataReffrence = await apiService.GetMachineData();
        Debug.Log("FetchMachine" + machineDataReffrence.batches[0].batchNo);
    }
     double  CalculateSpawnInterval()
      {
          var startTime = machineDataReffrence.batches[0].startTime;
    var endTime = machineDataReffrence.batches[0].endTime;
    var producedItems = machineDataReffrence.batches[0].producedItems;
    if (producedItems <= 0)
    {
        throw new InvalidOperationException("producedItems must be greater than zero.");
    }
    TimeSpan interval = endTime - startTime;
    var totalSeconds = interval.TotalSeconds;
    var calculatedSpawnInterval = totalSeconds / producedItems;
    Debug.Log(calculatedSpawnInterval);
    return calculatedSpawnInterval;
    }


private void UpdateMachine()
    {
        
        Debug.Log("machineDataReffrence.statusCode.statusDescription" + machineDataReffrence.statusCode.statusDescription);
        if (machineDataReffrence.statusCode.statusDescription.Equals("Aktiv"))
        {
        spawner.numToSpawn = machineDataReffrence.batches[0].producedItems;
        spawner.Running = machineDataReffrence.machineRunning;
        spawner.spawnInterval = (float)CalculateSpawnInterval();

        }
       
        //Display function
    
    
    
    }

}
