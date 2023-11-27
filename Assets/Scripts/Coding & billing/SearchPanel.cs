using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SearchPanel : MonoBehaviour
{
    public static SearchPanel Instance { get; private set; }  
    public TMP_InputField searchInput;
    public Dropdown suggestionDropdown;
    public List<string> allWords; // List of all words to search from
    public GameObject DiabetesPanel;
    public GameObject Reason;
    public GameObject HyperTensionPanel;
    public GameObject AnxietyPanel;

    public List<string> filteredWords; // List of filtered words based on the search input


    public Dictionary<string, string> myDictionary = new Dictionary<string, string>()
    {
       { "Z02.9", "Encounter for administrative examinations,unspecified" },
       { "Ell.9", "Type 2 diabetes mellitus without complications" },
        {"I10", "Essential (primary) hypertension" },
        {"F41.9", "Anxiety disorder, unspecified" },
        {"D64.9", "Anemia, unspecified" },
        {"D75.1", "Secondary polycythemia" },
        {"E11.621", "Type 2 diabetes mellitus with foot ulcer" },
        {"E11.9", "Type 2 diabetes mellitus without complications" },
        {"E78.5", "Hyperlipidemia, unspecified" },
        {"F32.9", "Major depressive disorder, single episode, unspecified" },
        {"F41.8", "Other specified anxiety disorders" },
        {"F80.9", "Developmental disorder of speech and language, unspecified" },
        {"F90.9", "Attention-deficit hyperactivity disorder, unspecified type" },
        {"I48.91", "Unspecified atrial fibrillation" },
        {"I50.9", "Heart failure, unspecified" },
        {"J01.00", "Acute maxillary sinusitis, unspecified" },
        {"J02.9", "Acute pharyngitis, unspecified" },
        {"J06.9", "Acute upper respiratory infection, unspecified" },
        {"J30.2", "Other seasonal allergic rhinitis" },
        {"J32.9", "Chronic sinusitis, unspecified" },
        {"J44.9", "Chronic obstructive pulmonary disease, unspecified " },
        {"M54.5", "Low back pain" },
        {"R05", "Cough" },
        {"R06.02", "Shortness of breath" },
        {"R07.89", "Other chest pain" },
        {"R07.9", "Chest pain, unspecified" },
        {"R11.2", "Nausea with vomiting, unspecified" },
        {"R42", "Dizziness and giddiness" },
        {"R50.9", "Fever, unspecified" },
        {"R51.9", "Headache, unspecified" },
        {"Z00.00", "Encounter for general adult medical examination without abnormal findings" },
        {"Z00.121", "Encounter for routine child health examination with abnormal findings"},
        {"Z00.129", "Encounter for routine child health examination without abnormal findings" },
        {"Z09", "Encounter for follow-up examination after completed treatment for conditions other than malignant neoplasm" },
        {"Z11.59", "Encounter for screening for other viral diseases" },
        {"Z12.31", "Encounter for screening mammogram for malignant neoplasm of breast " },
        {"Z20.822" , "Contact with and (suspected) exposure to COVIDI 9"},
        {"Z20.828", "Contact with and (suspected) exposure to other viral communicable diseases" },
        {"Z23", "Encounter for immunization" },
        {"Z51.6" , "Encounter for desensitization to allergens"},
        {"Z71.3" , "Dietary counseling and surveillance"},
        {"Z79.01", "Long term (current) use of anticoagulants" },
        {"Z91.09", "Other allergy status, other than to drugs and biological substances" },
        {"U07.1", "COVID-19" },
        {"N39.0", "Urinary tract infection, site not specified" },
        {"Z00.01", "Encounter for general adult medical examination with abnormal findings"},
        {"R10.9", "Unspecified abdominal pain" },
    };

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        // Add a listener to the search input's OnValueChanged event
        // searchInput.onEndEdit.AddListener(OnSearchInputValueChanged);
        //searchInput.onValueChanged.AddListener(callFunc);

        foreach (var kvp in myDictionary)
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
        if(searchValue.Contains("Diabetes") || searchValue.Contains("diabetes"))
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
        else if(searchValue.Contains("Anxiety") || searchValue.Contains("anxiety"))
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

            if(DiabetesPanel != null)
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