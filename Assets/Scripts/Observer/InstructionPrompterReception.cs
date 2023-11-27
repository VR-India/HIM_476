using UnityEngine;

public class InstructionPrompterReception : MonoBehaviour, IObserver
{
    public static InstructionPrompterReception Instance;
    public Sounds instructionsSO;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        Invoke(nameof(redButton), instructionsSO.clips[0].time);
    }

    [SerializeField] subject _sub;

    public void OnNotify(ButtonPressAction action)
    {
        switch(action)
        {
            case ButtonPressAction.dialoguePanel:
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

    private void OnEnable()
    {
        _sub.AddObserver(this);
    }

    private void OnDisable()
    {
        _sub.RemoveObserver(this);
    }

    void redButton()
    {
        SoundManager.instance.PlayClipOneShot(instructionsSO.clips[0].clip, instructionsSO.Instruction_validForOnce);
    }

    #region Audio Play Delay

    void dpDelay()
    {
        SoundManager.instance.PlayClipOneShot(instructionsSO.clips[1].clip, instructionsSO.Instruction_validForOnce);
    }

    void ffDelay()
    {
        SoundManager.instance.PlayClipOneShot(instructionsSO.clips[2].clip, instructionsSO.Instruction_validForOnce);
    }

    void idDelay()
    {
        SoundManager.instance.PlayClipOneShot(instructionsSO.clips[3].clip, instructionsSO.Instruction_validForOnce);
    }

    private void detailsDelay()
    {
        SoundManager.instance.PlayClipOneShot(instructionsSO.clips[4].clip, instructionsSO.Instruction_validForOnce);
    }

    void gnsDelay()
    {
        SoundManager.instance.PlayClipOneShot(instructionsSO.clips[5].clip, instructionsSO.Instruction_validForOnce);
        instructionsSO.Instruction_validForOnce = true;
    }
    #endregion
}