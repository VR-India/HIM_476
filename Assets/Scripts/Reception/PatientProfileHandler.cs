using Michsky.MUIP;
using myData;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;

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

public class PatientProfileHandler : MonoBehaviour
{
    public ButtonManager selectButton;
    public ButtonManager trainingButton;

    [SerializeField]
    private CustomDropdown dropdown;

    [SerializeField]
    private List<PersonDetails> patientList;
    private PersonDetails currentPatient;

    public BNG.SnapZone[] scannerCardHolder;
    public Image checkInScanImg;

    void Start()
    {
        patientList = new();

        selectButton.onClick.AddListener(delegate { AddDetailsOfSelectedPatient(dropdown.selectedText.text); });
        trainingButton.onClick.AddListener(delegate { AddDetailsOfSelectedPatient(PatientResourceHandler.patient.name); });
        //dropdown.onValueChanged.AddListener(delegate { AddDetailsOfSelectedPatient(dropdown.selectedText.text); });

        LoadDetailsFromJson();
    }

    /// <summary>
    /// Adds the details of the current patient to the patient list and saves the updated list to a JSON file.
    /// </summary>
    void AddDetailsToJson()
    {
        if (currentPatient != null)
        {
            // Add the current patient to the list
            patientList.Add(currentPatient);

            // Serialize the patient list to JSON
            string json = JsonConvert.SerializeObject(patientList);

            // Write the JSON data to a file
            File.WriteAllText(Application.dataPath + "/patient.json", json);

            // Reset the current patient for future entries
            currentPatient = new();
        }
    }

    /// <summary>
    /// Loads patient details from a JSON file located in the Resources folder and deserializes them into the patient list.
    /// </summary>
    void LoadDetailsFromJson()
    {
        // Load the JSON file as a TextAsset from the Resources folder
        string json = Resources.Load<TextAsset>("jsonBillData/patient").text;

        // Deserialize the JSON data into the patient list
        patientList = JsonConvert.DeserializeObject<List<PersonDetails>>(json);
    }

    /// <summary>
    /// Sets the current patient details based on the provided name by searching the patient list.
    /// </summary>
    /// <param name="name">The full name of the patient to search for.</param>
    void AddDetailsOfSelectedPatient(string name)
    {
        //foreach (var item in patientList)
        //{
        //    string nameJSON = item.firstName + " " + item.lastName;

        //    if (nameJSON == name)
        //        currentPatient = item;
        //}

        // Find the patient in the list with the matching full name
        currentPatient = patientList.Find(patient => $"{patient.firstName} {patient.lastName}" == name);
    }

    /// <summary>
    /// Handles the button press event for scanning, updating UI elements and displaying patient details.
    /// </summary>
    public void OnScanButtonPressed()
    {
        // Deactivate scanner ghost
        PatientInteractionAnimator.instance.scannerGhost.SetActive(false);
        Debug.Log("Scanning");

        // Check if scanner data is available
        if (scannerCardHolder[0].HeldItem == null && scannerCardHolder[1].HeldItem == null)
        {
            Debug.Log("data null");
            return;
        }

        // Set the scan image sprite
        checkInScanImg.sprite = PatientResourceHandler.checkInScanSprite;

        // Animate in CustomInputFields
        foreach (var item in FindObjectsOfType<CustomInputField>())
        {
            item.AnimateIn();
        }

        // Fill details in UI panels
        FillDetailsInPanels();
    }

    /// <summary>
    /// Fills patient details in UI panels based on the current patient data.
    /// </summary>
    void FillDetailsInPanels()
    {
        if (DataRef.instance != null && DataRef.instance.currentPersonDetails != null)
        {
            var patientGeneralInfo = DataRef.instance.currentPersonDetails.GeneralDetails;
            var patientInsuranceInfo = DataRef.instance.currentPersonDetails.patientInsurance.insurance;

            // General
            patientGeneralInfo.firstName.text = currentPatient?.firstName;
            patientGeneralInfo.lastName.text = currentPatient?.lastName;
            patientGeneralInfo.middleName.text = currentPatient?.middleName;
            patientGeneralInfo.gender.selectedText.text = currentPatient?.gender;

            // Address
            patientGeneralInfo.addressLine1.text = currentPatient?.addressLine1;
            patientGeneralInfo.addressLine2.text = currentPatient?.addressLine2;
            patientGeneralInfo.zipCode.text = currentPatient?.zipCode.ToString();
            patientGeneralInfo.city.selectedText.text = currentPatient?.city;
            patientGeneralInfo.state.selectedText.text = currentPatient?.state;
            patientGeneralInfo.country.selectedText.text = currentPatient?.country;
            patientGeneralInfo.county.selectedText.text = currentPatient?.county;

            // Insurance
            patientInsuranceInfo.addressLine1.text = currentPatient?.insuranceAddressLine1;
            patientInsuranceInfo.addressLine2.text = currentPatient?.insuranceAddressLine2;
            patientInsuranceInfo.startDate.text = currentPatient?.insuranceStartDate;
            patientInsuranceInfo.subscriberMember.text = currentPatient?.subscriberMember;
        }
    }
}
