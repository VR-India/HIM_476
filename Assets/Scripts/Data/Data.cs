using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Michsky.MUIP;
using myData;
using System.IO;

[System.Serializable]
public class CustomDetails
{
    public List<PersonDetails_1> PersonDetailsList = new();
}

[System.Serializable]
public class PersonDetails_1
{
    public GeneralDetails GeneralDetails = new();
    public Guarantor guarantor = new();
    public RelatedPerson relatedPerson = new();
    public PatientInsurance patientInsurance = new();
}

[System.Serializable]
public class GeneralDetails
{
    public string facility;
    public string SSN;
    public string _SSN;
    public string MRN;
    public string firstName;
    public string middleName;
    public string lastName;
    public string gender;
    public string preferredLanguage;
    public string maritalStatus;
    public string addressLine1;
    public string addressLine2;
    public string zipCode;
    public string city;
    public string state;
    public string county;
    public string country;
}

[System.Serializable]
public class Guarantor
{
    public string startDate;
    public string endDate;
    public string relationship;
    public string firstName;
    public string middleName;
    public string lastName;
    public string gender;
    public string dateOfBirth;
    public string mobilePhone;
    public string addressLine1;
    public string addressLine2;
    public string zipCode;
    public string city;
    public string state;
    public string county;
    public string country;
    public string employer;

    public List<TMP_Text> displaySeqGuarantor;
    public List<TMP_Text> displayNameGuarantor;
    public List<TMP_Text> displayRelationGuarantor;
    public List<TMP_Text> displayContactGuarantor;
    public List<TMP_Text> displayAddressGuarantor;
    public List<TMP_Text> displayStartDateGuarantor;
    public List<TMP_Text> displayEndDateGuarantor;
}

[System.Serializable]
public class RelatedPerson
{
    public string relation;
    public string firstName;
    public string middleName;
    public string lastName;
    public string gender;
    public string dateOfBirth;
    public string addressLine1;
    public string addressLine2;
    public string zipCode;
    public string city;
    public string state;
    public string county;
    public string country;
    public string employer;
    public string role;

    public List<TMP_Text> displayRoleRelated;
    public List<TMP_Text> displayNameRelated;
    public List<TMP_Text> displayGenderRelated;
    public List<TMP_Text> displayRelationRelated;
}

[System.Serializable]
public class PatientInsurance
{
    public Subscriber subscriber = new();
    public Insurance insurance = new();
}

[System.Serializable]
public class Subscriber
{
    public string relation;
    public string firstName;
    public string middleName;
    public string lastName;
    public string employer;
}

[System.Serializable]
public class Insurance
{
    public string healthPlans;
    public string payer;
    public string financialClass;
    public string addressLine1;
    public string addressLine2;
    public string zipCode;
    public string city;
    public string state;
    public string county;
    public string country;
    public string startDate;
    public string endDate;
    public string subscriberMember;
    public string groupNumber;

    public List<TMP_Text> displaySeqInsurance;
    public List<TMP_Text> displayHealthPlansInsurance;
    public List<TMP_Text> displayPayerInsurance;
    public List<TMP_Text> displayFinancialClass;
    public List<TMP_Text> displaySubscriberInsurance;
    public List<TMP_Text> displayMemberInsurance;
    public List<TMP_Text> displayGroupNumberInsurance;
    public List<TMP_Text> displayStartDateInsurance;
    public List<TMP_Text> displayEndDateInsurance;

}

[System.Serializable]
public class InsuranceAuthorities
{
    public string relation;
    public string firstName;
    public string middleName;
    public string lastName;
}

public class Data : MonoBehaviour
{
    public TMP_InputField SSN;
    public TMP_InputField MRN;
    public TMP_InputField firstName;
    public TMP_InputField middleName;
    public TMP_InputField lastName;
    public TMP_InputField addressLine1;
    public TMP_InputField addressLine2;
    public TMP_InputField zipCode;

    public CustomDropdown facility;
    public CustomDropdown if_SSN;
    public CustomDropdown gender;
    public CustomDropdown preferredLanguage;
    public CustomDropdown maritalStatus;
    public CustomDropdown city;
    public CustomDropdown state;
    public CustomDropdown county;
    public CustomDropdown country;

    public CustomDetails details = new();
    public PersonDetails_1 patientDetails = new();

    //private void Awake()
    //{
    //    details = JsonUtility.FromJson<CustomDetails>(File.ReadAllText(Application.dataPath + "/ReceptionData.json"));
    //}

    int iGuarantor = 0;

