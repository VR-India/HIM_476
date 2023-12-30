using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Michsky.MUIP;
using Newtonsoft.Json;

public class SearchBar : MonoBehaviour
{
    //public static SearchBar Instance { get; private set; }

    public TMP_InputField searchInput;
    public CustomDropdown suggestionDropdown;

    public List<string> allWords; // List of all words to search from
    //public List<string> filteredWords; // List of filtered words based on the search input

    public static Dictionary<string, string> codes = new Dictionary<string, string>();

    private static List<CustomDropdown.Item> originalOptions;

    //private void Awake()
    //{
    //    if (Instance != null)
    //        return;

    //    Instance = this;

    //    string json = Resources.Load<TextAsset>("jsonBillData/code").text;
    //    codes = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
    //}

    private void Start()
    {
    //    if (Instance != null)
    //        return;

    //    Instance = this;

        string json = Resources.Load<TextAsset>("jsonBillData/code").text;
        codes = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        foreach (var item in codes)
        {
            allWords.Add(item.Key);
        }

        for (int i = 0; i < allWords.Count; i++)
        {
            suggestionDropdown.items[i].itemName = allWords[i];
        }
        originalOptions = new List<CustomDropdown.Item>(suggestionDropdown.items);
        searchInput.onValueChanged.AddListener(FilterDropdownOptions);

        RefreshDropdown();
    }

    void FilterDropdownOptions(string searchText)
    {
        if (string.IsNullOrEmpty(searchText))
        {
            RefreshDropdown();
            return;
        }

        List<CustomDropdown.Item> filteredOptions = originalOptions.FindAll(option =>
            option.itemName.ToLower().Contains(searchText.ToLower()));

        suggestionDropdown.items = filteredOptions;

        foreach (var item in suggestionDropdown.items)
            item.OnItemSelection.AddListener(delegate { OnDropdownValueChanged(item.itemName); });

        suggestionDropdown.SetupDropdown();
        suggestionDropdown.isOn = false;
        suggestionDropdown.Animate();
    }

    void OnDropdownValueChanged(string itemName)
    {
        searchInput.text = itemName;
    }

    void RefreshDropdown()
    {
        suggestionDropdown.isOn = true;
        suggestionDropdown.Animate();
        suggestionDropdown.items.Clear();
        suggestionDropdown.items = originalOptions;
        suggestionDropdown.SetupDropdown();
    }
}