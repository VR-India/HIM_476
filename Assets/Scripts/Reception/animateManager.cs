using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animateManager : MonoBehaviour
{
    public static animateManager instance;

    public Sounds sounds;
    public AudioSource audioSource;
    public GameObject patient;
    public GameObject cards, handSphere, scannerGhost;
    public Button form, ID, wait, done;

    public Sounds boolRef;
    int patientIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        patientIndex = PlayerPrefs.GetInt("patient");
    }
    public void setPosition()
    {
        switch (patient.name)
        {
            case "Peter":
                patient.transform.position = new Vector3(-34.011f, 0, -13.212f);
                patient.transform.eulerAngles = new Vector3(0, 456.444f, 0);

                cards.transform.localPosition = new Vector3(0, 0, 0);
                cards.transform.localEulerAngles = new Vector3(0, 0, 0);
                break;

            case "John":
                patient.transform.position = new Vector3(-34.011f, 0, -13.212f);
                patient.transform.eulerAngles = new Vector3(0, 456.444f, 0);

                cards.transform.localPosition = new Vector3(0, 0, 0);
                cards.transform.localEulerAngles = new Vector3(0, 0, 0);
                break;

            case "Davin":
                cards.transform.localPosition = new Vector3(0.0130000003f, 0.00700000022f, 0.00700000022f);
                cards.transform.localEulerAngles = new Vector3(349.084167f, 149.039474f, 263.518372f);
                break;

            case "Emily":
                cards.transform.localPosition = new Vector3(0.0130000003f, 0.00700000022f, 0.00700000022f);
                cards.transform.localEulerAngles = new Vector3(349.084167f, 149.039474f, 263.518372f);
                break;
        }
    }

    public void tellProblem()
    {
        Invoke(nameof(tellProblemDelay), sounds.clips[1].time);
    }

    void tellProblemDelay()
    {
        patient.GetComponent<Animator>().SetBool("TellProblem", true);
        audioSource.PlayOneShot(fadeAndMatChange.illnessClip);
        form.interactable = true;
    }

    public void takeClipboard()
    {
        Invoke(nameof(takeClipboardDelay), sounds.clips[0].time);
    }

    void takeClipboardDelay()
    {
        setPosition();
        patient.GetComponent<Animator>().SetBool("TakeClipboard", true);
        handSphere.SetActive(true);
    }

    public void takenClipboard()
    {
        setPosition();
        patient.GetComponent<Animator>().SetBool("Taken", true);
    }

    public void giveBack()
    {
        setPosition();
        patient.GetComponent<Animator>().SetBool("GiveBack", true);
    }

    public void givenClipboard()
    {
        setPosition();
        patient.GetComponent<Animator>().SetBool("GivenClipboard", true);
        ID.interactable = true;
    }

    public void giveCards()
    {
        setPosition();
        Invoke(nameof(givenCardsDelay), sounds.clips[0].time);
    }

    void givenCardsDelay()
    {
        cards.SetActive(true);
        patient.GetComponent<Animator>().Play("give cards");
    }

    public void givenCards()
    {
        setPosition();
        patient.GetComponent<Animator>().SetBool("GivenCards", true);
        wait.interactable = true;

        scannerGhost.SetActive(true);
        scannerGhost.GetComponent<Animator>().Play("ID scanner");
    }

    public void checkInWalk()
    {
        Invoke(nameof(ciwDelay), 3f);
    }

    void ciwDelay()
    {
        patient.GetComponent<Animator>().Play("checkIn walk");
        Invoke(nameof(checkInTalk), 4.1f);
    }

    public void checkInTalk()
    {
        patient.GetComponent<Animator>().Play("checkIn talk");
        audioSource.PlayOneShot(fadeAndMatChange.checkInAppClip);
    }

    public void checkInID()
    {
        Invoke(nameof(cidDelay), 3f);
    }

    public void cidDelay()
    {
        setPosition();
        cards.SetActive(true);
        patient.GetComponent<Animator>().Play("CheckIn ID");
        handSphere.GetComponent<sphereCollAnim>().checkGiven = false;
    }


}