    /// <summary>
    /// Fills guarantor details and updates the display.
    /// </summary>
    public void FillGuarantor()
    {
        var guarantor = patientDetails.guarantor;

        // Check if there are more guarantor details to display and if the required data is available.
        if (iGuarantor < guarantor.displayNameGuarantor.Count && !string.IsNullOrEmpty(guarantor.firstName))
        {
            guarantor.displaySeqGuarantor[iGuarantor].text = "000" + (iGuarantor + 1);
            guarantor.displayNameGuarantor[iGuarantor].text = guarantor.firstName + " " + guarantor.middleName + " " + guarantor.lastName;
            guarantor.displayRelationGuarantor[iGuarantor].text = guarantor.relationship;
            guarantor.displayContactGuarantor[iGuarantor].text = guarantor.mobilePhone;
            guarantor.displayAddressGuarantor[iGuarantor].text = guarantor.addressLine1 + " " + guarantor.addressLine2;
            guarantor.displayStartDateGuarantor[iGuarantor].text = guarantor.startDate;
            guarantor.displayEndDateGuarantor[iGuarantor].text = guarantor.endDate;
            iGuarantor++;
        }
    }

    int iRelated = 0;

    /// <summary>
    /// Fills related person details and updates the display.
    /// </summary>
    public void FillRelated()
    {
        var relatedPerson = patientDetails.relatedPerson;

        // Check if there are more related person details to display and if the required data is available.
        if (iRelated < relatedPerson.displayNameRelated.Count && !string.IsNullOrEmpty(relatedPerson.firstName))
        {
            relatedPerson.displayRoleRelated[iRelated].text = relatedPerson.role;
            relatedPerson.displayNameRelated[iRelated].text = relatedPerson.firstName + " " + relatedPerson.middleName + " " + relatedPerson.lastName;
            relatedPerson.displayGenderRelated[iRelated].text = relatedPerson.gender;
            relatedPerson.displayRelationRelated[iRelated].text = relatedPerson.relation;
            iRelated++;
        }
    }

    int iInsurance = 0;

    /// <summary>
    /// Fills patient insurance details and updates the display.
    /// </summary>
    public void FillPatientInsurance()
    {
        // Perform any necessary data preparation before filling insurance details.
        PatientInsurance_ThirdPageData();

        var insurance = patientDetails.patientInsurance.insurance;

        // Check if there are more insurance details to display.
        if (iInsurance < insurance.displayHealthPlansInsurance.Count)
        {
            insurance.displaySeqInsurance[iInsurance].text = "000" + (iInsurance + 1);
            insurance.displayHealthPlansInsurance[iInsurance].text = insurance.healthPlans;
            insurance.displayPayerInsurance[iInsurance].text = insurance.payer;
            insurance.displayFinancialClass[iInsurance].text = insurance.financialClass;
            insurance.displaySubscriberInsurance[iInsurance].text = insurance.subscriberMember;
            insurance.displayMemberInsurance[iInsurance].text = "";
            insurance.displayGroupNumberInsurance[iInsurance].text = insurance.groupNumber;
            insurance.displayStartDateInsurance[iInsurance].text = insurance.startDate;
            insurance.displayEndDateInsurance[iInsurance].text = insurance.endDate;
            iInsurance++;
        }
    }

    /// <summary>
    /// Fills information based on the specified role (guarantor, related, or subscriber).
    /// </summary>
    /// <param name="name">The role name (guarantor, related, subscriber).</param>
    public void Self(string name)
    {
        var currentRef = DataRef.instance.currentPersonDetails.GeneralDetails;

        if (name == "guarantor")
        {
            foreach (var item in FindObjectsOfType<CustomInputField>())
            {
                item.AnimateIn();
            }

            var guarantorInfo = DataRef.instance.currentPersonDetails.guarantor;

            guarantorInfo.firstName.text = currentRef.firstName.text;
            guarantorInfo.lastName.text = currentRef.lastName.text;
            guarantorInfo.middleName.text = currentRef.middleName.text;
            guarantorInfo.gender.selectedText.text = currentRef.gender.selectedText.text;
            guarantorInfo.addressLine1.text = currentRef.addressLine1.text;
            guarantorInfo.addressLine2.text = currentRef.addressLine2.text;
            guarantorInfo.zipCode.text = currentRef.zipCode.text;
            guarantorInfo.city.selectedText.text = currentRef.city.selectedText.text;
            guarantorInfo.state.selectedText.text = currentRef.state.selectedText.text;
            guarantorInfo.county.selectedText.text = currentRef.county.selectedText.text;
            guarantorInfo.country.selectedText.text = currentRef.country.selectedText.text;
        }

        if (name == "related")
        {
            foreach (var item in FindObjectsOfType<CustomInputField>())
            {
                item.AnimateIn();
            }

            var relatedInfo = DataRef.instance.currentPersonDetails.relatedPerson;

            relatedInfo.firstName.text = currentRef.firstName.text;
            relatedInfo.lastName.text = currentRef.lastName.text;
            relatedInfo.middleName.text = currentRef.middleName.text;
            relatedInfo.gender.selectedText.text = currentRef.gender.selectedText.text;
            relatedInfo.addressLine1.text = currentRef.addressLine1.text;
            relatedInfo.addressLine2.text = currentRef.addressLine2.text;
            relatedInfo.zipCode.text = currentRef.zipCode.text;
            relatedInfo.city.selectedText.text = currentRef.city.selectedText.text;
            relatedInfo.state.selectedText.text = currentRef.state.selectedText.text;
            relatedInfo.county.selectedText.text = currentRef.county.selectedText.text;
            relatedInfo.country.selectedText.text = currentRef.country.selectedText.text;
        }

        if (name == "subscriber")
        {
            foreach (var item in FindObjectsOfType<CustomInputField>())
            {
                item.AnimateIn();
            }

            var insuranceProfile = DataRef.instance.currentPersonDetails.patientInsurance.subscriber;

            insuranceProfile.firstName.text = currentRef.firstName.text;
            insuranceProfile.lastName.text = currentRef.lastName.text;
            insuranceProfile.middleName.text = currentRef.middleName.text;
        }
    }

