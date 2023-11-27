using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagnosisManager : MonoBehaviour
{
    public GameObject Reason;
    public GameObject DiagnosisPanel;
    public GameObject Summary;

    public void ContinueButton()
    {
        
        Summary.SetActive(true);
        DiagnosisPanel.SetActive(false);

    }

    public void Back()
    {
        
        Summary.SetActive(true);
        DiagnosisPanel.SetActive(false);
    }
}
