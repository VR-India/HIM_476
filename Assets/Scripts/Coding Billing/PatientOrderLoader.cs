using Michsky.MUIP;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents an entity with a name and an array of final order sprites.
/// </summary>
[Serializable]
public class PatientOrderData
{
    public string name;
    public Sprite[] finalOrderSprite;
}

/// <summary>
/// Represents a class which deals with final order sprites.
/// </summary>
public class PatientOrderLoader : MonoBehaviour
{
    public List<PatientOrderData> patientOrder;
    public GameObject[] report;
    public ButtonManager openButton;
    public GridLayoutGroup layout;
    CustomDropdown CD;

    // Start is called before the first frame update
    void Start()
    {
        CD = GetComponent<CustomDropdown>();

        //Adds a listener, When the button is clicked, it invokes the LoadFinalOrder method with the selectedItemIndex from dropdown
        openButton.onClick.AddListener(delegate { LoadFinalOrder(CD.selectedItemIndex); });
    }

    /// <summary>
    /// Loads the final order of sprites based on the selected item index.
    /// </summary>
    /// <param name="selectedItemIndex">The index of the selected item.</param>
    /// <remarks>
    /// - Checks if the <i>selectedItemIndex</i> is within valid bounds before proceeding.
    /// <br>- Retrieves the <i>selectedItem</i> based on the index.</br>
    /// <br>- Sets the <i>constraintCount</i> of the layout based on the number of sprites in the selected item's final order.</br>
    /// <br>- Displays and sets the sprites in the <i>report</i> based on the final order of the selected item.</br>
    /// </remarks>
    private void LoadFinalOrder(int selectedItemIndex)
    {
        if (0 > selectedItemIndex || selectedItemIndex >= patientOrder.Count)
            return;

        PatientOrderData selectedItem = patientOrder[selectedItemIndex];

        layout.constraintCount = selectedItem.finalOrderSprite.Length;

        for (int i = 0; i < selectedItem.finalOrderSprite.Length; i++)
        {
            GameObject currentReportItem = report[i];

            currentReportItem.SetActive(true);
            currentReportItem.GetComponent<Image>().sprite = selectedItem.finalOrderSprite[i];
        }
    }
}