    public void General_FirstPageData()
    {
        #region Self
        var currentRef = DataRef.instance.currentPersonDetails.GeneralDetails;
        var current = patientDetails.GeneralDetails;

        current.facility = currentRef.facility.selectedText.text;
        current.SSN = currentRef.SSN.text;
        current._SSN = currentRef.if_SSN.selectedText.text;
        current.MRN = currentRef.MRN.text;
        current.firstName = currentRef.firstName.text;
        current.lastName = currentRef.lastName.text;
        current.middleName = currentRef.middleName.text;
        current.gender = currentRef.gender.selectedText.text;
        current.preferredLanguage = currentRef.preferredLanguage.selectedText.text;
        current.maritalStatus = currentRef.maritalStatus.selectedText.text;
        current.addressLine1 = currentRef.addressLine1.text;
        current.addressLine2 = currentRef.addressLine2.text;
        current.zipCode = currentRef.zipCode.text;
        current.city = currentRef.city.selectedText.text;
        current.state = currentRef.state.selectedText.text;
        current.county = currentRef.county.selectedText.text;
        current.country = currentRef.country.selectedText.text;

        facility.selectedText.text = current.facility;
        SSN.text = current.SSN;
        if_SSN.selectedText.text = current._SSN;
        MRN.text = current.MRN;
        firstName.text = current.firstName;
        lastName.text = current.lastName;
        middleName.text = current.middleName;
        gender.selectedText.text = current.gender;
        preferredLanguage.selectedText.text = current.preferredLanguage;
        maritalStatus.selectedText.text = current.maritalStatus;
        addressLine1.text = current.addressLine1;
        addressLine2.text = current.addressLine2;
        zipCode.text = current.zipCode;
        city.selectedText.text = current.city;
        state.selectedText.text = current.state;
        county.selectedText.text = current.county;
        country.selectedText.text = current.country;
        #endregion
    }

    public void Guarantor_SecondPageData()
    {
        #region Guarantor
        var currentRef_Guarantor = DataRef.instance.currentPersonDetails.guarantor;
        var guarantor = patientDetails.guarantor;

        guarantor.startDate = currentRef_Guarantor.startDate.text;
        guarantor.endDate = currentRef_Guarantor.endDate.selectedText.text;
        guarantor.relationship = currentRef_Guarantor.relationship.selectedText.text;
        guarantor.firstName = currentRef_Guarantor.firstName.text;
        guarantor.lastName = currentRef_Guarantor.lastName.text;
        guarantor.middleName = currentRef_Guarantor.middleName.text;
        guarantor.gender = currentRef_Guarantor.gender.selectedText.text;
        guarantor.dateOfBirth = currentRef_Guarantor.dateOfBirth.selectedText.text;
        guarantor.mobilePhone = currentRef_Guarantor.mobilePhone.text;
        guarantor.addressLine1 = currentRef_Guarantor.addressLine1.text;
        guarantor.addressLine2 = currentRef_Guarantor.addressLine2.text;
        guarantor.zipCode = currentRef_Guarantor.zipCode.text;
        guarantor.city = currentRef_Guarantor.city.selectedText.text;
        guarantor.state = currentRef_Guarantor.state.selectedText.text;
        guarantor.county = currentRef_Guarantor.county.selectedText.text;
        guarantor.country = currentRef_Guarantor.country.selectedText.text;
        guarantor.employer = currentRef_Guarantor.employer.selectedText.text;
        #endregion
    }

