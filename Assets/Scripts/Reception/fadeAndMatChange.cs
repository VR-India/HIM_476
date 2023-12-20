using Michsky.MUIP;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fadeAndMatChange : MonoBehaviour
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

    public enum Mode { Practice, Training }
    public Mode mode;

    public ButtonManager selectButton;

    public ActivePatientData sendPatientData; 

    public void SetMode(int i)
    {
        if (i == 0)
            mode = Mode.Practice;
        else if (i == 1)
            mode = Mode.Training;
    }
    private void Awake()
    {
        //Playing Next Patient audio
        if (boolRef.LoadScene_valid)
        {
            source.Play();
        }
    }
    [SerializeField]
    private CustomDropdown dropdown;
    private void Start()
    {
        if (mode == Mode.Practice)
        {
            selectButton.onClick.AddListener(delegate { AssignPatientResource(dropdown.selectedItemIndex); });
        }
        else if (mode == Mode.Training)
        {
            
        }
    }

    public void Training()
    {
        int patientIndex = PlayerPrefs.GetInt("patient");

        //setting patient number
        if (patientIndex > -1 && patientIndex < charMats.Count - 1)
        {
            int x = patientIndex + 1;
            PlayerPrefs.SetInt("patient", x);
        }
        else
            PlayerPrefs.SetInt("patient", 0);

        Debug.Log(" current patient number from list: " + patientIndex);

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

    public sphereCollAnim collAnim;

    #region transition to check-In
    public void transition()
    {
        collAnim = FindObjectOfType<sphereCollAnim>();
        StartCoroutine(FadeImage());
        Debug.Log("transition");
    }

    IEnumerator FadeImage()
    {
        Debug.Log("fading");
        yield return new WaitForSeconds(2f);
        for (float i = 0; i <= 1; i += Time.deltaTime * 1f)
        {
            // set color with i as alpha
            transPanel.color = new Color(0, 0, 0, i);
            yield return null;
        }

        patient.SetActive(false);
        SetCheckinPosition();

        dialoguePanel2.SetActive(true);
        patient.SetActive(true);

        for (float i = 1; i >= 0; i -= Time.deltaTime * 1f)
        {
            // set color with i as alpha
            transPanel.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }

    private void SetCheckinPosition()
    {
        switch (collAnim.name)
        {

            case "model1_Sphere":
                patient.transform.position = new Vector3(-32.6080017f, 0, -12.7550001f);
                patient.transform.eulerAngles = new Vector3(0, 308.770355f, 0);
                break;
            case "model2_Sphere":
                patient.transform.localPosition = new Vector3(0.239999995f, -2.15700006f, -0.379999995f);
                patient.transform.eulerAngles = new Vector3(0, 106.290787f, 0);
                break;

            case "model3_Sphere":
                patient.transform.localPosition = new Vector3(0.239999995f, -2.15700006f, -0.379999995f);
                patient.transform.eulerAngles = new Vector3(0, 105.450195f, 0);
                break;
        }
    }
    #endregion

    public void NextPatientCheck()
    {
        if (!boolRef.LoadScene_valid)
        {
            redBtnPress();
        }

        if (boolRef.LoadScene_valid)
        {
            SceneManager.LoadScene(0);
        }
        boolRef.LoadScene_valid = true;
    }
    void redBtnPress()
    {
        source.Play();
        patient.SetActive(true);
        btn.GetComponent<Button>().interactable = true;
        btn.GetComponent<ButtonManager>().isInteractable = true;
        ghost.SetActive(false);
        redBTN.enabled = false;
    }

    void AssignPatientResource(int opt)
    {
        sendPatientData.currentPatinetIndex = opt;
        sendPatientData.currentPatientName = charMats[opt].name;

        patient = charMats[opt].patientPrefab;
        animateManager.instance.patient = patient;
        animateManager.instance.handSphere = charMats[opt].handSphere;
        animateManager.instance.cards = charMats[opt].cardsInHand;
        DL.mainTexture = charMats[opt].DLMat;
        HC.mainTexture = charMats[opt].HCMat;
        clipboard.sprite = charMats[opt].clipboard;
        illnessClip = illness.clips[opt].clip;
        checkInAppClip = checkInApp.clips[opt].clip;
        appText.text = charMats[opt].appDetails;
        checkInTextField.text = charMats[opt].patientName;
        checkInScanSprite = charMats[opt].DLsprite;

        if (mode == Mode.Practice)
        {
            patient.SetActive(true);
            btn.GetComponent<Button>().interactable = true;
            btn.GetComponent<ButtonManager>().isInteractable = true;
        }
    }
}