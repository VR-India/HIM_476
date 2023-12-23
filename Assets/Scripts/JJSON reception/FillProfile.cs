using myData;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillProfile : MonoBehaviour
{
    public TMP_Text[] text;
    public Data data;

    // Start is called before the first frame update
    void OnEnable()
    {
        var general = data.patientDetails.GeneralDetails;
        var currentRef_Auth = data.patientDetails.patientInsurance.insurance;

        text[0].text = Random.Range(1000, 9999).ToString();
        text[1].text = currentRef_Auth.healthPlans;
        text[2].text = null; //currentRef_Auth.payer.selectedText.text;
        text[3].text = currentRef_Auth.financialClass;
        text[4].text = general.lastName + ", " + general.firstName;
        text[5].text = currentRef_Auth.groupNumber;
        text[6].text = currentRef_Auth.endDate;
    }
}
