using Michsky.MUIP;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Singleton manager responsible for animating various interactions with the patient
/// </summary>
public class PatientInteractionAnimator : MonoBehaviour
{
    public static PatientInteractionAnimator instance;

    public Sounds sounds;
    public AudioSource audioSource;
    public GameObject patient;
    public GameObject cards, handSphere, scannerGhost;
    public GameObject form, ID, wait, pen;

    public static bool abc;

    public Sounds boolRef;
    int patientIndex;

    public InteractableObjectHandler collAnim;

    [SerializeField]
    private ActivePatientData currentMode;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        patientIndex = PlayerPrefs.GetInt("patient");
    }

    /// <summary>
    /// Sets the position based on the current sphere collider's name and attaches the pen to the wrist.
    /// </summary>
    public void setPosition()
    {
        collAnim = FindObjectOfType<InteractableObjectHandler>();

        pen.transform.parent = GameObject.FindGameObjectWithTag("Wrist").transform;

        switch (collAnim.name)
        {
            case "model1_Sphere":
                SetModel1_Transform();
                break;

            case "model2_Sphere":
                SetModel2_Transform();
                break;

            case "model3_Sphere":
                SetModel3_Transform();
                break;
        }
    }

    void SetModel1_Transform()
    {
        patient.transform.position = new Vector3(-34.011f, 0, -13.212f);
        patient.transform.eulerAngles = new Vector3(0, 456.444f, 0);

        cards.transform.localPosition = new Vector3(0.306699991f, -0.105099998f, 0.0307f);
        cards.transform.localEulerAngles = new Vector3(70.4637985f, 270.180664f, 276.008972f);

        pen.transform.localPosition = new Vector3(-0.124899998f, 0.0379999988f, -0.0313000008f);
        pen.transform.localEulerAngles = new Vector3(348.443695f, 309.023071f, 179.78447f);
    }

    void SetModel2_Transform()
    {
        cards.transform.localPosition = new Vector3(-0.0057f, -0.0229f, -0.036f);
        cards.transform.localEulerAngles = new Vector3(8.626f, 260.123f, -106.012f);

        pen.transform.localPosition = new Vector3(-0.0555999987f, 0.0935999975f, 0.0183000006f);
        pen.transform.localEulerAngles = new Vector3(15.5909128f, 268.951782f, 14.6230659f);
    }

    void SetModel3_Transform()
    {
        cards.transform.localPosition = new Vector3(-0.0057f, -0.0229f, -0.036f);
        cards.transform.localEulerAngles = new Vector3(8.626f, 260.123f, -106.012f);

        pen.transform.localPosition = new Vector3(-0.0555999987f, 0.0935999975f, 0.0183000006f);
        pen.transform.localEulerAngles = new Vector3(15.5909128f, 268.951782f, 14.6230659f);
    }

    /// <summary>
    /// Initiates the telling problem animation after a delay.
    /// </summary>
    public void tellProblem()
    {
        Invoke(nameof(tellProblemDelay), sounds.clips[1].time);
    }

    /// <summary>
    /// Delays the telling problem animation to synchronize with the audio clip.
    /// </summary>
    void tellProblemDelay()
    {
        patient.GetComponent<Animator>().SetBool("TellProblem", true);
        audioSource.PlayOneShot(PatientResourceHandler.illnessClip);
        form.GetComponent<ButtonManager>().isInteractable = true;
        form.GetComponent<Button>().interactable = true;
    }

    /// <summary>
    /// Initiates the take clipboard animation after a delay.
    /// </summary>
    public void takeClipboard()
    {
        Invoke(nameof(takeClipboardDelay), sounds.clips[0].time);
    }

    /// <summary>
    /// Delays the take clipboard animation to synchronize with the audio clip.
    /// </summary>
    void takeClipboardDelay()
    {
        setPosition();
        patient.GetComponent<Animator>().SetBool("TakeClipboard", true);
        handSphere.SetActive(true);
    }

    /// <summary>
    /// Initiates the taken clipboard animation after a delay.
    /// </summary>
    public void takenClipboard()
    {
        setPosition();
        patient.GetComponent<Animator>().SetBool("Taken", true);
        pen.SetActive(true);
    }

    /// <summary>
    /// Initiates the give back animation.
    /// </summary>
    public void giveBack()
    {
        setPosition();
        patient.GetComponent<Animator>().SetBool("GiveBack", true);
    }

    /// <summary>
    /// Initiates the given clipboard animation after a delay.
    /// </summary>
    public void givenClipboard()
    {
        setPosition();
        patient.GetComponent<Animator>().SetBool("GivenClipboard", true);
        ID.GetComponent<ButtonManager>().isInteractable = true;
        ID.GetComponent<Button>().interactable = true;
        pen.SetActive(false);
    }

    /// <summary>
    /// Initiates the give cards animation after a delay.
    /// </summary>
    public void giveCards()
    {
        setPosition();
        Invoke(nameof(givenCardsDelay), sounds.clips[0].time);
    }

    /// <summary>
    /// Delays the give cards animation to synchronize with the audio clip.
    /// </summary>
    void givenCardsDelay()
    {
        cards.SetActive(true);
        patient.GetComponent<Animator>().Play("give cards");
    }

    /// <summary>
    /// Initiates the given cards animation.
    /// </summary>
    public void givenCards()
    {
        setPosition();
        patient.GetComponent<Animator>().SetBool("GivenCards", true);
        wait.GetComponent<ButtonManager>().isInteractable = true;
        wait.GetComponent<Button>().interactable = true;
        if (currentMode.mode == Mode.Practice)
        {
            scannerGhost.SetActive(true);
            scannerGhost.GetComponent<Animator>().Play("ID scanner");
        }
    }

    /// <summary>
    /// Initiates the check-in walk sequence.
    /// </summary>
    public void checkInWalk()
    {
        Invoke(nameof(ciwDelay), 3f);
    }

    /// <summary>
    /// Delays the check-in walk animation and initiates the check-in talk sequence.
    /// </summary>
    void ciwDelay()
    {
        patient.GetComponent<Animator>().Play("checkIn walk");
        Invoke(nameof(checkInTalk), 4.1f);
    }

    /// <summary>
    /// Initiates the check-in talk animation and plays the associated audio clip.
    /// </summary>
    public void checkInTalk()
    {
        patient.GetComponent<Animator>().Play("checkIn talk");
        audioSource.PlayOneShot(PatientResourceHandler.checkInAppClip);
    }

    /// <summary>
    /// Initiates the check-in ID sequence after a delay.
    /// </summary>
    public void checkInID()
    {
        Invoke(nameof(cidDelay), 3f);
    }

    /// <summary>
    /// Delays the check-in ID animation and sets the checkGiven property in the handSphere component.
    /// </summary>
    public void cidDelay()
    {
        setPosition();
        cards.SetActive(true);
        patient.GetComponent<Animator>().Play("CheckIn ID");
        handSphere.GetComponent<InteractableObjectHandler>().checkGiven = false;
    }
}