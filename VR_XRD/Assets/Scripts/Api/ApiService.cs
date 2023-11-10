using UnityEngine;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Meta.WitAi.Json;


[UnityEngine.Scripting.Preserve]
public class ApiService : MonoBehaviour
{
    private string apiUrl;
    public string authToken;

    private async void Start()
    {
        var machineData = await GetMachineData();
        // Handle machineData if necessary
    }

    private async Task<MachineData> GetMachineData()
    {
        apiUrl = "http://localhost:5000/getMachine?id=1";
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Debug.Log(responseData);
                    MachineData machineData = JsonConvert.DeserializeObject<MachineData>(responseData);
                    TestApi(machineData); 
                    Debug.Log(machineData.ToString());
                    return machineData;
                }
                else
                {
                    Debug.LogError("API Request Error: " + response.ReasonPhrase);
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
    
    // Consider removing after testing
    private void TestApi(MachineData machineData)
    {
        Debug.Log("Machine Name: " + machineData.machineName);
        Debug.Log("Description: " + machineData.description);
        Debug.Log("Status: " + machineData.statusDescription);
    }
}