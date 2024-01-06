using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForInputfield : MonoBehaviour
{
    public TMP_Text ip;

    private void Awake()
    {
        ip = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        // GetComponent<TMP_InputField>().OnSelect(changeOpacity());
    }

    /// <summary>
    /// Changes the opacity of the associated TMP_Text component by disabling its visibility.
    /// </summary>
    public void changeOpacity()
    {
        ip.enabled = false;
    }
}
