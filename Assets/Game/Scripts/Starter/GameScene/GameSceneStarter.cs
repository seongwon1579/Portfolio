using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneStarter : MonoBehaviour
{
    private GameTimer gameTimer;
    private SignalBus signalBus;
    private GameManager gameManager;

    [Inject]
    private void Construct(GameManager gameManager ,GameTimer gameTimer, SignalBus signalBus)
    {
        this.gameManager = gameManager;
        this.gameTimer = gameTimer;
        this.signalBus = signalBus;
    }

    private void Awake()
    {
        SetEvents();
    }

    private void Start()
    {
        gameTimer.StartTimer();
    }

    private void SetEvents()
    {
        signalBus.Subscribe<GameOverSignal>(() => gameManager.SetRecords(gameTimer.TimerText));        
    }
}
