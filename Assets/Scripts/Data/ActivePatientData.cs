using UnityEngine;

public enum Mode
{
    Practice,
    Training
}

/// <summary>
/// ScriptableObject to store active patient data.
/// </summary>
[CreateAssetMenu(fileName = "PatientDataTransfer")]
public class ActivePatientData : ScriptableObject
{
    public int currentPatinetIndex;
    public string currentPatientName;
    public bool insuranceDDCheck;

    public Mode mode;
}
