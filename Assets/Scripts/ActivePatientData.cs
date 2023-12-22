using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mode { Practice, Training }

[CreateAssetMenu(fileName = "PatientDataTransfer")]
public class ActivePatientData : ScriptableObject
{
    public int currentPatinetIndex;
    public string currentPatientName;

    public Mode mode;
}
