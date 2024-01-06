using BNG;
using UnityEngine;

/// <summary>
/// Handles interactions with colliders present in hand.
/// </summary>
public class InteractableObjectHandler : MonoBehaviour
{
    public GameObject clipBoard, emptyPage, fillPage, DL, MC;
    public bool filled = false, given = false, checkGiven = true;
    int patientIndex;

    /// <summary>
    /// Handles interactions when the object stays triggered with other colliders.
    /// </summary>
    /// <param name="other">The collider of the interacting object.</param>
    private void OnTriggerStay(Collider other)
    {
        // Get the patient index from PlayerPrefs.
        patientIndex = PlayerPrefs.GetInt("patient");

        // Check if the interacting object is a clipboard, not being held in hand, and the form is also not filled.
        if (other.CompareTag("Clipboard") && clipBoard.GetComponent<Grabbable>().BeingHeld == false && !filled)
        {
            HandleClipboardInteraction();
        }

        // Check if the interacting object is cards, being held in hand, and the cards are not given.
        else if (other.CompareTag("Cards") && other.GetComponent<Grabbable>().BeingHeld == true && !given)
        {
            HandleCardsInteraction(other);
        }

        // Check if the interacting object is cards, being held in hand, and the check is not given.
        else if (other.CompareTag("Cards") && other.GetComponent<Grabbable>().BeingHeld == true && !checkGiven)
        {
            HandleCheckGivenInteraction(other);
        }

        // Check if the form is filled and the clipboard is being held in hand.
        else if (filled && clipBoard.GetComponent<Grabbable>().BeingHeld == true)
        {
            PatientInteractionAnimator.instance.givenClipboard();
        }
    }

    /// <summary>
    /// Handles the behavior when an object exits the trigger area.
    /// </summary>
    /// <param name="other">The collider of the object that exited the trigger area.</param>
    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object is cards, and the cards is being held in hand.
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

    /// <summary>
    /// Handles the interaction when the clipboard is picked up.
    /// </summary>
    void HandleClipboardInteraction()
    {
        // Disable the grabbable component of the clipboard
        clipBoard.GetComponent<Grabbable>().enabled = false;

        // Trigger the animation for taking the clipboard
        PatientInteractionAnimator.instance.takenClipboard();

        // Set the clipboard's parent to the same parent as the interactable object
        clipBoard.transform.SetParent(this.transform.parent);

        // Position and rotate the clipboard based on the name of the interactable object
        switch (this.gameObject.name)
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

        // Invoke the FillingForm method after a delay of 2 seconds
        Invoke(nameof(FillingForm), 2f);
    }

    /// <summary>
    /// Handles the interaction when cards are grabbed.
    /// </summary>
    /// <param name="other">The Collider of the interacting object.</param>
    void HandleCardsInteraction(Collider other)
    {
        // Sets the parent of the interacting object to null.
        other.transform.SetParent(null);

        // Initiates the animation for giving the cards.
        PatientInteractionAnimator.instance.givenCards();

        // Marks the cards as given.
        given = true;
    }

    /// <summary>
    /// Handles the interaction when check-in ID is given.
    /// </summary>
    void HandleCheckGivenInteraction(Collider other)
    {
        // Sets the parent of the interacting object to null.
        other.transform.SetParent(null);

        // Initiates the animation for setting the position.
        PatientInteractionAnimator.instance.setPosition();

        // Plays the "CheckIn ID given" animation for the patient.
        PatientInteractionAnimator.instance.patient.GetComponent<Animator>().Play("CheckIn ID given");

        // Sets the transform and activates specified game objects.
        SetTransformAndActivate(DL, new Vector3(-33.0419998f, 0.732200027f, -13.307f), new Vector3(0f, 0.146f, 359.503998f));
        SetTransformAndActivate(MC, new Vector3(-33.0419998f, 0.732200027f, -13.207f), new Vector3(0f, 0.146f, 359.503998f));

        //DL.transform.SetParent(null);
        //DL.transform.position = new Vector3(-33.0419998f, 0.732200027f, -13.307f);
        //DL.transform.localEulerAngles = new Vector3(0f, 0.146f, 359.503998f);
        //DL.SetActive(true);
        //MC.transform.SetParent(null);
        //MC.transform.position = new Vector3(-33.0419998f, 0.732200027f, -13.207f);
        //MC.transform.localEulerAngles = new Vector3(0f, 0.146f, 359.503998f);
        //MC.SetActive(true);

        // Marks the check-in as given.
        checkGiven = true;
    }

    /// <summary>
    /// Sets the transform and activates the specified GameObject.
    /// </summary>
    /// <param name="obj">The GameObject to be transformed and activated.</param>
    /// <param name="position">The new position of the GameObject.</param>
    /// <param name="eulerAngles">The new local euler angles of the GameObject.</param>
    void SetTransformAndActivate(GameObject obj, Vector3 position, Vector3 eulerAngles)
    {
        obj.transform.SetParent(null);
        obj.transform.position = position;
        obj.transform.localEulerAngles = eulerAngles;
        obj.SetActive(true);
    }

    /// <summary>
    /// Fills the form by activating the filled page and deactivating the empty page. 
    /// </summary>
    void FillingForm()
    {
        emptyPage.SetActive(false);
        fillPage.SetActive(true);

        // Enabling the grabbable feature of the clipboard
        clipBoard.GetComponent<Grabbable>().enabled = true;

        //animateManager.instance.givenClipboard();
        //GetComponent<SphereCollider>().enabled = false;

        // Marking the form as filled.
        filled = true;
    }
}
