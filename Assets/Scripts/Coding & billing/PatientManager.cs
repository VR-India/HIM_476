using Michsky.MUIP;
using UnityEngine;

public class PatientManager : MonoBehaviour
{
    [SerializeField]
    private CustomDropdown codingDropdown;
    [SerializeField]
    private CustomDropdown billingDropdown;

    [SerializeField]
    private ActivePatientData receivePatientData;

    // Start is called before the first frame update
    void Start()
    {
        codingDropdown.index = receivePatientData.currentPatinetIndex;
        billingDropdown.index = receivePatientData.currentPatinetIndex;
        codingDropdown.selectedItemIndex = receivePatientData.currentPatinetIndex;
        billingDropdown.selectedItemIndex = receivePatientData.currentPatinetIndex;
        codingDropdown.selectedText.text = codingDropdown.items[receivePatientData.currentPatinetIndex].itemName;
        billingDropdown.selectedText.text = billingDropdown.items[receivePatientData.currentPatinetIndex].itemName;
        billingDropdown.selectedImage.sprite = billingDropdown.items[receivePatientData.currentPatinetIndex].itemIcon;
    }
}
