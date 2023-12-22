using Michsky.MUIP;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class x
{
    public string name;
    public Sprite[] finalOrderSprite;
}

public class CodingDetails : MonoBehaviour
{
    public List<x> sprites;
    public GameObject[] report;
    public ButtonManager openButton;
    public GridLayoutGroup layout;
    CustomDropdown CD;

    // Start is called before the first frame update
    void Start()
    {
        CD = GetComponent<CustomDropdown>();
        openButton.onClick.AddListener(delegate { LoadFinalOrder(CD.selectedItemIndex); });
    }

    private void LoadFinalOrder(int selectedItemIndex)
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            if (i == selectedItemIndex)
            {
                layout.constraintCount = sprites[i].finalOrderSprite.Length;

                for (int j = 0; j < sprites[i].finalOrderSprite.Length; j++)
                {
                    report[j].SetActive(true);
                    report[j].GetComponent<Image>().sprite = sprites[i].finalOrderSprite[j];
                }
            }
        }
    }
}
