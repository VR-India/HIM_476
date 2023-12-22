using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Patient
{
    public string name;
    public string[] code;
}

[CreateAssetMenu(fileName = "Assessment")]
public class AssessmentSO : ScriptableObject
{
    [SerializeField]
    public List<Patient> patient;
}
