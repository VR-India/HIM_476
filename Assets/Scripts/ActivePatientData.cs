using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PatientDataTransfer")]
public class ActivePatientData : ScriptableObject
{
    public int currentPatinetIndex;
    public string currentPatientName;
}
