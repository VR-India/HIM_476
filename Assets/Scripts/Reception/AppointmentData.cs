using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AppointmentData : MonoBehaviour
{
    public GameObject[] appointment;

    public CustomDropdown appointmentType;
    public CustomDropdown Location;

    int i = 0;

    public void FillAppointment()
    {
        if(i < appointment.Length)
        {
            TMP_Text[] text = appointment[i].GetComponentsInChildren<TMP_Text>();
            text[0].text = appointmentType.selectedText.text;
            text[1].text = Location.selectedText.text;
            i++;
        }
    }
}
