using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleOnOff : MonoBehaviour
{

    public List<GameObject> Toggles;

    public void ToggleOnOff()
    {

        foreach (GameObject go in Toggles)
        {
            //go.GetComponent<Toggle>().isOn = false;
        }
    }

    public void ToggleOnlyOnce()
    {
        //foreach (GameObject go in Toggles)
        //{
        //    go.GetComponent<Toggle>().isOn = false;
        //    if (go.GetComponent<Toggle>().isOn)
        //    {
        //        go.GetComponent<Toggle>().isOn = true;
        //    }
          
        //}
    }
}
