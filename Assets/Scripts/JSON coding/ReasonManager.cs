using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReasonManager : MonoBehaviour
{
    public GameObject Reason;
    public GameObject DiagnosisPanel;
    public GameObject Summary;

    public void ContinueButton()
    {
        
        Summary.SetActive(true);
        Reason.SetActive(false);

    }

    public void Back()
    {
        
        Summary.SetActive(true);
        Reason.SetActive(false);
    }

    public void Diagnosis123()
    {
        
        DiagnosisPanel.SetActive(true);
        Reason.SetActive(false);
    }
}
