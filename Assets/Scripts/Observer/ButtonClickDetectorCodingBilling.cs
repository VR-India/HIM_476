using UnityEngine.UI;

/// <summary>
/// Detects button clicks in the coding billing area and notifies observers.
/// </summary>
public class ButtonClickDetectorCodingBilling : Subject
{
    public Button icon, open, submit;

    private void Start()
    {
        icon.onClick.AddListener(() => NotifyObserver(ButtonPressAction.AppIcon));
        open.onClick.AddListener(() => NotifyObserver(ButtonPressAction.OpenDoc));
        submit.onClick.AddListener(() => NotifyObserver(ButtonPressAction.ReportSubmit));
    }
}