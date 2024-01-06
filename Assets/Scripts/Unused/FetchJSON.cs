using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Class responsible for fetching JSON data and displaying it in a log.
/// </summary>
public class FetchJSON : MonoBehaviour
{
    public CustomDetails details = new();

    public GameObject info;
    public GameObject contentLog;

    /// <summary>
    /// Called when the "Logs" button is clicked.
    /// </summary>
    public void OnClickLogs()
    {
        // Clear existing log entries
        foreach (var item in contentLog.GetComponentsInChildren<RectTransform>())
        {
            if (item.gameObject.name == contentLog.name)
                continue;

            Destroy(item.gameObject);
        }

        // Fetch data from JSON file
        details = JsonUtility.FromJson<CustomDetails>(File.ReadAllText(Application.dataPath + "/ReceptionData.json"));

        // Display fetched data in the log
        for (int i = 0; i < details.PersonDetailsList.Count; i++)
        {
            TMP_Text[] texts = info.GetComponentsInChildren<TMP_Text>();
            Instantiate(info, contentLog.transform);
            texts[0].text = null;
            texts[1].text = details.PersonDetailsList[i].GeneralDetails.firstName;
            texts[2].text = details.PersonDetailsList[i].GeneralDetails.middleName;
            texts[3].text = details.PersonDetailsList[i].GeneralDetails.lastName;
            texts[4].text = details.PersonDetailsList[i].GeneralDetails.MRN;
            texts[5].text = null;
            texts[6].text = details.PersonDetailsList[i].patientInsurance.insurance.payer;
        }
    }
}
