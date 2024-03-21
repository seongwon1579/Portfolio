using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button recordButton;

    [SerializeField]
    private GameObject recordPanel;

    private void Awake()
    {
        SetEvent();
    }

    private void SetEvent()
    {
        startButton.onClick.AddListener(() =>
        {
            LoadingSceneManager.Set("1st");
        });

        recordButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            recordPanel.SetActive(true);
        });
    }

}
