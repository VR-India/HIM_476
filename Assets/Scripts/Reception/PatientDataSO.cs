using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterReferences
{
    public string Name;
    public Texture DriverLicenseMaterial;
    public Texture HealthCardMaterial;
    public Sprite ClipboardSprite;
    public string AppointmentDetails;
    public string PatientName;
    public GameObject PatientPrefab;
    public GameObject HandSphere;
    public GameObject CardsInHand;
    public Sprite DriverLicenseSprite;
}

[CreateAssetMenu(fileName ="Data references", menuName = "Scriptable/Data Reference Script", order = 1)]
public class PatientDataSO : ScriptableObject
{
    public List<CharacterReferences> charRefs;
}
