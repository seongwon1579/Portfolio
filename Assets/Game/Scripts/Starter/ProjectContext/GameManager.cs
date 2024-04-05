using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class GameManager : MonoBehaviour
{
    private List<float> records = new List<float>();
    public List<float> Records
    {
        get => records;
        private set => records = value;
    }

    public void SetRecords(string e)
    {
        records.Add(float.Parse(e));
        records = records.OrderByDescending(x => x).ToList();

        StartCoroutine(LoadSceneCo());
    }

    IEnumerator LoadSceneCo()
    {
        yield return new WaitForSeconds(3f);
        LoadingSceneManager.Set("StartScene");
    }
}