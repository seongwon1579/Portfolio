using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Record : MonoBehaviour
{
    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private TextMeshProUGUI[] recordsText;
    private List<float> records;

    private void Awake()
    {
        SetEvent();
    }

    private void OnEnable()
    { 
        ShowRecord();
    }

    private void SetEvent()
    {
        closeButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            mainMenu.SetActive(true);
        });
    }

    private void ShowRecord()
    {
        records = GameManager.Instance.records;
        if (records == null)
            return;

        for (int i = 0; i < records.Count; i++)
        {
            recordsText[i].text = records[i].ToString();
        }
    }
}
