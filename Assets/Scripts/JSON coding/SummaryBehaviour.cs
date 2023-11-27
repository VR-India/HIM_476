using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummaryBehaviour : MonoBehaviour
{
    public GameObject Reason;
    public GameObject DiagnosisPanel;
    public GameObject Summary;

    public void dxReason()
    {
        
        Reason.SetActive(true);
        Summary.SetActive(false);
    }

    public void Diagnosis123()
    {
        
        DiagnosisPanel.SetActive(true);
        Summary.SetActive(false);
    }
}
