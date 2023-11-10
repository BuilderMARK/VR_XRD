using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiStarter : MonoBehaviour
{
    public ApiService apiService;

    // Start is called before the first frame update
    async  void Start()
    {
       MachineData machineData =  await apiService.GetMachineData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
