using Michsky.MUIP;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages patient-related functionality, including dropdowns for coding and billing, patient data reception, and audio source control.
/// </summary>
public class PatientSelector : MonoBehaviour
{
    // Dropdown for coding selection.
    [SerializeField]
    private CustomDropdown codingDropdown;

    // Dropdown for billing selection.
    [SerializeField]
    private CustomDropdown billingDropdown;

    // Reference to the active patient data component for receiving patient-related information.
    [SerializeField]
    private ActivePatientData receivePatientData;

    // Reference to the audio source component for audio playback.
    [SerializeField]
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Set dropdown indices and selected text based on the current patient index
        codingDropdown.index = receivePatientData.currentPatinetIndex;
        billingDropdown.index = receivePatientData.currentPatinetIndex;
        codingDropdown.selectedItemIndex = receivePatientData.currentPatinetIndex;
        billingDropdown.selectedItemIndex = receivePatientData.currentPatinetIndex;
        codingDropdown.selectedText.text = codingDropdown.items[receivePatientData.currentPatinetIndex].itemName;
        billingDropdown.selectedText.text = billingDropdown.items[receivePatientData.currentPatinetIndex].itemName;
        billingDropdown.selectedImage.sprite = billingDropdown.items[receivePatientData.currentPatinetIndex].itemIcon;

        // Enable or disable the audio source based on the mode
        if (receivePatientData.mode == Mode.Practice)
        {
            audioSource.enabled = true;
        }

        else if (receivePatientData.mode == Mode.Training)
        {
            audioSource.enabled = false;
        }
    }
}