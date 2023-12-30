using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class ValidateCoding : MonoBehaviour
{
    [SerializeField]
    private ActivePatientData receiveActivePatient;

    [SerializeField]
    private AssessmentSO AssessmentSO;

    public string[] currentCode;
    public int codeCount;

    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private AddCoding addedCodes;

    [SerializeField]
    private GameObject[] panels;
    [SerializeField]
    private RectTransform resultPanel;

    [SerializeField]
    private RectTransform FinalNumber;
    [SerializeField]
    private TMP_Text[] textFields;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in AssessmentSO.patient)
        {
            if (item.name == receiveActivePatient.currentPatientName)
                currentCode = item.code;
        }

        codeCount = currentCode.Length;
        continueButton.onClick.AddListener(delegate { OnButtonPressedValidate(receiveActivePatient.mode); });
    }

    void OnButtonPressedValidate(Mode mode)
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

    int correct = 0;

    void CheckingCodes()
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

    void PracticeCoding()
    {
        CheckingCodes();

        if (codeCount == correct)
        {
            panels[0].SetActive(false);
            panels[1].SetActive(true);
        }

        else
        {
            if (codeCount != addedCodes.codeGO.Count)
            {
                resultPanel.gameObject.SetActive(true);
                resultPanel.GetComponentInChildren<TMP_Text>().text = "Codes count incorrect";
                Debug.Log("Codes count incorrect");
            }

            else
            {
                resultPanel.gameObject.SetActive(true);
                resultPanel.GetComponentInChildren<TMP_Text>().text = "Codes Mismatch";
            }
        }
    }

    void TrainingCoding()
    {
        CheckingCodes();

        float score = correct / codeCount * 100;

        if (codeCount != addedCodes.codeGO.Count)
            textFields[3].text = "Codes count incorrect";
        else
            textFields[3].text = $"Coding Accuracy : {score}%";

        panels[0].SetActive(false);
        panels[1].SetActive(true);
    }

    void TrainingReceptionInsuranceCheck()
    {
        if (receiveActivePatient.insuranceDDCheck)
            textFields[4].text = "Correct Reception Insurance Detail filled";
        else
            textFields[4].text = "Wrong Reception Insurance Detail filled";
    }

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
