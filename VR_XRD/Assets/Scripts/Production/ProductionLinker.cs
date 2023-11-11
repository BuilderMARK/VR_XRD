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



    // Start is called before the first frame update
    void Start()
    {
        spawner.Running = true;
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
    }


    private void UpdateMachine()
    {
        if (machineDataReffrence == null) return;
        spawner.numToSpawn = 10;
        spawner.Running = machineDataReffrence.machineRunning;
        //Display function
    
    
    
    }

}
