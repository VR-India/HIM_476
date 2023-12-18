using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Michsky.MUIP;
using UnityEngine.UI;

[Serializable]
public class Patients
{
    [JsonProperty("name")]
    public string guarantor;

    [JsonProperty("account")]
    public int account;

    [JsonProperty("encounter")]
    public int encounter;

    [JsonProperty("status")]
    public string status;

    [JsonProperty("insurance pending")]
    public float insurancePending;

    [JsonProperty("patient balance")]
    public float patientBalance;

    [JsonProperty("total balance")]
    public float totalBalance;

    [JsonProperty("begin date")]
    public string beginDate;

    [JsonProperty("end date")]
    public string endDate;

    [JsonProperty("financial class")]
    public string financialClass;

    [JsonProperty("type")]
    public string type;

    [JsonProperty("location")]
    public string location;

    [JsonProperty("physician")]
    public string physician;

    [JsonProperty("health plan")]
    public string healthPlan;

    [JsonProperty("bill Status")]
    public string billStatus;

    [JsonProperty("claims")]
    public string claims;

    [JsonProperty("payments")]
    public float payments;
}

public class BillDetailsJson : MonoBehaviour
{
    [SerializeField]
    private CustomDropdown dropdown;
    [SerializeField]
    private Image claimForm;

    public List<Patients> patientsBillJSON;

    private Patients selectedPatient;

    private TMP_Text[] text;


    // Start is called before the first frame update
    void Start()
    {
        patientsBillJSON = new();

        string json = Resources.Load<TextAsset>("jsonBillData/bill").text;
        patientsBillJSON = JsonConvert.DeserializeObject<List<Patients>>(json);

        text = GetComponentsInChildren<TMP_Text>();
        Prefix();
    }

    private void OnEnable()
    {
        dropdown.onValueChanged.AddListener(delegate { FetchBillDetails(dropdown.selectedText.text, dropdown.selectedImage.sprite); });
    }

    private void Prefix()
    {
        #region Prefix
        text[0].text = "Account: ";
        text[1].text = "Encounter: ";
        text[2].text = "Status: ";
        text[3].text = "Insurance Pending:<br>";
        text[4].text = "Patient Balance:<br>";
        text[5].text = "Total Balance:<br>";
        text[6].text = "Guarantor: ";
        text[7].text = "Begin Date: ";
        text[8].text = "End Date: ";
        text[9].text = "Financial Class: ";
        text[10].text = "Type: ";
        text[11].text = "Location: ";
        text[12].text = "Physician: ";
        text[13].text = "Health Plan<br><br>";
        text[14].text = "Status<br><br>";
        text[15].text = "Claims<br><br>";
        text[16].text = "Total Charges<br><br>";
        text[17].text = "Payments<br><br>";
        text[18].text = "Adjustments<br><br>";
        text[19].text = "Patient Responsibility<br><br>";
        #endregion
    }

    public void FetchBillDetails(string name, Sprite sprite)
    {
        if (patientsBillJSON.Count == 0)
            return;

        Prefix();

        foreach (var item in patientsBillJSON)
        {
            if (item.guarantor == name)
                selectedPatient = item;
        }

        claimForm.sprite = sprite;

        text[0].text += selectedPatient.account;
        text[1].text += selectedPatient.encounter;
        text[2].text += selectedPatient.status;
        text[3].text += ("$ " + selectedPatient.insurancePending);
        text[4].text += ("$ " + selectedPatient.patientBalance);
        text[5].text += ("$ " + selectedPatient.totalBalance);
        text[6].text += selectedPatient.guarantor.ToUpper();
        text[7].text += selectedPatient.beginDate;
        text[8].text += selectedPatient.endDate;
        text[9].text += selectedPatient.financialClass;
        text[10].text += selectedPatient.type.ToUpper();
        text[11].text += selectedPatient.location.ToUpper();
        text[12].text += selectedPatient.physician;
        text[13].text += selectedPatient.healthPlan;
        text[14].text += selectedPatient.billStatus;
        text[15].text += selectedPatient.claims;
        text[16].text += ("$ " + selectedPatient.totalBalance);
        text[17].text += ("$ " + selectedPatient.payments);
        text[18].text += ("$ " + selectedPatient.insurancePending);
        text[19].text += ("$ " + (selectedPatient.totalBalance - selectedPatient.payments - selectedPatient.insurancePending));
    }
}
