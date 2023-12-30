using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Newtonsoft.Json;

public class SearchPanel : MonoBehaviour
{
    public static SearchPanel Instance { get; private set; }

    private TMP_InputField searchInput;
    private Dropdown suggestionDropdown;

    public GameObject DiabetesPanel;
    public GameObject Reason;
    public GameObject HyperTensionPanel;
    public GameObject AnxietyPanel;

    public Dictionary<string, string> codes = new Dictionary<string, string>();
    private List<string> allWords = new(); // List of all words to search from
    private List<string> filteredWords = new(); // List of filtered words based on the search input

    private void Awake()
    {
        string json = Resources.Load<TextAsset>("jsonBillData/code").text;
        codes = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        if (Instance != null)
            return;

        Instance = this;
    }

    private void Start()
    {
        // Add a listener to the search input's OnValueChanged event
        //searchInput.onEndEdit.AddListener(OnSearchInputValueChanged);
        //searchInput.onValueChanged.AddListener(callFunc);
        searchInput = GetComponentInChildren<TMP_InputField>();
        suggestionDropdown = GetComponentInChildren<Dropdown>();

        foreach (var kvp in codes)
        {
            allWords.Add(kvp.Key);
        }
    }

    


    public void callFunc(string s)
    {
        //Debug.Log(s);
        StartCoroutine(OnSearchInputValueChanged(s));
    }

    private IEnumerator OnSearchInputValueChanged(string searchValue)
    {
        yield return new WaitForSeconds(3f);
        // Debug.Log("searchvalue " + searchValue);
        suggestionDropdown.ClearOptions();

        filteredWords = allWords.FindAll(word => word.ToLower().Contains(searchValue.ToLower()));
        filteredWords.Insert(0, "....");

        suggestionDropdown.AddOptions(filteredWords);

        suggestionDropdown.Show();
        if (searchValue.Contains("Diabetes") || searchValue.Contains("diabetes"))
        {
            AddCoding.name = searchValue;
            DiabetesPanel?.SetActive(true);
            Reason?.SetActive(false);
        }
        else if (searchValue.Contains("Hypertension") || searchValue.Contains("hypertension"))
        {
            AddCoding.name = searchValue;
            HyperTensionPanel?.SetActive(true);
            Reason?.SetActive(false);
        }
        else if (searchValue.Contains("Anxiety") || searchValue.Contains("anxiety"))
        {
            AddCoding.name = searchValue;
            AnxietyPanel?.SetActive(true);
            Reason?.SetActive(false);
        }

        else
        {
            AddCoding.name = searchValue;
            DiabetesPanel?.SetActive(false);
            Reason?.SetActive(true);

        }
        //suggestionDropdown.gameObject.SetActive(filteredWords.Count > 0);

    }

    public void OnSuggestionSelected()
    {
        string selectedSuggestion = filteredWords[suggestionDropdown.value];
        searchInput.text = selectedSuggestion;
        //Debug.Log(searchInput.text);
        //suggestionDropdown.gameObject.SetActive(false);

    }

    public void OnSearch()
    {
        suggestionDropdown.ClearOptions();

        filteredWords = allWords.FindAll(word => word.ToLower().Contains(searchInput.text.ToLower()));
        filteredWords.Insert(0, "....");

        suggestionDropdown.AddOptions(filteredWords);

        suggestionDropdown.Show();
        if (searchInput.text.Contains("Diabetes") || searchInput.text.Contains("diabetes"))
        {
            AddCoding.name = searchInput.text;
            DiabetesPanel?.SetActive(true);
            Reason?.SetActive(false);
        }
        else if (searchInput.text.Contains("Hypertension") || searchInput.text.Contains("hypertension"))
        {
            AddCoding.name = searchInput.text;
            HyperTensionPanel?.SetActive(true);
            Reason?.SetActive(false);
        }
        else if (searchInput.text.Contains("Anxiety") || searchInput.text.Contains("anxiety"))
        {
            AddCoding.name = searchInput.text;
            AnxietyPanel?.SetActive(true);
            Reason?.SetActive(false);
        }

        else
        {
            AddCoding.name = searchInput.text;

            if (DiabetesPanel != null)
                DiabetesPanel.SetActive(false);
            if (Reason != null)
                Reason.SetActive(true);

        }
    }

    public void OnClear()
    {
        suggestionDropdown.Hide();
        searchInput.text = string.Empty;
        AddCoding.name = searchInput.text;
    }
}