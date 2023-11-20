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
    private bool isInvoking = false;
    private MachineData machineDataReffrence = null;
    public bool isRunning = false; //Should be toggable though the machine buttons
    private float calculateSpawnInterval;

    void Start()
    {
        ToggleRunning(isRunning);
    }

    public void ToggleRunning(bool run)
    {
        isRunning = run;
        if (isRunning)
        {
            if (!isInvoking) 
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
            CancelInvoke("UpdateMachine");
            isInvoking = false; //Set isInvoking back to false after calling CancelInvoke
        }
    }

    private IEnumerator FetchMachine()
    {
        while(isRunning){
            machineDataReffrence = new MachineData();
            yield return StartCoroutine(apiService.GetMachineData1((MachineData data) =>
            {
                machineDataReffrence = data;
                Debug.Log("TAG MACHINE " + machineDataReffrence);
                Debug.Log(data.batches);  
            }));
            yield return new WaitForSeconds(30);
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
            Debug.Log("TAG machineDataReffrence.statusCode.statusDescription " + machineDataReffrence.statusCode.statusDescription);
            //Udkommenteret for demo, men logikken er rigtig i praktsis!
            
            //if (machineDataReffrence.statusCode.statusDescription.Equals("stopped"))
            //{
                spawner.numToSpawn = machineDataReffrence.batches[0].producedItems;
                //spawner.ToggleRunning(machineDataReffrence.machineRunning);
                spawner.ToggleRunning(true);
                spawner.spawnInterval = (float)CalculateSpawnInterval();
            //}
            //else
            //{
            //    Debug.Log("TAG MachineDataReffrence is null");
            //}
        }
    }

    public MachineData GetMachineData() {
        return machineDataReffrence;
    }
}