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
                case "Peter_Sphere":
                    clipBoard.transform.localPosition = new Vector3(-0.248999998f, -0.0159000009f, -0.0719000027f);
                    clipBoard.transform.localEulerAngles = new Vector3(5.0625186f, 155.665466f, 340.612061f);
                    break;

                case "John_Sphere":
                    clipBoard.transform.localPosition = new Vector3(-0.248999998f, -0.0159000009f, -0.0719000027f);
                    clipBoard.transform.localEulerAngles = new Vector3(5.0625186f, 155.665466f, 340.612061f);
                    break;

                case "Davin_Sphere":
                    clipBoard.transform.localPosition = new Vector3(-0.075000003f, 0.228300005f, 0.0121999998f);
                    clipBoard.transform.localEulerAngles = new Vector3(351.868958f, 5.08239555f, 100.135933f);
                    break;

                case "Emily_Sphere":
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
        animateManager.instance.giveBack();
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
