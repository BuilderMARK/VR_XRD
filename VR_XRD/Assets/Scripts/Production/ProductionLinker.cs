using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionLinker : MonoBehaviour
{


    public ApiService apiService;
    public SimpleSpawner spawner;
    public DisplayScript display;
    private int test = 1;
    private bool isInvoking = false; //New variable to track InvokeRepeating


    private MachineData machineDataReffrence = null;


    public bool isRunning = false; //Should be toggable though the machine buttons
    private float calculateSpawnInterval;



    // Start is called before the first frame update
    void Start()
    {
        ToggleRunning(isRunning);
        
    }

    public void ToggleRunning(bool run)
    {
        isRunning = run;
        if (isRunning)
        {
            if (!isInvoking) //Check if InvokeRepeating has been called
            {
                StartCoroutine(FetchMachine());
                //InvokeRepeating("FetchMachine", 1.0f, 3.0f);
                InvokeRepeating("UpdateMachine", 2.0f, 2.0f);
                isInvoking = true; //Set isInvoking to true after calling InvokeRepeating
            }
        }
        else
        {
            StopCoroutine(FetchMachine());
            //CancelInvoke("FetchMachine");
            CancelInvoke("UpdateMachine");
            isInvoking = false; //Set isInvoking back to false after calling CancelInvoke
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FetchMachine()
    {
        while(isRunning){
            machineDataReffrence = new MachineData();
            yield return StartCoroutine(apiService.GetMachineData1((MachineData data) =>
            {
                machineDataReffrence = data;
                Debug.Log(data.batches);  
            }));
            yield return new WaitForSecondsRealtime(30);
        }
    }
     private double CalculateSpawnInterval()
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
        if (machineDataReffrence != null && machineDataReffrence.statusCode != null)
        {
        Debug.Log("TAG machineDataReffrence.statusCode.statusDescription" + machineDataReffrence.statusCode.statusDescription);
        if (machineDataReffrence.statusCode.statusDescription.Equals("Aktiv"))
        {
        spawner.numToSpawn = machineDataReffrence.batches[0].producedItems;
        spawner.ToggleRunning(machineDataReffrence.machineRunning);
        spawner.spawnInterval = (float)CalculateSpawnInterval();
        }
        else
        {
            Debug.Log("TAG MachineDataReffrence is null");
        }

        }
       
        //Display function
    
    
    
    }

    public MachineData GetMachineData() {
        return machineDataReffrence;
    }
}
