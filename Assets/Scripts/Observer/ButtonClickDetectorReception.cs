using Michsky.UI.ModernUIPack;
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
    public ButtonManagerBasic fillForm, askId, twoMins, doctorFree;
    public BNG.Button redBtn;

    private void Start()
    {
        redBtn.onButtonDown.AddListener(() => NotifyObserver(ButtonPressAction.dialoguePanel));
        //redBtn.onClick.AddListener(() => NotifyObserver(ButtonPressAction.dialoguePanel));
        fillForm.clickEvent.AddListener(() => NotifyObserver(ButtonPressAction.giveClipboard));
        askId.clickEvent.AddListener(() => NotifyObserver(ButtonPressAction.scanID));
        twoMins.clickEvent.AddListener(() => NotifyObserver(ButtonPressAction.fillDetails));
        doctorFree.clickEvent.AddListener(() => NotifyObserver(ButtonPressAction.nextScene));
    }
}