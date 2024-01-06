using UnityEngine;

/// <summary>
/// Represents the Instruction Prompter for the Coding Billing scene and implements the IObserver interface.
/// </summary>
public class InstructionPrompterCodingBilling : MonoBehaviour, IObserver
{
    public static InstructionPrompterCodingBilling instance;

    // ScriptableObject containing audio clips.
    public Sounds audioSO;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Play initial audio clip after a delay.
        Invoke(nameof(hello), audioSO.clips[0].time);
    }

    #region Observer Subscriber
    [SerializeField] private Subject _subject;

    /// <summary>
    /// Implementation of the OnNotify method from the IObserver interface.
    /// </summary>
    /// <param name="action">The ButtonPressAction to notify about.</param>
    public void OnNotify(ButtonPressAction action)
    {
        switch (action)
        {
            case ButtonPressAction.AppIcon:
                Invoke(nameof(drDelay), audioSO.clips[1].time);
                break;

            case ButtonPressAction.OpenDoc:
                Invoke(nameof(rmDelay), audioSO.clips[2].time);
                break;

            case ButtonPressAction.ReportSubmit:
                Invoke(nameof(submitDelay), audioSO.clips[3].time);
                break;

            default:
                Debug.Log("Invalid Button Press");
                break;
        }
    }

    /// <summary>
    /// Enables the manager to start observing button press actions.
    /// </summary>
    private void OnEnable()
    {
        _subject.AddObserver(this);
    }

    /// <summary>
    /// Disables the manager from observing button press actions.
    /// </summary>
    private void OnDisable()
    {
        _subject.RemoveObserver(this);
    }
    #endregion

    #region Audio Play Delay
    /// <summary>
    /// Plays an initial hello audio clip after a delay.
    /// </summary>
    void hello()
    {
        SoundManager.instance.PlayClipOneShot(audioSO.clips[0].clip);
    }

    /// <summary>
    /// Delays and plays an audio clip associated with the DrDelay action.
    /// </summary>
    void drDelay()
    {
        SoundManager.instance.PlayClipOneShot(audioSO.clips[1].clip);
    }

    /// <summary>
    /// Delays and plays an audio clip associated with the RmDelay action.
    /// </summary>
    void rmDelay()
    {
        SoundManager.instance.PlayClipOneShot(audioSO.clips[2].clip);
    }

    /// <summary>
    /// Delays and plays an audio clip associated with the SubmitDelay action.
    /// </summary>
    void submitDelay()
    {
        SoundManager.instance.PlayClipOneShot(audioSO.clips[3].clip);
    }
    #endregion
}
