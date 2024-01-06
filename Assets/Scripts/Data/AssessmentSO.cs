using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class representing a patient and their associated coding information.
/// </summary>
[Serializable]
public class Patient
{
    public string name;
    public string[] code;
}

/// <summary>
/// ScriptableObject that holds a list of patients with their associated coding information.
/// </summary>
[CreateAssetMenu(fileName = "Assessment")]
public class AssessmentSO : ScriptableObject
{
    [SerializeField]
    public List<Patient> patient;
}
