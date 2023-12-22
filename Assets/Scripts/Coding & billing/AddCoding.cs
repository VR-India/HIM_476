using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddCoding : MonoBehaviour
{
    public GameObject codeDetailsPrefab;
    public TMP_Text[] tMP_Texts;
    public TMP_InputField CodeInput;

    public List<GameObject> codeGO;

    public static string name;

    public void InstantiateOnClick()
    {
        if (name != null)
        {
            if (name.Contains("Diabetes") || name.Contains("diabetes"))
            {
                GameObject temp = Instantiate(codeDetailsPrefab, this.transform);
                tMP_Texts = temp.GetComponentsInChildren<TMP_Text>();

                foreach (var kvp in SearchPanel.Instance.codes)
                {
                    if (kvp.Key == "E11.9")
                    {
                        tMP_Texts[0].text = kvp.Key.ToString();
                        tMP_Texts[1].text = kvp.Value.ToString();
                    }
                }
                temp.GetComponentInChildren<Button>().onClick.AddListener(delegate { RemoveCodeFromList(temp); });
                codeGO.Add(temp);
            }
            else if(name.Contains("Hypertension") || name.Contains("hypertension"))
            {
                GameObject temp = Instantiate(codeDetailsPrefab, this.transform);
                tMP_Texts = temp.GetComponentsInChildren<TMP_Text>();
                foreach (var kvp in SearchPanel.Instance.codes)
                {
                    if (kvp.Key == "I10")
                    {
                        tMP_Texts[0].text = kvp.Key.ToString();
                        tMP_Texts[1].text = kvp.Value.ToString();
                    }
                }
                temp.GetComponentInChildren<Button>().onClick.AddListener(delegate { RemoveCodeFromList(temp); });
                codeGO.Add(temp);
            }
            else if(name.Contains("Anxiety") || name.Contains("anxiety"))
            {
                GameObject temp = Instantiate(codeDetailsPrefab, this.transform);
                tMP_Texts = temp.GetComponentsInChildren<TMP_Text>();
                foreach (var kvp in SearchPanel.Instance.codes)
                {
                    if (kvp.Key == "F41.9")
                    {
                        tMP_Texts[0].text = kvp.Key.ToString();
                        tMP_Texts[1].text = kvp.Value.ToString();
                    }
                }
                temp.GetComponentInChildren<Button>().onClick.AddListener(delegate { RemoveCodeFromList(temp); });
                codeGO.Add(temp);
            }
            else
            {
                GameObject temp = Instantiate(codeDetailsPrefab, this.transform);
                tMP_Texts = temp.GetComponentsInChildren<TMP_Text>();
                foreach (var kvp in SearchPanel.Instance.codes)
                {
                    if (kvp.Key == CodeInput.text)
                    {
                        tMP_Texts[0].text = kvp.Key.ToString();
                        tMP_Texts[1].text = kvp.Value.ToString();
                    }
                }
                temp.GetComponentInChildren<Button>().onClick.AddListener(delegate { RemoveCodeFromList(temp); });
                codeGO.Add(temp);
            }
        }
    }

    void RemoveCodeFromList(GameObject go)
    {
        codeGO.Remove(go);
        Destroy(go);
    }
}
