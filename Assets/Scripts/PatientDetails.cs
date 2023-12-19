using Michsky.MUIP;
using myData;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
internal class PersonDetails
{
    [JsonProperty("first name")]
    public string firstName;

    [JsonProperty("middle name")]
    public string middleName;

    [JsonProperty("last name")]
    public string lastName;

    [JsonProperty("gender")]
    public string gender;

    [JsonProperty("address line 1")]
    public string addressLine1;

    [JsonProperty("address line 2")]
    public string addressLine2;

    [JsonProperty("zipcode")]
    public int zipCode;

    [JsonProperty("city")]
    public string city;

    [JsonProperty("state")]
    public string state;

    [JsonProperty("country")]
    public string country;

    [JsonProperty("county")]
    public string county;

    [JsonProperty("insurance address line 1")]
    public string insuranceAddressLine1;

    [JsonProperty("insurance address line 2")]
    public string insuranceAddressLine2;

    [JsonProperty("insurance start date")]
    public string insuranceStartDate;

    [JsonProperty("subscriber member")]
    public string subscriberMember;
}

public class PatientDetails : MonoBehaviour
{
    public ButtonManager selectButton;
    public ButtonManager trainingButton;

    private List<PersonDetails> patientList;
    [SerializeField]
    private PersonDetails currentPatient;
    [SerializeField]
    private CustomDropdown dropdown;

    public BNG.SnapZone[] scannerCardHolder;
    public Image checkInScanImg;

    void Start()
    {
        patientList = new();

        selectButton.onClick.AddListener(delegate { AddDetailsOfSelectedPatient(dropdown.selectedText.text); });
        trainingButton.onClick.AddListener(delegate { AddDetailsOfSelectedPatient(fadeAndMatChange.patient.name); });
        //dropdown.onValueChanged.AddListener(delegate { AddDetailsOfSelectedPatient(dropdown.selectedText.text); });

        LoadDetailsFromJson();
    }

    void AddDetailsToJson()
    {
        patientList.Add(currentPatient);

        string json = JsonConvert.SerializeObject(patientList);
        File.WriteAllText(Application.dataPath + "/patient.json", json);

        currentPatient = new();
    }

    void LoadDetailsFromJson()
    { 
        string json = Resources.Load<TextAsset>("jsonBillData/patient").text;
        patientList = JsonConvert.DeserializeObject<List<PersonDetails>>(json);
    }

    void AddDetailsOfSelectedPatient(string name)
    {
        foreach (var item in patientList)
        {
            string nameJSON = item.firstName + " " + item.lastName;

            if (nameJSON == name)
                currentPatient = item;
        }
    }

    public void OnScanButtonPressed()
    {
        animateManager.instance.scannerGhost.SetActive(false);

        Debug.Log("Scanning");

        if (scannerCardHolder[0].HeldItem == null && scannerCardHolder[1].HeldItem == null)
        {
            Debug.Log("data null");
            return;
        }

        checkInScanImg.sprite = fadeAndMatChange.checkInScanSprite;

        foreach (var item in FindObjectsOfType<CustomInputField>())
        {
            item.AnimateIn();
        }

        FillDetailsInPanels();
    }

    void FillDetailsInPanels()
    {
        var patientGeneralInfo = DataRef.instance.currentPersonDetails.GeneralDetails;
        var patientInsuranceInfo = DataRef.instance.currentPersonDetails.patientInsurance.insurance;

        // General
        patientGeneralInfo.firstName.text = currentPatient.firstName;
        patientGeneralInfo.lastName.text = currentPatient.lastName;
        patientGeneralInfo.middleName.text = currentPatient.middleName;
        patientGeneralInfo.gender.selectedText.text = currentPatient.gender;

        // Address
        patientGeneralInfo.addressLine1.text = currentPatient.addressLine1;
        patientGeneralInfo.addressLine2.text = currentPatient.addressLine2;
        patientGeneralInfo.zipCode.text = currentPatient.zipCode.ToString();
        patientGeneralInfo.city.selectedText.text = currentPatient.city;
        patientGeneralInfo.state.selectedText.text = currentPatient.state;
        patientGeneralInfo.country.selectedText.text = currentPatient.country;
        patientGeneralInfo.county.selectedText.text = currentPatient.county;

        // Insurance
        patientInsuranceInfo.addressLine1.text = currentPatient.insuranceAddressLine1;
        patientInsuranceInfo.addressLine2.text = currentPatient.insuranceAddressLine2;
        patientInsuranceInfo.startDate.text = currentPatient.insuranceStartDate;
        patientInsuranceInfo.subscriberMember.text = currentPatient.subscriberMember;
    }
}
