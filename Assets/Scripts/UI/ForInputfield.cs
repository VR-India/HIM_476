using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForInputfield : MonoBehaviour
{
    public TMP_Text ip;

    private void Awake()
    {
        ip=GetComponentInChildren<TMP_Text>();
    }
    private void Start()
    {
       // GetComponent<TMP_InputField>().OnSelect(changeOpacity());
    }
    public void changeOpacity()
    {
        ip.enabled = false;
    }
}
