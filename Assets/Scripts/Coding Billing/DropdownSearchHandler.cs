using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Michsky.MUIP;
using Newtonsoft.Json;

public class DropdownSearchHandler : MonoBehaviour
{
    public TMP_InputField searchInput;
    public CustomDropdown suggestionDropdown;

    public List<string> allWords;

    public static Dictionary<string, string> codes = new Dictionary<string, string>();

    private static List<CustomDropdown.Item> originalOptions;

    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// Initializes the dropdown by loading JSON data and populating dropdown items.
    /// </summary>
    void Initialize()
    {
        // Load JSON data from Resources
        string json = Resources.Load<TextAsset>("jsonBillData/code").text;
        codes = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        // Extract all words from codes dictionary keys
        allWords.AddRange(codes.Keys);

        // Assign each word to the corresponding item in the suggestion dropdown
        for (int i = 0; i < allWords.Count; i++)
        {
            suggestionDropdown.items[i].itemName = allWords[i];
        }

        // Cache the original dropdown options
        originalOptions = new List<CustomDropdown.Item>(suggestionDropdown.items);

        // Add event listener for search input changes
        searchInput.onValueChanged.AddListener(FilterDropdownOptions);

        // Refresh the dropdown based on the initial state
        RefreshDropdown();
    }

    /// <summary>
    /// <para>Filters the options in a dropdown based on the provided search text.</para>
    /// <list type="bullet">
    ///     <item><description>If the search text is <i>empty or null</i>, refreshes the dropdown to display all original options.</description></item>
    ///     <item><description>Filters the original options to include only those that contain the specified search text (case-insensitive).</description></item>
    ///     <item><description>Updates the dropdown with the filtered options, sets up item selection listeners, and animates the dropdown.</description></item>
    /// </list>
    /// </summary>
    /// <param name="searchText">The text used to filter the dropdown options.</param>
    void FilterDropdownOptions(string searchText)
    {
        // Check if the search text is empty or null
        if (string.IsNullOrEmpty(searchText))
        {
            // If true, refresh the dropdown and exit the method
            RefreshDropdown();
            return;
        }

        // Filter the original options based on the search text (case-insensitive)
        List<CustomDropdown.Item> filteredOptions = originalOptions.FindAll(option =>
            option.itemName.ToLower().Contains(searchText.ToLower()));

        // Assign the filtered options to the dropdown
        suggestionDropdown.items = filteredOptions;

        // Set up item selection listeners for each item in the dropdown
        foreach (var item in suggestionDropdown.items)
            item.OnItemSelection.AddListener(delegate { OnDropdownValueChanged(item.itemName); });

        // Set up the dropdown and trigger an animation
        suggestionDropdown.SetupDropdown();
        suggestionDropdown.isOn = false;
        suggestionDropdown.Animate();
    }

    /// <summary>
    /// Handles the dropdown value change event by updating the search input text.
    /// </summary>
    /// <param name="itemName">The selected item's name to be set as the search input text.</param>
    void OnDropdownValueChanged(string itemName)
    {
        searchInput.text = itemName;
    }

    /// <summary>
    /// Refreshes the suggestion dropdown by clearing its options and updating it with the original options.
    /// </summary>
    void RefreshDropdown()
    {
        suggestionDropdown.isOn = true;
        suggestionDropdown.Animate();
        suggestionDropdown.items.Clear();
        suggestionDropdown.items = originalOptions;
        suggestionDropdown.SetupDropdown();
    }
}