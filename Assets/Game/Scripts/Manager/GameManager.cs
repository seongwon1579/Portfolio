using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConversationAsset;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using System.Linq;


public class GameManager : Singleton<GameManager>
{
    public List<float> records = new List<float>();

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void EndGame()
    {
        records.Add(float.Parse(UIController.uIController.GetRecord()));
        records = records.OrderByDescending(x => x).ToList();

        StartCoroutine(LoadSceneCo());
    }

    IEnumerator LoadSceneCo()
    {
        yield return new WaitForSeconds(3f);
        LoadingSceneManager.Set("StartScene");
    }
}


