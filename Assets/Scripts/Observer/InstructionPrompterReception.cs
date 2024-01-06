using UnityEngine;

/// <summary>
/// Represents the Instruction Prompter for the Reception scene and implements the IObserver interface.
/// </summary>
public class InstructionPrompterReception : MonoBehaviour, IObserver
{
    public static InstructionPrompterReception Instance;

    // The ScriptableObject containing audio instructions.
    public Sounds instructionsSO;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        //Invoke(nameof(redButton), instructionsSO.clips[0].time);
    }

    #region Observer Subscriber
    [SerializeField] private Subject _sub;

    /// <summary>
    /// Implementation of the OnNotify method from the IObserver interface.
    /// </summary>
    /// <param name="action">The ButtonPressAction to notify about.</param>
    public void OnNotify(ButtonPressAction action)
    {
        switch (action)
        {
            case ButtonPressAction.dialoguePanel:
                instructionsSO.Instruction_validForOnce = false;
                Invoke(nameof(dpDelay), instructionsSO.clips[1].time);
                break;

            case ButtonPressAction.giveClipboard:
                Invoke(nameof(ffDelay), instructionsSO.clips[2].time);
                break;

            case ButtonPressAction.scanID:
                Invoke(nameof(idDelay), instructionsSO.clips[3].time);
                break;

            case ButtonPressAction.fillDetails:
                Invoke(nameof(detailsDelay), instructionsSO.clips[4].time);
                break;

            case ButtonPressAction.nextScene:
                Invoke(nameof(gnsDelay), instructionsSO.clips[5].time);
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
        _sub.AddObserver(this);
    }

    /// <summary>
    /// Disables the manager from observing button press actions.
    /// </summary>
    private void OnDisable()
    {
        _sub.RemoveObserver(this);
    }

    /// <summary>
    /// Plays the audio for the red button instruction.
    /// </summary>
    void redButton()
    {
        SoundManager.instance.PlayClipOneShot(instructionsSO.clips[0].clip, instructionsSO.Instruction_validForOnce);
    }
    #endregion

    #region Audio Play Delay
    /// <summary>
    /// Delays and plays the audio for the dialogue panel instruction.
    /// </summary>
    void dpDelay()
    {
        SoundManager.instance.PlayClipOneShot(instructionsSO.clips[1].clip, instructionsSO.Instruction_validForOnce);
    }

    /// <summary>
    /// Delays and plays the audio for the give clipboard instruction.
    /// </summary>
    void ffDelay()
    {
        SoundManager.instance.PlayClipOneShot(instructionsSO.clips[2].clip, instructionsSO.Instruction_validForOnce);
    }

    /// <summary>
    /// Delays and plays the audio for the scan ID instruction.
    /// </summary>
    void idDelay()
    {
        SoundManager.instance.PlayClipOneShot(instructionsSO.clips[3].clip, instructionsSO.Instruction_validForOnce);
    }

    /// <summary>
    /// Delays and plays the audio for the fill details instruction.
    /// </summary>
    private void detailsDelay()
    {
        SoundManager.instance.PlayClipOneShot(instructionsSO.clips[4].clip, instructionsSO.Instruction_validForOnce);
    }

    /// <summary>
    /// Delays and plays the audio for the next scene instruction.
    /// </summary>
    void gnsDelay()
    {
        SoundManager.instance.PlayClipOneShot(instructionsSO.clips[5].clip, instructionsSO.Instruction_validForOnce);
        instructionsSO.Instruction_validForOnce = true;
    }
    #endregion
}