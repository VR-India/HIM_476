using UnityEngine;

public class InstructionPromptManager : MonoBehaviour, IObserver
{
    public static InstructionPromptManager instance;
    public Sounds audioSO;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


        Invoke(nameof(hello), audioSO.clips[0].time);
    }

    #region Observer Subscriber
    [SerializeField] subject _subject;
    public void OnNotify(ButtonPressAction action)
    {
        switch(action)
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

    private void OnEnable()
    {
        _subject.AddObserver(this);
    }

    private void OnDisable()
    {
        _subject.RemoveObserver(this);
    }
    #endregion

    #region Audio Play Delay
    void hello()
    {
        SoundManager.instance.PlayClipOneShot(audioSO.clips[0].clip);
    }
    void drDelay()
    {
        SoundManager.instance.PlayClipOneShot(audioSO.clips[1].clip);
    }

    void rmDelay()
    {
        SoundManager.instance.PlayClipOneShot(audioSO.clips[2].clip);
    }

    void submitDelay()
    {
        SoundManager.instance.PlayClipOneShot(audioSO.clips[3].clip);
    }
    #endregion
}
