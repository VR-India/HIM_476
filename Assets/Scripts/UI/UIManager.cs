using UnityEngine;

/// <summary>
/// Manages UI interactions and controls the visibility of various panels based on button actions.
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Data json;
    public AppointmentDetailsUpdater appointmentDetails;

    // Array of panels controlled by the UIManager.
    public PanelButtonFetcher[] panels;

    private void Start()
    {
        // Initializes the singleton instance if it's null.
        if (instance == null)
            instance = this;
    }

    /// <summary>
    /// Handles button actions and toggles panel visibility accordingly.
    /// </summary>
    /// <param name="btnName">The name of the button triggering the action.</param>
    public void btnAction(string btnName)
    {
        switch (btnName)
        {
            case "Software Icon":
                TogglePanel(1);
                break;

            case "LOGIN BUTTON":
                TogglePanel(2);
                TogglePanel(1, false);
                break;

            case "RevenueCycle":
                TogglePanel(3);
                TogglePanel(2, false);
                break;

            case "Search":
                TogglePanel(4);
                break;

            case "PatientSave":
                TogglePanel(4, false);
                json.General_FirstPageData();
                break;

            case "Registrations":
                TogglePanel(7);
                break;

            case "NEXT button(patient)":
                TogglePanel(9);
                TogglePanel(8, false);
                break;

            case "Button add GUARANTOR":
                TogglePanel(10);
                break;

            case "Ok(guarentor)":
                TogglePanel(10, false);
                json.Guarantor_SecondPageData();
                json.FillGuarantor();
                break;

            case "Button add RELATED PERSON":
                TogglePanel(11);
                break;

            case "Ok(related)":
                TogglePanel(11, false);
                json.RelatedPerson_SecondPageData();
                json.FillRelated();
                break;

            case "NEXT button(Relationship)":
                TogglePanel(9, false);
                TogglePanel(12);
                break;

            case "Button add insurance":
                TogglePanel(13);
                break;

            case "Subscriber":
                TogglePanel(14);
                TogglePanel(15, false);
                break;

            case "Insurance":
                TogglePanel(15);
                TogglePanel(14, false);
                break;

            case "OK(sub)":
                TogglePanel(13, false);
                break;

            case "OK(ins)":
                TogglePanel(13, false);
                json.FillPatientInsurance();
                break;

            case "Save(insurance)":
                TogglePanel(7, false);
                TogglePanel(9, false);
                TogglePanel(12, false);
                TogglePanel(8);
                json.Save_ThirdPageData();
                break;

            case "Appointments":
                TogglePanel(5);
                break;

            case "Button (6)":
                TogglePanel(6);
                break;

            case "OK(calender)":
                TogglePanel(6, false);
                TogglePanel(5, false);
                break;

            case "Button (7)":
                appointmentDetails.FillAppointment();
                break;

            default:
                Debug.Log("case not found");
                break;
        }
    }

    /// <summary>
    /// Toggles the visibility of a panel based on its index.
    /// </summary>
    /// <param name="index">The index of the panel.</param>
    /// <param name="active">Whether to set the panel as active or inactive.</param>
    void TogglePanel(int index, bool active = true)
    {
        panels[index].gameObject.SetActive(active);
    }
}