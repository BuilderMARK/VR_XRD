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

    public async Task<MachineData> GetMachineData()
    {
        apiUrl = "http://localhost:5000/getMachine?id=1";
        try
        {
            Debug.Log("Api Start");
            using (HttpClient client = new HttpClient())
            {
                //TODO Måske overvej en bedre måde at indsætte en token på, men tænker det er for meget arbejde og skulle logge ind først
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    Debug.Log("Api SuccessS ");
                    string responseData = await response.Content.ReadAsStringAsync();
                    MachineData machineData = JsonConvert.DeserializeObject<MachineData>(responseData);
                    TestApi(machineData);
                    Debug.Log(machineData.ToString());
                    return machineData;
                    
                }
                else
                {
                    Debug.LogError("Fejl i API-anmodning: " + response.ReasonPhrase);
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Fejl i API-anmodning: " + ex.Message);
            return null;
        }
        
    }
    //TODO Skal slettes senere når vi ved det virker
    void TestApi(MachineData machineData)
    {
        Debug.Log("Maskinens navn: " + machineData.machineName);
        Debug.Log("Beskrivelse: " + machineData.description);
        Debug.Log("Status: " + machineData.statusDescription);
    }
}