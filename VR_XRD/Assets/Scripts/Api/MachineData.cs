using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineData : MonoBehaviour
{
        public int statusCodeID;
        public string statusDescription;
        public int batchNo;
        public int machineID;
        public int producedItems;
        public DateTime startTime;
        public DateTime endTime;
        public string machineName;
        public string description;
        public bool machineRunning;


    public MachineData()
    {
        statusCodeID = 0;
        statusDescription = string.Empty;
        batchNo = 0;
        machineID = 0;
        producedItems = 0;
        startTime = DateTime.MinValue;
        endTime = DateTime.MinValue;
        machineName = string.Empty;
        description = string.Empty;
        machineRunning = false;
    }
}
