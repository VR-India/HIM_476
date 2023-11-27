using UnityEngine.UI;

public class ButtonClickDetector : subject
{
    public Button icon, open, submit;

    private void Start()
    {
        icon.onClick.AddListener(() => NotifyObserver(ButtonPressAction.AppIcon));
        open.onClick.AddListener(() => NotifyObserver(ButtonPressAction.OpenDoc));
        submit.onClick.AddListener(() => NotifyObserver(ButtonPressAction.ReportSubmit));
    }
}