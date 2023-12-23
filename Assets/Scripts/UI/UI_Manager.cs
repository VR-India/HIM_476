using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    private void Start()
    {
        if(instance == null)
            instance = this;
    }
    public panel_fetch[] panels;
    public Data json;
    public AppointmentData appointment;

    public void btnAction(string btnName)
    {
        switch(btnName)
        {
            case "Software Icon":
                turnOn(1);
                break;
            case "LOGIN BUTTON":
                turnOn(2);
                turnOff(1);
                break;
            case "RevenueCycle":
                turnOn(3);
                turnOff(2);
                break;
            case "Search":
                turnOn(4);
                break;
            case "PatientSave":
                turnOff(4);
                json.General_FirstPageData();
                break;
            case "Registrations":
                turnOn(7);
                break;
            case "NEXT button(patient)":
                turnOn(9);
                turnOff(8);
                break;
            case "Button add GUARANTOR":
                turnOn(10);
                break;
            case "Ok(guarentor)":
                turnOff(10);
                json.Guarantor_SecondPageData();
                json.FillGuarantor();
                break;
            case "Button add RELATED PERSON":
                turnOn(11);
                break;
            case "Ok(related)":
                turnOff(11);
                json.RelatedPerson_SecondPageData();
                json.FillRelated();
                break;
            case "NEXT button(Relationship)":
                turnOff(9);
                turnOn(12);
                break;
            case "Button add insurance":
                turnOn(13);
                break;
            case "Subscriber":
                turnOn(14);
                turnOff(15);
                break;
            case "Insurance":
                turnOn(15);
                turnOff(14);
                break;
            case "OK(sub)":
                turnOff(13);
                break;
            case "OK(ins)":
                turnOff(13);
                json.FillPatientInsurance();
                break;
            case "Save(insurance)":
                turnOff(7);
                turnOff(9);
                turnOff(12);
                turnOn(8);
                json.Save_ThirdPageData();
                break;
            case "Appointments":
                turnOn(5);
                break;
            case "Button (6)":
                turnOn(6);
                break;
            case "OK(calender)":
                turnOff(6);
                turnOff(5);
                break;
            case "Button (7)":
                appointment.FillAppointment();
                break;
            default:
                Debug.Log("case not found");
                break;
        }
    }

    void turnOn(int index)
    {
        panels[index].gameObject.SetActive(true);
    }

    void turnOff(int index)
    {
        panels[index].gameObject.SetActive(false);
    }
}