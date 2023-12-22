using Michsky.MUIP;
using TMPro;
using UnityEngine;

[System.Serializable]
public class insuranceData
{
    public string patientName;
    public string insuranceName;
    public string insuranceType;
}

public class dropdownFetch : MonoBehaviour
{
    public GameObject[] insuranceDD;
    public insuranceData[] patientInsuranceInfo;
    public TMP_Text resultCanvas;

    private void Start()
    {
        //insuranceDD = GameObject.FindGameObjectsWithTag("insuranceDD");
    }

    public void checkInsuranceData()
    {
        if (insuranceDD[0].GetComponent<CustomDropdown>().selectedText.text != patientInsuranceInfo[PlayerPrefs.GetInt("patient") - 1].insuranceName
        || insuranceDD[1].GetComponent<CustomDropdown>().selectedText.text != patientInsuranceInfo[PlayerPrefs.GetInt("patient") - 1].insuranceType)
        {
            resultCanvas.text = "Wrong Insurance detail Selected";
        }
        else
            resultCanvas.text = "Correct Insurance detail Selected";
    }
}