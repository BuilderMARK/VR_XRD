using UnityEngine;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Meta.WitAi.Json;

public class ApiService : MonoBehaviour
{
    private string apiUrl = "http://localhost:5000/getMachine?id=1";
    public string authToken;

    public async void Start()
    {
        var machineData = await GetMachineData();
        // Handle machineData if necessary
    }

    public async Task<MachineData> GetMachineData()
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Debug.Log("raw responseData" + responseData);
                    MachineData machineData = JsonConvert.DeserializeObject<MachineData>(responseData);
                    TestApi(machineData); 
                    return machineData;
                }
                else
                {
                    Debug.LogError("API Request Error: " + response.ReasonPhrase);
                    Debug.LogError(response);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("API Request Exception: " + ex.Message);
                return null;
            }
        }
    }
    
    private void TestApi(MachineData machineData)
    {
        Debug.Log("batchNo: " + machineData.batches[0].batchNo);
        Debug.Log("endTime " + machineData.batches[0].endTime);
        Debug.Log("StartTime " + machineData.batches[0].startTime);
        Debug.Log("Machine Name: " + machineData.machineName);
        Debug.Log("Description: " + machineData.description);
        Debug.Log("Status: " + machineData.machineRunning);
    }
}