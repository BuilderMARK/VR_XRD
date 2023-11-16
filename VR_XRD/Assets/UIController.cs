using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public ProductionLinker productionLinker;

    public TextMeshProUGUI batchIdText;

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
            batchIdText.SetText(machineData.machineID.ToString());
        }

    }
}
