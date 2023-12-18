using Michsky.MUIP;
using UnityEngine.UI;
using UnityEngine;

public enum ButtonPressAction
{
    #region coding actions
    AppIcon,
    OpenDoc,
    ReportSubmit,
    #endregion

    #region reception actions
    dialoguePanel,
    giveClipboard,
    scanID,
    fillDetails,
    nextScene,
    #endregion
}

public class ButtonClickDetectorReception : subject
{
    public ButtonManager fillForm, askId, twoMins, doctorFree;
    public BNG.Button redBtn;

    private void Start()
    {
        redBtn.onButtonDown.AddListener(() => NotifyObserver(ButtonPressAction.dialoguePanel));
        //redBtn.onClick.AddListener(() => NotifyObserver(ButtonPressAction.dialoguePanel));
        fillForm.onClick.AddListener(() => NotifyObserver(ButtonPressAction.giveClipboard));
        askId.onClick.AddListener(() => NotifyObserver(ButtonPressAction.scanID));
        twoMins.onClick.AddListener(() => NotifyObserver(ButtonPressAction.fillDetails));
        doctorFree.onClick.AddListener(() => NotifyObserver(ButtonPressAction.nextScene));
    }
}