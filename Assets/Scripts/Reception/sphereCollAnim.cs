using BNG;
using System.Collections.Generic;
using UnityEngine;

public class sphereCollAnim : MonoBehaviour
{
    public GameObject clipBoard, emptyPage, fillPage, DL, MC;
    public bool filled = false, given = false, checkGiven = true;
    int patientIndex;
    private void OnTriggerStay(Collider other)
    {
        patientIndex = PlayerPrefs.GetInt("patient");
        if (other.CompareTag("Clipboard") && clipBoard.GetComponent<Grabbable>().BeingHeld == false && !filled)
        {
            clipBoard.GetComponent<Grabbable>().enabled = false;
            animateManager.instance.takenClipboard();
            clipBoard.transform.SetParent(this.transform.parent);

            switch(this.gameObject.name)
            {
                case "model1_Sphere":
                    
                    clipBoard.transform.localPosition = new Vector3(0.247500002f, 0.0458000004f, 0.0261000004f);
                    clipBoard.transform.localEulerAngles = new Vector3(272.035095f, 282.656311f, 261.20163f);
                    break;

                case "model2_Sphere":
                    clipBoard.transform.localPosition = new Vector3(0.0444f, 0.236f, 0.0445f);
                    clipBoard.transform.localEulerAngles = new Vector3(-17.836f, -85.891f, 263.243f);
                    break;

                case "model3_Sphere":
                    clipBoard.transform.localPosition = new Vector3(0.0444f, 0.236f, 0.0445f);
                    clipBoard.transform.localEulerAngles = new Vector3(-17.836f, -85.891f, 263.243f);
                    break;
            }

            Invoke(nameof(FillingForm), 2f);
        }
        if(other.CompareTag("Cards") && other.GetComponent<Grabbable>().BeingHeld == true && !given)
        {
            other.transform.SetParent(null);
            animateManager.instance.givenCards();
            given = true;
        }
        if (other.CompareTag("Cards") && other.GetComponent<Grabbable>().BeingHeld == true && !checkGiven)
        {
            other.transform.SetParent(null);
            animateManager.instance.setPosition();
            animateManager.instance.patient.GetComponent<Animator>().Play("CheckIn ID given");
            DL.transform.SetParent(null);
            DL.transform.position = new Vector3(-33.0419998f, 0.732200027f, -13.307f);
            DL.transform.localEulerAngles = new Vector3(0f, 0.146f, 359.503998f);
            DL.SetActive(true);
            MC.transform.SetParent(null);
            MC.transform.position = new Vector3(-33.0419998f, 0.732200027f, -13.207f);
            MC.transform.localEulerAngles = new Vector3(0f, 0.146f, 359.503998f);
            MC.SetActive(true);
            checkGiven = true;
        }
        if (filled && clipBoard.GetComponent<Grabbable>().BeingHeld == true)
            animateManager.instance.givenClipboard();
    }
    void FillingForm()
    {
        emptyPage.SetActive(false);
        fillPage.SetActive(true);
        clipBoard.GetComponent<Grabbable>().enabled = true;
        //animateManager.instance.givenClipboard();
        //GetComponent<SphereCollider>().enabled = false;
        filled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cards") && other.GetComponent<Grabbable>().BeingHeld == true)
        {
            other.gameObject.SetActive(false);
            DL.SetActive(true);
            MC.SetActive(true);
        }
        /*
        if(other.CompareTag("Cards") && other.GetComponent<Grabbable>().BeingHeld == false)
        {
            instructionScript.instance.id();
            Debug.Log("exit if working");
        }*/
    }
}
