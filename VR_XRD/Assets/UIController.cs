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
        if (machineData != null)
        {
            machineText.SetText("Machine " + machineData.machineName + " - " + machineData.machineID);

            string machineInfoString = "";
            machineInfoString += "Batch: " + machineData.currentBatch.batchNo + "\b";
            machineInfoString += "Batch start: " + machineData.currentBatch.startTime + "\b";
            machineInfoString += "Batch end: " + machineData.currentBatch.endTime + "\b";
            machineInfoString += "Batch size: " + machineData.currentBatch.producedItems + "\b";
            machineInfoString += "\b";

            if (machineData.machineRunning) {
                machineInfoString += "Status: Machine is running";
            } else {
                machineInfoString += "Status: Machine is stopped";
            }

            machineInfoText.SetText(machineInfoString);
        }

    }
}
