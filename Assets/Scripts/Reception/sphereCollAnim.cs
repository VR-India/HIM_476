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
                    clipBoard.transform.localPosition = new Vector3(-0.075000003f, 0.228300005f, 0.0121999998f);
                    clipBoard.transform.localEulerAngles = new Vector3(351.868958f, 5.08239555f, 100.135933f);
                    break;

                case "model3_Sphere":
                    clipBoard.transform.localPosition = new Vector3(-0.075000003f, 0.228300005f, 0.0121999998f);
                    clipBoard.transform.localEulerAngles = new Vector3(351.868958f, 5.08239555f, 100.135933f);
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
            DL.SetActive(true);
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
