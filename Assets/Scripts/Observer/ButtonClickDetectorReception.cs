using Michsky.MUIP;

/// <summary>
/// Detects button clicks in the reception area and notifies observers.
/// </summary>
public class ButtonClickDetectorReception : Subject
{
    public ButtonManager fillForm, askId, twoMins, doctorFree, practiceSelect;

    private void Start()
    {
        practiceSelect.onClick.AddListener(() => NotifyObserver(ButtonPressAction.dialoguePanel));
        //redBtn.onClick.AddListener(() => NotifyObserver(ButtonPressAction.dialoguePanel));
        fillForm.onClick.AddListener(() => NotifyObserver(ButtonPressAction.giveClipboard));
        askId.onClick.AddListener(() => NotifyObserver(ButtonPressAction.scanID));
        twoMins.onClick.AddListener(() => NotifyObserver(ButtonPressAction.fillDetails));
        doctorFree.onClick.AddListener(() => NotifyObserver(ButtonPressAction.nextScene));
    }
}