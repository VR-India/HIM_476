
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AddCoding : MonoBehaviour
{
    public GameObject codeDetailsPrefab;
    public TMP_Text[] tMP_Texts;
    public TMP_InputField CodeInput;

    public static string name;

    public void InstantiateOnClick()
    {
        if (name != null)
        {
            if (name.Contains("Diabetes") || name.Contains("diabetes"))
            {
                GameObject temp = Instantiate(codeDetailsPrefab, this.transform);
                tMP_Texts = temp.GetComponentsInChildren<TMP_Text>();
                foreach (var kvp in SearchPanel.Instance.myDictionary)
                {
                    if (kvp.Key == "E11.9")
                    {
                        tMP_Texts[0].text = kvp.Key.ToString();
                        tMP_Texts[1].text = kvp.Value.ToString();
                    }
                }
            }
            else if(name.Contains("Hypertension") || name.Contains("hypertension"))
            {
                GameObject temp = Instantiate(codeDetailsPrefab, this.transform);
                tMP_Texts = temp.GetComponentsInChildren<TMP_Text>();
                foreach (var kvp in SearchPanel.Instance.myDictionary)
                {
                    if (kvp.Key == "I10")
                    {
                        tMP_Texts[0].text = kvp.Key.ToString();
                        tMP_Texts[1].text = kvp.Value.ToString();
                    }
                }
            }
            else if(name.Contains("Anxiety") || name.Contains("anxiety"))
            {
                GameObject temp = Instantiate(codeDetailsPrefab, this.transform);
                tMP_Texts = temp.GetComponentsInChildren<TMP_Text>();
                foreach (var kvp in SearchPanel.Instance.myDictionary)
                {
                    if (kvp.Key == "F41.9")
                    {
                        tMP_Texts[0].text = kvp.Key.ToString();
                        tMP_Texts[1].text = kvp.Value.ToString();
                    }
                }
            }
            else
            {
                GameObject temp = Instantiate(codeDetailsPrefab, this.transform);
                tMP_Texts = temp.GetComponentsInChildren<TMP_Text>();
                foreach (var kvp in SearchPanel.Instance.myDictionary)
                {
                    if (kvp.Key == CodeInput.text)
                    {
                        tMP_Texts[0].text = kvp.Key.ToString();
                        tMP_Texts[1].text = kvp.Value.ToString();
                    }
                }
            }

        }


    }
}
