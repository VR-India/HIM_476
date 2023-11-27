using Michsky.UI.ModernUIPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class BillList
{
    public List<BillData> bilList;
}
[Serializable]
public class BillData
{
    public string billData, billAmount;
}

public class BillDetails : MonoBehaviour
{
    public BillList _billList;
    public TMP_Text Details, Bill;
    public CustomDropdown patientName;
    public Sprite img;
    private void Start()
    {
        /*string json = JsonUtility.ToJson(billList, true);
        File.WriteAllText(Application.dataPath + "/jsonBillData/data.json", json);*/

        img = Resources.Load<Sprite>("3M icon");
        //string json = File.ReadAllText(Application.dataPath + "/jsonBillData/data.json");
        string json = Resources.Load<TextAsset>("jsonBillData/data").text;
        _billList = JsonUtility.FromJson<BillList>(json);
    }

    public void fillDetails(int index)
    {
        Details.text = _billList.bilList[index].billData;
        Bill.text = _billList.bilList[index].billAmount;
    }
}