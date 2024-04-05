using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StartSceneStarter : MonoBehaviour
{
    private GameManager gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public List<float> GetRecords()
    {
        return gameManager.Records;
    }
}
