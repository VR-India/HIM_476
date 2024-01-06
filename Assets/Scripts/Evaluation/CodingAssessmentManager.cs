using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Validates coding based on the selected mode (Practice or Training).
/// </summary>
public class CodingAssessmentManager : MonoBehaviour
{
    [SerializeField] private ActivePatientData receiveActivePatient;
    [SerializeField] private AssessmentSO AssessmentSO;
    [SerializeField] private Button continueButton;
    [SerializeField] private CodeDisplayManager addedCodes;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private RectTransform resultPanel;
    [SerializeField] private RectTransform FinalNumber;
    [SerializeField] private TMP_Text[] textFields;

    private string[] currentCode;
    private int codeCount;
    private int correct = 0;
    private string displayResult;

    // Start is called before the first frame update
    private void Start()
    {
        Initialize();

        continueButton.onClick.AddListener(delegate { OnButtonPressedValidate(receiveActivePatient.mode); });
    }

    /// <summary>
    /// Initializes the script by fetching the expected coding sequence.
    /// </summary>
    private void Initialize()
    {
        if (AssessmentSO == null)
            return;

        // Find the patient with the current patient name.
        var patient = AssessmentSO.patient.Find(patient => patient.name == receiveActivePatient.currentPatientName);

        // If the patient is found, set up code count.
        if (patient != null)
        {
            currentCode = patient.code;
            codeCount = currentCode.Length;
            return;
        }
    }

    /// <summary>
    /// Handles the validation logic based on the selected mode.
    /// </summary>
    /// <param name="mode">The selected mode (Practice or Training).</param>
    private void OnButtonPressedValidate(Mode mode)
    {
        switch (mode)
        {
            case Mode.Practice:
                PracticeCoding();
                break;

            case Mode.Training:
                TrainingCoding();
                TrainingReceptionInsuranceCheck();
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Checks the correctness of the entered codes for practice mode.
    /// </summary>
    private void CheckingCodes()
    {
        correct = 0;

        if (codeCount == addedCodes.codeGO.Count)
        {
            for (int i = 0; i < codeCount; i++)
            {
                if (currentCode[i] == addedCodes.codeGO[i].GetComponentInChildren<TMP_Text>().text)
                    correct++;
            }
        }
    }

    /// <summary>
    /// Handles the validation logic for practice mode.
    /// </summary>
    private void PracticeCoding()
    {
        CheckingCodes();

        if (codeCount == correct)
        {
            panels[0].SetActive(false);
            panels[1].SetActive(true);
        }

        else
        {
            displayResult = codeCount != addedCodes.codeGO.Count ? "Codes count incorrect" : "Codes Mismatch";

            resultPanel.gameObject.SetActive(true);
            resultPanel.GetComponentInChildren<TMP_Text>().text = displayResult;
        }
    }

    /// <summary>
    /// Handles the validation logic for training mode.
    /// </summary>
    private void TrainingCoding()
    {
        CheckingCodes();

        float score = codeCount == 0 ? 0 : ((float)correct / codeCount) * 100;

        displayResult = codeCount != addedCodes.codeGO.Count ? "Codes count incorrect" : $"Coding Accuracy : {score}%";

        textFields[3].text = displayResult;

        panels[0].SetActive(false);
        panels[1].SetActive(true);
    }

    /// <summary>
    /// Checks the correctness of the reception insurance details for training mode.
    /// </summary>
    private void TrainingReceptionInsuranceCheck()
    {
        if (receiveActivePatient.insuranceDDCheck)
            textFields[4].text = "Correct Reception Insurance Detail filled";
        else
            textFields[4].text = "Wrong Reception Insurance Detail filled";
    }

    /// <summary>
    /// Generates a random number and sets up display elements based on the selected mode.
    /// </summary>
    public void generateNumber()
    {
        FinalNumber.GetComponentInChildren<TMP_Text>().text = Random.Range(100000, 999999).ToString();

        if (receiveActivePatient.mode == Mode.Practice)
        {
            textFields[0].gameObject.SetActive(true);
            textFields[1].gameObject.SetActive(true);
        }
        else if (receiveActivePatient.mode == Mode.Training)
        {
            textFields[2].gameObject.SetActive(true);
            textFields[3].gameObject.SetActive(true);
        }
    }
}