    public void RelatedPerson_SecondPageData()
    {
        #region Related Person
        var currentRef_relatedPerson = DataRef.instance.currentPersonDetails.relatedPerson;
        var relatedPerson = patientDetails.relatedPerson;

        relatedPerson.role = currentRef_relatedPerson.role.selectedText.text;
        relatedPerson.relation = currentRef_relatedPerson.relation.selectedText.text;
        relatedPerson.firstName = currentRef_relatedPerson.firstName.text;
        relatedPerson.lastName = currentRef_relatedPerson.lastName.text;
        relatedPerson.middleName = currentRef_relatedPerson.middleName.text;
        relatedPerson.gender = currentRef_relatedPerson.gender.selectedText.text;
        relatedPerson.dateOfBirth = currentRef_relatedPerson.dateOfBirth.selectedText.text;
        relatedPerson.addressLine1 = currentRef_relatedPerson.addressLine1.text;
        relatedPerson.addressLine2 = currentRef_relatedPerson.addressLine2.text;
        relatedPerson.zipCode = currentRef_relatedPerson.zipCode.text;
        relatedPerson.city = currentRef_relatedPerson.city.selectedText.text;
        relatedPerson.state = currentRef_relatedPerson.state.selectedText.text;
        relatedPerson.county = currentRef_relatedPerson.county.selectedText.text;
        relatedPerson.country = currentRef_relatedPerson.country.selectedText.text;
        relatedPerson.employer = currentRef_relatedPerson.employer.selectedText.text;
        #endregion
    }

    public void PatientInsurance_ThirdPageData()
    {
        #region Subscriber
        var currentRef_Profile = DataRef.instance.currentPersonDetails.patientInsurance.subscriber;
        var subscriber = patientDetails.patientInsurance.subscriber;

        subscriber.relation = currentRef_Profile.relation.selectedText.text;
        subscriber.firstName = currentRef_Profile.firstName.text;
        subscriber.lastName = currentRef_Profile.lastName.text;
        subscriber.middleName = currentRef_Profile.middleName.text;
        subscriber.employer = currentRef_Profile.employer.selectedText.text;
        #endregion

        #region Insurance
        var currentRef_Auth = DataRef.instance.currentPersonDetails.patientInsurance.insurance;
        var insurance = patientDetails.patientInsurance.insurance;

        insurance.healthPlans = currentRef_Auth.healthPlans.selectedText.text;
        insurance.payer = null; //currentRef_Auth.payer.selectedText.text;
        insurance.financialClass = currentRef_Auth.financialClass.selectedText.text;
        insurance.addressLine1 = currentRef_Auth.addressLine1.text;
        insurance.addressLine2 = currentRef_Auth.addressLine2.text;
        insurance.zipCode = currentRef_Auth.zipCode.text;
        insurance.city = currentRef_Auth.city.selectedText.text;
        insurance.state = currentRef_Auth.state.selectedText.text;
        insurance.county = currentRef_Auth.county.selectedText.text;
        insurance.country = currentRef_Auth.country.selectedText.text;
        insurance.startDate = currentRef_Auth.startDate.text;
        insurance.endDate = currentRef_Auth.endDate.selectedText.text;
        insurance.subscriberMember = currentRef_Auth.subscriberMember.text;
        insurance.groupNumber = currentRef_Auth.groupNumber.text;
        #endregion
    }

    public void Save_ThirdPageData()
    {
        #region ToJSON
        string fileName = Application.dataPath + "/ReceptionData.json";

        if (File.Exists(fileName))
        {
            details = JsonUtility.FromJson<CustomDetails>(File.ReadAllText(fileName));
        }

        else
        {
            Debug.Log("Created");
        }

        details.PersonDetailsList.Add(patientDetails);
        string json = JsonUtility.ToJson(details, true);

        File.WriteAllText(fileName, json);
        #endregion
    }

    public void OnSave()
    {
        string fileName = Application.dataPath + "/ReceptionData.json";

        if (File.Exists(fileName))
        {
            details = JsonUtility.FromJson<CustomDetails>(File.ReadAllText(fileName));
        }

        else
        {
            Debug.Log("Created");
        }

        details.PersonDetailsList.Add(patientDetails);
        string json = JsonUtility.ToJson(details, true);

        File.WriteAllText(fileName, json);
    }

    public void onFetch()
    {
        details = JsonUtility.FromJson<CustomDetails>(File.ReadAllText(Application.dataPath + "/ReceptionData.json"));
    }
}
