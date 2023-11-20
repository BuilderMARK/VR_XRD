using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Meta.WitAi.Json;
using Oculus.Platform;
using UnityEngine.Networking;

public class ApiService : MonoBehaviour
{
    private string apiUrl = "https://via-bp-backend-delegator-bb6352f3951c.herokuapp.com/getMachine?id=1";
    public string authToken;

    public IEnumerator GetMachineData1(Action<MachineData> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(apiUrl))
        {
            www.SetRequestHeader("Authorization", "Bearer " + authToken);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string responseData = www.downloadHandler.text;
                MachineData machineData = JsonConvert.DeserializeObject<MachineData>(responseData);
                TestApi(machineData);
                callback(machineData);
            }
            else
            {
                Debug.LogError("API Request Error: " + www.error);
                Debug.LogError(www);
            }
        }
    }
    
    public async Task<MachineData> GetMachineData()
    {
        Debug.Log("TAG API ER KALDT FRA API SERVICE");
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
                    Debug.LogError("TAG API Request Error: " + response.ReasonPhrase);
                    Debug.LogError(response);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("TAG API Request Exception: " + ex.Message);
                return null;
            }
        }
    }
    
    private void TestApi(MachineData machineData)
    {
        Debug.Log("TAG  batchNo: " + machineData.batches[0].batchNo);
        Debug.Log("TAG endTime " + machineData.batches[0].endTime);
        Debug.Log("TAG StartTime " + machineData.batches[0].startTime);
        Debug.Log("TAG Machine Name: " + machineData.machineName);
        Debug.Log("TAG Description: " + machineData.description);
        Debug.Log("TAG Status: " + machineData.machineRunning);
    }
}