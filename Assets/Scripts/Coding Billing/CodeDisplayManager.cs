using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the instantiation of prefab as per code based on user input.
/// </summary>
public class CodeDisplayManager : MonoBehaviour
{
    // The prefab used for displaying coding details.
    public GameObject codeDetailsPrefab;

    // The array of TMP_Text components used for displaying text in the code details.
    public TMP_Text[] tMP_Texts;

    // The input field for entering the code.
    public TMP_InputField CodeInput;

    // The list of instantiated code GameObjects.
    public List<GameObject> codeGO;

    // The static variable storing the code name.
    public static string name;

    /// <summary>
    /// Instantiates a GameObject with text values based on code when the button is clicked.
    /// </summary>
    public void InstantiateOnClick()
    {
        name = CodeInput.text;

        if (name != null)
        {
            if (name.Contains("Diabetes") || name.Contains("diabetes"))
            {
                GameObject temp = Instantiate(codeDetailsPrefab, this.transform);
                tMP_Texts = temp.GetComponentsInChildren<TMP_Text>();

                // Set text values based on the code from the SearchPanel
                foreach (var kvp in SearchPanel.Instance.codes)
                {
                    if (kvp.Key == "E11.9")
                    {
                        tMP_Texts[0].text = kvp.Key.ToString();
                        tMP_Texts[1].text = kvp.Value.ToString();
                    }
                }

                // Add a click listener to remove the code from the list
                temp.GetComponentInChildren<Button>().onClick.AddListener(delegate { RemoveCodeFromList(temp); });
                codeGO.Add(temp);
            }

            else if(name.Contains("Hypertension") || name.Contains("hypertension"))
            {
                GameObject temp = Instantiate(codeDetailsPrefab, this.transform);
                tMP_Texts = temp.GetComponentsInChildren<TMP_Text>();

                // Set text values based on the code from the SearchPanel
                foreach (var kvp in SearchPanel.Instance.codes)
                {
                    if (kvp.Key == "I10")
                    {
                        tMP_Texts[0].text = kvp.Key.ToString();
                        tMP_Texts[1].text = kvp.Value.ToString();
                    }
                }

                // Add a click listener to remove the code from the list
                temp.GetComponentInChildren<Button>().onClick.AddListener(delegate { RemoveCodeFromList(temp); });
                codeGO.Add(temp);
            }

            else if(name.Contains("Anxiety") || name.Contains("anxiety"))
            {
                GameObject temp = Instantiate(codeDetailsPrefab, this.transform);
                tMP_Texts = temp.GetComponentsInChildren<TMP_Text>();

                // Set text values based on the code from the SearchPanel
                foreach (var kvp in SearchPanel.Instance.codes)
                {
                    if (kvp.Key == "F41.9")
                    {
                        tMP_Texts[0].text = kvp.Key.ToString();
                        tMP_Texts[1].text = kvp.Value.ToString();
                    }
                }

                // Add a click listener to remove the code from the list
                temp.GetComponentInChildren<Button>().onClick.AddListener(delegate { RemoveCodeFromList(temp); });
                codeGO.Add(temp);
            }

            else
            {
                GameObject temp = Instantiate(codeDetailsPrefab, this.transform);
                tMP_Texts = temp.GetComponentsInChildren<TMP_Text>();

                // Set text values based on the code from the SearchPanel
                foreach (var kvp in DropdownSearchHandler.codes)//SearchBar.Instance.codes)
                {
                    if (kvp.Key == CodeInput.text)
                    {
                        tMP_Texts[0].text = kvp.Key.ToString();
                        tMP_Texts[1].text = kvp.Value.ToString();
                    }
                }

                // Add a click listener to remove the code from the list
                temp.GetComponentInChildren<Button>().onClick.AddListener(delegate { RemoveCodeFromList(temp); });
                codeGO.Add(temp);
            }
        }
    }

    /// <summary>
    /// Removes a code GameObject from the list and destroys it.
    /// </summary>
    /// <param name="go">The GameObject to be removed and destroyed.</param>
    void RemoveCodeFromList(GameObject go)
    {
        codeGO.Remove(go);
        Destroy(go);
    }
}
