using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class ValidateCoding : MonoBehaviour
{
    [SerializeField]
    private ActivePatientData recieveActivePatient;

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

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in AssessmentSO.patient)
        {
            if (item.name == recieveActivePatient.currentPatientName)
                currentCode = item.code;
        }

        codeCount = currentCode.Length;
        continueButton.onClick.AddListener(delegate { OnButtonPressedValidate(recieveActivePatient.mode); });
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
                break;

            default:
                break;
        }
    }

    void PracticeCoding()
    {
        if (codeCount == addedCodes.codeGO.Count)
        {
            for (int i = 0; i < codeCount; i++)
            {
                if (currentCode[i] != addedCodes.codeGO[i].GetComponentInChildren<TMP_Text>().text)
                {
                    resultPanel.gameObject.SetActive(true);
                    resultPanel.GetComponentInChildren<TMP_Text>().text = "Codes Mismatch";
                    Debug.Log("Codes Mismatch");
                }
                else
                {
                    //Debug.Log("Codes Correct");
                    panels[0].SetActive(false);
                    panels[1].SetActive(true);
                }
            }
        }
        else
        {
            resultPanel.gameObject.SetActive(true);
            resultPanel.GetComponentInChildren<TMP_Text>().text = "Codes count incorrect";
            Debug.Log("Codes count incorrect");
        }
    }

    void TrainingCoding()
    {
        int correct = 0;
        int incorrect = 0;

        if (codeCount == addedCodes.codeGO.Count)
        {
            for (int i = 0; i < codeCount; i++)
            {
                if (currentCode[i] != addedCodes.codeGO[i].GetComponentInChildren<TMP_Text>().text)
                {
                    incorrect++;
                    Debug.Log("Codes Mismatch : " + incorrect);
                }

                else
                {
                    correct++;
                    Debug.Log("Codes Correct : " + correct);
                    panels[0].SetActive(false);
                    panels[1].SetActive(true);
                }
            }

            float score = correct / codeCount * 100;

            Debug.Log("Param : " + score);
        }

        else
            Debug.Log("Codes count incorrect");
    }
}
