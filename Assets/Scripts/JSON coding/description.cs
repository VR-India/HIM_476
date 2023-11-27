using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class description : MonoBehaviour
{
    public TMP_Text text1;
    public GameObject description1;

    public void xyz()
    {
        if (text1.text != "")
        {
            description1.SetActive(true);
        }
    }
    
}
