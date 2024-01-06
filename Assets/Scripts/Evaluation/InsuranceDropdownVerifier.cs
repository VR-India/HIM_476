using Michsky.MUIP;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InsuranceData
{
    public string patientName;
    public string insuranceName;
    public string insuranceType;
}

public class InsuranceDropdownVerifier : MonoBehaviour
{
    public GameObject[] insuranceDD;
    public InsuranceData[] patientInsuranceInfo;
    public TMP_Text resultCanvas;
    public Button checkButton;
    public ActivePatientData activePatient;

    private void Start()
    {
        //insuranceDD = GameObject.FindGameObjectsWithTag("insuranceDD");
    }

    public void checkInsuranceData()
    {
        if (insuranceDD[0].GetComponent<CustomDropdown>().selectedText.text != patientInsuranceInfo[activePatient.currentPatinetIndex].insuranceName
        || insuranceDD[1].GetComponent<CustomDropdown>().selectedText.text != patientInsuranceInfo[activePatient.currentPatinetIndex].insuranceType)
        {
            resultCanvas.text = "Wrong Insurance detail Selected";
            activePatient.insuranceDDCheck = false;
        }
        else
        {
            resultCanvas.text = "Correct Insurance detail Selected";
            checkButton.gameObject.SetActive(false);
            activePatient.insuranceDDCheck = true;
        }
    }
}