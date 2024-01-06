using Michsky.MUIP;
using UnityEngine;
using TMPro;

/// <summary>
/// Manages appointment data and fills appointment details.
/// </summary>
public class AppointmentDetailsUpdater : MonoBehaviour
{
    public GameObject[] appointment;

    public CustomDropdown appointmentType;
    public CustomDropdown Location;

    int currentIndex = 0;

    /// <summary>
    /// Fills appointment details based on the selected appointment type and location.
    /// </summary>
    public void FillAppointment()
    {
        if (currentIndex >= appointment.Length)
            return;

        TMP_Text[] textComponents = appointment[currentIndex].GetComponentsInChildren<TMP_Text>();
        textComponents[0].text = appointmentType.selectedText.text;
        textComponents[1].text = Location.selectedText.text;
        currentIndex++;
    }
}
