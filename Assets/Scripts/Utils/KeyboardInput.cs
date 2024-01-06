using TMPro;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

public class KeyboardInput : MonoBehaviour
{
    private TMP_InputField inputField;
    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onSelect.AddListener(s => assignInputField());
    }

    private void assignInputField()
    {
        NonNativeKeyboard.Instance.InputField = inputField;
        NonNativeKeyboard.Instance.PresentKeyboard(inputField.text);
    }
}
