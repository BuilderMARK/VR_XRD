using System;
using System.Collections.Generic;

public class MachineData
{
    public int machineID { get; set; }
    public string machineName { get; set; }
    public string description { get; set; }
    public StatusCode statusCode { get; set; }
    public List<Batch> batches { get; set; }
    public Batch currentBatch { get; set; }
    public bool machineRunning { get; set; }
}

public class StatusCode
{
    public int statusCodeId { get; set; }
    public string statusDescription { get; set; }
}

public class Batch
{
    public int batchNo { get; set; }
    public int machineId { get; set; }
    public int producedItems { get; set; }
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
}

