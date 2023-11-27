using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace myData
{
    [System.Serializable]
    public class PersonDetails
    {
        public GeneralDetails GeneralDetails = new();
        public Guarantor guarantor = new();
        public RelatedPerson relatedPerson = new();
        public PatientInsurance patientInsurance = new();
    }

    [System.Serializable]
    public class GeneralDetails
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
    }

    [System.Serializable]
    public class Guarantor
    {
        public TMP_InputField startDate;
        public TMP_InputField mobilePhone;
        public TMP_InputField firstName;
        public TMP_InputField middleName;
        public TMP_InputField lastName;
        public TMP_InputField addressLine1;
        public TMP_InputField addressLine2;
        public TMP_InputField zipCode;

        public CustomDropdown endDate;
        public CustomDropdown relationship;
        public CustomDropdown gender;
        public CustomDropdown dateOfBirth;
        public CustomDropdown city;
        public CustomDropdown state;
        public CustomDropdown county;
        public CustomDropdown country;
        public CustomDropdown employer;
    }

    [System.Serializable]
    public class RelatedPerson
    {
        public TMP_InputField firstName;
        public TMP_InputField middleName;
        public TMP_InputField lastName;
        public TMP_InputField addressLine1;
        public TMP_InputField addressLine2;
        public TMP_InputField zipCode;

        public CustomDropdown role;
        public CustomDropdown relation;
        public CustomDropdown gender;
        public CustomDropdown dateOfBirth;
        public CustomDropdown city;
        public CustomDropdown state;
        public CustomDropdown county;
        public CustomDropdown country;
        public CustomDropdown employer;
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
        public TMP_InputField firstName;
        public TMP_InputField middleName;
        public TMP_InputField lastName;

        public CustomDropdown relation;
        public CustomDropdown employer;
    }

    [System.Serializable]
    public class Insurance
    {
        public TMP_InputField addressLine1;
        public TMP_InputField addressLine2;
        public TMP_InputField zipCode;
        public TMP_InputField startDate;
        public TMP_InputField subscriberMember;
        public TMP_InputField groupNumber;

        public CustomDropdown healthPlans;
        public CustomDropdown payer;
        public CustomDropdown city;
        public CustomDropdown state;
        public CustomDropdown county;
        public CustomDropdown country;
        public CustomDropdown endDate;
    }

    [System.Serializable]
    public class InsuranceAuthorities
    {
        public TMP_InputField firstName;
        public TMP_InputField middleName;
        public TMP_InputField lastName;

        public CustomDropdown relation;
    }

    public class DataRef : MonoBehaviour
    {
        public static DataRef instance;

        public PersonDetails currentPersonDetails = new();

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
    }
}
