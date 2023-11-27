using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System.Reflection;

public class Data3
{
    Dictionary<string, object> _data = new Dictionary<string, object>();
}

public class DiagnosisData : MonoBehaviour
{
    // First Panel Fields
    public TMP_InputField CodeInput;
    public TMP_Text textComponent;
    public TMP_Text textComponent1;

    public List<string> key;
    public List<string> value;

    public void Load()
    {
        string filePath = Application.persistentDataPath + "/data1.json";

        if (System.IO.File.Exists(filePath))
        {
            string json = System.IO.File.ReadAllText(filePath);
            Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            foreach (KeyValuePair<string, object> kvp in data)
            {
                if (kvp.Key == "Code0")
                {
                    textComponent.text = kvp.Value.ToString();
                }
                if (kvp.Key == "Code1")
                {
                    textComponent1.text = kvp.Value.ToString();
                }
            }
        }
    }


    // Collect data and save to JSON
    public void Fetch()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        data = JsonConvert.DeserializeObject<Dictionary<string, object>>(System.IO.File.ReadAllText(Application.persistentDataPath + "/data1.json"));

        foreach (KeyValuePair<string, object> kvp in data)
        {
            key.Add(kvp.Key);
            value.Add(kvp.Value.ToString());
        }

    }

    int count = 0;

    public void CollectAndSaveData()
    {
        // Collect data from the first panel
        string Code = CodeInput.text;

        // Create a dictionary to store the collected data
        Dictionary<string, object> data = new Dictionary<string, object>();

        data.Add("Code" + count, Code);
        count++;

        // Convert the data to JSON using Unity's JsonUtility
        string jsonData = JsonConvert.SerializeObject(data);

        // Save the JSON data to a file
        string filePath = Application.persistentDataPath + "/data1.json";
        System.IO.File.WriteAllText(filePath, jsonData);

        Debug.Log("Data saved to: " + filePath);
    }
}


