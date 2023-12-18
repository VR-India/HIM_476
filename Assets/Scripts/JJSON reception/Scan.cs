using BNG;
using Michsky.MUIP;
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

        #region Agnijeet Dawde
        if ((SLOT1 == "AGNIJEET_DL" || SLOT1 == "AGNIJEET_HC") &&
            (SLOT2 == "AGNIJEET_HC" || SLOT2 == "AGNIJEET_DL"))
        {
            // Personal
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Agnijeet";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Dawde";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Male";

            // Address
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "347 ";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Hall Street";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "71232";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "Delhi";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            // Insurance ( Blue Cross )
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "5525 Reitz Ave";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Baton Rogue, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "01 /01 /2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "BCS74182963";
        }
        #endregion

        #region Anne Doe
        if ((SLOT1 == "ANNE_DL" || SLOT1 == "ANNE_HC") &&
            (SLOT2 == "ANNE_HC" || SLOT2 == "ANNE_DL"))
        {
            // Personal
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Anna";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Doe";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Female";

            // Address
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "123";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Main Street";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "71222";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "Ruston";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            // Insurance ( Medicare health )
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "84180";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Baton Rogue, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "01 /01 /2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "2TE5ZE6KJ82";
        }
        #endregion

        #region Davin Brown
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
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";


            //louisiana healthcare connections 
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "4040";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Farmington, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "07/10/2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "6383736743";
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
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";


            //
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
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            //louisiana healthcare connections 
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "4040";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Farmington, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "07/10/2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "6383756743";
        }
        #endregion

        #region Jessica James
        if ((SLOT1 == "JESSICA_DL" || SLOT1 == "JESSICA_HC") &&
            (SLOT2 == "JESSICA_HC" || SLOT2 == "JESSICA_DL"))
        {
            // Personal
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Jessica";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "James";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Female";

            // Address
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "124";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Sidney Street";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "71483";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "Winnfield";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            // United Healthcare
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "425 Ashley Ridge Blvd";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Shreveport, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "07/10/2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "684791235";
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


            // United Healthcare
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "425 Ashley Ridge Blvd";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Shreveport, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "07/10/2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "681235791";
        }
        #endregion

        #region Johnny Blunt
        else if ((SLOT1 == "JOHNNY_DL" || SLOT1 == "JOHNNY_HC") &&
            (SLOT2 == "JOHNNY_HC" || SLOT2 == "JOHNNY_DL"))
        {
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Johnny";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Blunt";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "  ";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Male";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "36293";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Montrose Way";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "44011";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "Ohio";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            // Ameri Health Caritas
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "3155 Gentilly Blvd";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "New Orleans, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "07/10/2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "4712345871024";
        }
        #endregion

        #region June Smith
        else if (SLOT1 == "JUNE_DL" || SLOT2 == "JUNE_DL")
        {
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "June";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Smith";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "  ";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Female";

            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "125";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Main Street";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "71055";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "Maiden";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            // Self Pay
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "NA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "NA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "NA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "NA";
        }
        #endregion

        #region Karthika Sampedu
        if ((SLOT1 == "KARTHIKA_DL" || SLOT1 == "KARTHIKA_HC") &&
            (SLOT2 == "KARTHIKA_HC" || SLOT2 == "KARTHIKA_DL"))
        {
            // Personal
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Karthika";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Sampedu";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Female";

            // Address
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "452";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "71350";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "Marksville";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            // Insurance ( Medicare health )
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "84180";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Baton Rogue, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "01 /01 /2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "2TE5FE6RS15";
        }
        #endregion

        #region Mard Doe
        if ((SLOT1 == "MARK_DL" || SLOT1 == "MARK_HC") &&
            (SLOT2 == "MARK_HC" || SLOT2 == "MARK_DL"))
        {
            // Personal
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Mark";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Doe";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Male";

            // Address
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "Smith Street";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "71241";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "Formerville";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            // Insurance ( All Saver )
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "19032";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Lamar Blvd, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "01 /01 /2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "C074781524";
        }
        #endregion

        #region Peter Ward
        if ((SLOT1 == "PETER_DL" || SLOT1 == "PETER_HC") &&
            (SLOT2 == "PETER_HC" || SLOT2 == "PETER_DL"))
        {
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Peter";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Ward";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Male";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "221 B ";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Beaker Street";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "53090";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "New York";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            // Aetna 
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "2400,Suite 200";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Kenner, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "01 /01 /2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "784214265";
        }
        #endregion

        #region Savanna Smith
        if ((SLOT1 == "SAVANNA_DL" || SLOT1 == "SAVANNA_HC") &&
            (SLOT2 == "SAVANNA_HC" || SLOT2 == "SAVANNA_DL"))
        {
            // Personal
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Savanna";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Smith";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Female";

            // Address
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "1138";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "70601";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "Lake Charles";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            // Insurance ( )
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "84180";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Baton Rogue, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "01 /01 /2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "2TE5FE6RS15";
        }
        #endregion

        #region Srinivas Reddy
        if ((SLOT1 == "SRINIVAS_DL" || SLOT1 == "SRINIVAS_HC") &&
            (SLOT2 == "SRINIVAS_HC" || SLOT2 == "SRINIVAS_DL"))
        {
            // Personal
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Srinivas";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Reddy";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Male";

            // Address
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "9081 ";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Monroe Street";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "71301";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "Delhi";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            // Insurance ( Blue Cross )
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "5525 Reitz Ave";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Baton Rogue, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "01 /01 /2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "BCS852741639";
        }
        #endregion

        #region Stephanie Doe
        if ((SLOT1 == "STEPHANIE_DL" || SLOT1 == "STEPHANIE_HC") &&
            (SLOT2 == "STEPHANIE_HC" || SLOT2 == "STEPHANIE_DL"))
        {
            // Personal
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "Stephanie";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Doe";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Female";

            // Address
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "PO Box 123 ";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Main Street";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "71270";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "Ruston";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            // Insurance ( Blue Cross )
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "5525 Reitz Ave";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Baton Rogue, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "01 /01 /2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "BCS741639852";
        }
        #endregion

        #region William Doe
        if ((SLOT1 == "WILLIAM_DL" || SLOT1 == "WILLIAM_HC") &&
            (SLOT2 == "WILLIAM_HC" || SLOT2 == "WILLIAM_DL"))
        {
            // Personal
            DataRef.instance.currentPersonDetails.GeneralDetails.firstName.text = "William";
            DataRef.instance.currentPersonDetails.GeneralDetails.lastName.text = "Doe";
            DataRef.instance.currentPersonDetails.GeneralDetails.middleName.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.gender.selectedText.text = "Male";

            // Address
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine1.text = "PO Box 123 ";
            DataRef.instance.currentPersonDetails.GeneralDetails.addressLine2.text = "Main Street";
            DataRef.instance.currentPersonDetails.GeneralDetails.zipCode.text = "71270";
            DataRef.instance.currentPersonDetails.GeneralDetails.city.selectedText.text = "Ruston";
            DataRef.instance.currentPersonDetails.GeneralDetails.state.selectedText.text = "LA";
            DataRef.instance.currentPersonDetails.GeneralDetails.country.selectedText.text = "";
            DataRef.instance.currentPersonDetails.GeneralDetails.county.selectedText.text = "";

            // Insurance ( Blue Cross )
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine1.text = "5525 Reitz Ave";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.addressLine2.text = "Baton Rogue, LA";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.startDate.text = "01 /01 /2023";
            DataRef.instance.currentPersonDetails.patientInsurance.insurance.subscriberMember.text = "BCS741639853";
        }
        #endregion

    }
}