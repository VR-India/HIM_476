using UnityEngine;
using UnityEngine.UI;

public class PanelButtonFetcher : MonoBehaviour
{
    public Button[] btnsTMP;
    //public ButtonManager[] btnsMUI;

    private void Start()
    {
        btnsTMP = GetComponentsInChildren<Button>();

        //btnsMUI = GetComponentsInChildren<ButtonManager>();

        if (btnsTMP != null)
        {
            foreach (Button button in btnsTMP)
            {
                button.onClick.AddListener(() => UIManager.instance.btnAction(button.name));
                button.onClick.AddListener(() => Haptics.instance.callHaptics());
            }
        }
    }
}