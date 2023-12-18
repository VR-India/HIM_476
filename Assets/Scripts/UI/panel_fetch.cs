using UnityEngine;
using UnityEngine.UI;

public class panel_fetch : MonoBehaviour
{
    public Button[] btnsTMP;
    //public ButtonManager[] btnsMUI;
    private void Start()
    {   
        btnsTMP = GetComponentsInChildren<Button>();
        //btnsMUI = GetComponentsInChildren<ButtonManager>();
        if (btnsTMP != null)
        {
            for (int i = 0; i < btnsTMP.Length; i++)
            {
                string temp = btnsTMP[i].name;
                btnsTMP[i].onClick.AddListener(() => UI_Manager.instance.btnAction(temp));
            }
        }
    }
}