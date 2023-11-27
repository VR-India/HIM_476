using BNG;
using Michsky.UI.ModernUIPack;
using myData;
using UnityEngine;

public class Scan : MonoBehaviour
{
    public SnapZone[] snapZone;
    public string SLOT1, SLOT2;

    private void Update()
    {
        if (snapZone[0].HeldItem != null && snapZone[1].HeldItem != null && animateManager.instance.scannerGhost.active)
        {
            animateManager.instance.scannerGhost.GetComponent<Animator>().Play("scannerBtnPress");
        }
    }
    public void ScanThis()
    {
        animateManager.instance.scannerGhost.SetActive(false);

        Debug.Log("Scanning");
        
        if (snapZone[0].HeldItem == null && snapZone[1].HeldItem == null)
        {
            Debug.Log("data null");
            return;
        }

        SLOT1 = snapZone[0].HeldItem?.GetComponentInChildren<MeshRenderer>().material.mainTexture.name;
        SLOT2 = snapZone[1].HeldItem?.GetComponentInChildren<MeshRenderer>().material.mainTexture.name;
        

        foreach (var item in FindObjectsOfType<CustomInputField>())
        {
            item.AnimateIn();
        }

        #region Peter Santosh Ward
        if ((SLOT1 == "PETER_DL" || SLOT1 == "PETER_HC") &&
            (SLOT2 == "PETER_HC" || SLOT2 == "PETER_DL"))
        {
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Peter";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Ward";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "Santosh";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Male";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "4063 ";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Clifford Street";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "53090";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "619H 3th St";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Bailtong Range, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "01 /01 /2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "65484";
        }
        #endregion

        #region Johnny Blunt
        else if ((SLOT1 == "JOHNNY_DL" || SLOT1 == "JOHNNY_HC") &&
            (SLOT2 == "JOHNNY_HC" || SLOT2 == "JOHNNY_DL"))
        {
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Johney";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Blunt";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "  ";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Male";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "36293";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Montrose Way";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "44011";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "619H 3th St";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Bailtong Range, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "07/10/2018";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "7770000000000000";
        }
        #endregion

        #region John Doe
        else if ((SLOT1 == "JOHN_DL" || SLOT1 == "JOHN_HC") &&
            (SLOT2 == "JOHN_HC" || SLOT2 == "JOHN_DL"))
        {
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "John";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Doe";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "  ";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Male";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "Swetts Pond Rd";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Orrington";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "04474";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "619H 3th St";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Bailtong Range, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "07/10/2018";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "7770000000000000";
        }
        #endregion

        #region David Brown
        else if ((SLOT1 == "DAVIN_DL" || SLOT1 == "DAVIN_HC") &&
            (SLOT2 == "DAVIN_HC" || SLOT2 == "DAVIN_DL"))
        {
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Davin";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Brown";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "  ";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Male";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "59 N ";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Central Ave";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "08081";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "619H 3th St";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Bailtong Range, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "07/10/2018";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "7770000000000000";
        }
        #endregion

        #region Jason Murphy
        else if ((SLOT1 == "JASON_DL" || SLOT1 == "JASON_HC") &&
            (SLOT2 == "JASON_HC" || SLOT2 == "JASON_DL"))
        {
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Jason";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Murphy";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "  ";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Male";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "8277";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Croswell Shore Trl";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "49460";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "619H 3th St";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Bailtong Range, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "07/10/2018";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "7770000000000000";
        }
        #endregion

        #region Emily Blum
        else if ((SLOT1 == "EMILY_DL" || SLOT1 == "EMILY_HC") &&
            (SLOT2 == "EMILY_HC" || SLOT2 == "EMILY_DL"))
        {
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Emily";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Blum";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "  ";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Female";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Croswell West Olive";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "44011";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "619H 3th St";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Bailtong Range, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "07/10/2018";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "7770000000000000";
        }
        #endregion
    }
}