using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class Record : MonoBehaviour
{
    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private TextMeshProUGUI[] recordsText;

    private StartSceneStarter starter;

    [Inject]
    private void Construct(StartSceneStarter starter)
    {
        this.starter = starter;
    }

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
        List<float> records = starter.GetRecords();

        if (records == null)
            return;

        for (int i = 0; i < records.Count; i++)
        {
            recordsText[i].text = records[i].ToString();
        }
    }
}
