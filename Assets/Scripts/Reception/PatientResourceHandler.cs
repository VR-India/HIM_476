using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PatientResourceHandler : MonoBehaviour
{
    [System.Serializable]
    public class _charMats
    {
        public string name;
        public Texture DLMat, HCMat;
        public Sprite clipboard;
        public string appDetails;
        public string patientName;
        public GameObject patientPrefab;
        public GameObject handSphere;
        public GameObject cardsInHand;
        public Sprite DLsprite;
    }

    public Image transPanel;
    public float fadeDelay;

    public Material DL, HC;
    public SpriteRenderer clipboard;
    public Material shirt;
    public List<_charMats> charMats;


    public Sounds boolRef;//load scene bool reference

    public BNG.Button redBTN;

    public static GameObject patient;
    public GameObject btn;
    public GameObject ghost;
    public AudioSource source;

    public Sounds illness, checkInApp;

    public static AudioClip illnessClip, checkInAppClip;

    public TMP_Text appText;
    public TMP_Text checkInTextField;
    public static Sprite checkInScanSprite;

    public GameObject dialoguePanel2;

    public Mode mode;

    public ButtonManager selectButton;

    public ActivePatientData sendPatientData;

    [SerializeField]
    private CustomDropdown dropdown;

    public InteractableObjectHandler collAnim;

    private void Awake()
    {
        // Plays audio if the scene is valid for loading
        if (boolRef.LoadScene_valid)
        {
            source.Play();
        }
    }

    private void Start()
    {
        //Runs in Practice mode. Checks for the selected dropdown to activate respective patient
        selectButton.onClick.AddListener(delegate { AssignPatientResource(dropdown.selectedItemIndex); });
    }

    /// <summary>
    /// Sets the mode for patient data based on the provided integer:
    /// <br>- <b>0</b> : Mode is set to Practice.</br>
    /// <br>- <b>1</b> : Mode is set to Training.</br>
    /// </summary>
    /// <param name="i">Integer representing the desired mode (0 or 1).</param>
    public void SetMode(int i)
    {
        if (i == 0)
            sendPatientData.mode = Mode.Practice;

        else if (i == 1)
            sendPatientData.mode = Mode.Training;
    }

    /// <summary>
    /// Handles the Training mode logic:
    /// <br>- Increments the patient index.</br>
    /// <br>- Sets the patient number in PlayerPrefs.</br>
    /// <br>- Assigns patient resources.</br>
    /// <br>- Activates relevant objects.</br>
    /// </summary>
    public void Training()
    {
        int patientIndex = PlayerPrefs.GetInt("patient");

        // Setting patient number
        if (patientIndex > -1 && patientIndex < charMats.Count - 1)
            PlayerPrefs.SetInt("patient", patientIndex + 1);
        else
            PlayerPrefs.SetInt("patient", 0);

        // Debug.Log(" current patient number from list: " + patientIndex);

        AssignPatientResource(patientIndex);

        if (boolRef.LoadScene_valid)
        {
            patient.SetActive(true);
            btn.GetComponent<Button>().interactable = true;
            btn.GetComponent<ButtonManager>().isInteractable = true;
            ghost.SetActive(false);
            redBTN.enabled = false;
        }
    }

    #region Transition to Check-In
    /// <summary>
    /// Initiates a transition process.
    /// </summary>
    public void transition()
    {
        collAnim = FindObjectOfType<InteractableObjectHandler>();
        StartCoroutine(FadeImage());
        Debug.Log("transition");
    }

    /// <summary>
    /// Coroutine for fading the transition panel and adjusting patient position during a transition:
    /// <br>- Waits for a delay.</br>
    /// <br>- Fades out the transition panel.</br>
    /// <br>- Sets the patient inactive, adjusts its check-in position, and activates the dialogue panel.</br>
    /// <br>- Fades back in the transition panel.</br>
    /// </summary>
    IEnumerator FadeImage()
    {
        yield return new WaitForSeconds(2f);

        // Fades out the transition panel.
        for (float i = 0; i <= 1; i += Time.deltaTime * 1f)
        {
            // set color with i as alpha
            transPanel.color = new Color(0, 0, 0, i);
            yield return null;
        }

        // Sets the patient inactive, adjusts its check-in position, and activates the dialogue panel.
        patient.SetActive(false);
        SetCheckinPosition();
        dialoguePanel2.SetActive(true);
        patient.SetActive(true);

        // Fades back in the transition panel.
        for (float i = 1; i >= 0; i -= Time.deltaTime * 1f)
        {
            // set color with i as alpha
            transPanel.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }

    /// <summary>
    /// Sets the check-in position for the patient based on the collider animation's name.
    /// </summary>
    private void SetCheckinPosition()
    {
        switch (collAnim.name)
        {
            case "model1_Sphere":
                patient.transform.position = new Vector3(-32.6080017f, 0, -12.7550001f);
                patient.transform.eulerAngles = new Vector3(0, 308.770355f, 0);
                break;
            case "model2_Sphere":
                patient.transform.localPosition = new Vector3(-37.3799973f, 0.0255422592f, -12.2589998f);
                patient.transform.eulerAngles = new Vector3(0, 106.290787f, 0);
                break;

            case "model3_Sphere":
                patient.transform.localPosition = new Vector3(-37.3799973f, 0.0255422592f, -12.2589998f);
                patient.transform.eulerAngles = new Vector3(0, 106.290787f, 0);
                break;
        }
    }
    #endregion

    /// <summary>
    /// Handles the process of transitioning to the next patient or reloading the scene based on the scene load validity.
    /// </summary>
    public void NextPatientCheck()
    {
        // Check if the scene load is not valid and trigger the red button press.
        if (!boolRef.LoadScene_valid)
            redBtnPress();

        // If the scene load is valid, reload the scene.
        else if (boolRef.LoadScene_valid)
            SceneManager.LoadScene(0);

        // Reset the scene load validity.
        boolRef.LoadScene_valid = true;
    }

    /// <summary>
    /// Handles the logic when the red button is pressed, including playing audio, enabling interactability, and managing GameObjects.
    /// </summary>
    void redBtnPress()
    {
        // Play the audio.
        source.Play();

        // Enable the patient, button interactability, and ButtonManager interactability.
        patient.SetActive(true);
        btn.GetComponent<Button>().interactable = true;
        btn.GetComponent<ButtonManager>().isInteractable = true;

        // Disable the ghost GameObject and the red button.
        ghost.SetActive(false);
        redBTN.enabled = false;
    }

    /// <summary>
    /// Handles the assignment of patient resources and UI elements based on the selected index.
    /// </summary>
    /// <param name="opt">The index of the selected patient.</param>
    void AssignPatientResource(int opt)
    {
        // Set the current patient index and name.
        sendPatientData.currentPatinetIndex = opt;
        sendPatientData.currentPatientName = charMats[opt].name;

        // Assign patient-related objects and UI elements.
        patient = charMats[opt].patientPrefab;
        PatientInteractionAnimator.instance.patient = patient;
        PatientInteractionAnimator.instance.handSphere = charMats[opt].handSphere;
        PatientInteractionAnimator.instance.cards = charMats[opt].cardsInHand;
        DL.mainTexture = charMats[opt].DLMat;
        HC.mainTexture = charMats[opt].HCMat;
        clipboard.sprite = charMats[opt].clipboard;
        illnessClip = illness.clips[opt].clip;
        checkInAppClip = checkInApp.clips[opt].clip;
        appText.text = charMats[opt].appDetails;
        checkInTextField.text = charMats[opt].patientName;
        checkInScanSprite = charMats[opt].DLsprite;

        // Activate patient and UI elements in Practice mode.
        if (mode == Mode.Practice)
        {
            patient.SetActive(true);
            btn.GetComponent<Button>().interactable = true;
            btn.GetComponent<ButtonManager>().isInteractable = true;
        }
    }
}