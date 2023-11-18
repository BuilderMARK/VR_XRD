using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public ProductionLinker productionLinker;

    public TextMeshProUGUI machineText;

    public TextMeshProUGUI machineInfoText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MachineData machineData = productionLinker.GetMachineData();


        /* Used for testing UI

        machineData = new MachineData();
        machineData.machineName = "Morten";
        machineData.machineID = 99;

        Batch batch = new Batch();
        machineData.currentBatch = batch;

        machineData.currentBatch.batchNo = 99;
        machineData.currentBatch.startTime = new System.DateTime();
        machineData.currentBatch.endTime = new System.DateTime();
        machineData.currentBatch.producedItems = 99;
        machineData.machineRunning = true;
        */

        if (machineData != null)
        {
            machineText.SetText("Machine: " + machineData.machineName + " - " + machineData.machineID);

            string machineInfoString = "";
            machineInfoString += "Batch: " + machineData.currentBatch.batchNo + "<br>";
            machineInfoString += "Batch start: " + machineData.currentBatch.startTime + "<br>";
            machineInfoString += "Batch end: " + machineData.currentBatch.endTime + "<br>";
            machineInfoString += "Batch size: " + machineData.currentBatch.producedItems + "<br>";
            machineInfoString += "<br>";

            if (machineData.machineRunning) {
                machineInfoString += "Machine is running";
            } else {
                machineInfoString += "Machine is stopped";
            }

            machineInfoText.SetText(machineInfoString);
        }

    }
}
