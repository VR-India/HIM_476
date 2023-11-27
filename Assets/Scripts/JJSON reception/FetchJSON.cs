using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FetchJSON : MonoBehaviour
{
    public CustomDetails details = new();

    public GameObject info;
    public GameObject contentLog;

    public void OnClickLogs()
    {
        foreach (var item in contentLog.GetComponentsInChildren<RectTransform>())
        {
            if (item.gameObject.name == contentLog.name)
                continue;
            
            Destroy(item.gameObject);
        }

        details = JsonUtility.FromJson<CustomDetails>(File.ReadAllText(Application.dataPath + "/ReceptionData.json"));

        for(int i = 0; i < details.PersonDetailsList.Count; i++)  
        {
            TMP_Text[] texts = info.GetComponentsInChildren<TMP_Text>();
            Instantiate(info, contentLog.transform);
            texts[0].text = "";
            texts[1].text = details.PersonDetailsList[i].GeneralDetails.firstName;
            texts[2].text = details.PersonDetailsList[i].GeneralDetails.middleName;
            texts[3].text = details.PersonDetailsList[i].GeneralDetails.lastName;
            texts[4].text = details.PersonDetailsList[i].GeneralDetails.MRN;
            texts[5].text = "";
            texts[6].text = details.PersonDetailsList[i].patientInsurance.insurance.payer;
        }
    }
}
