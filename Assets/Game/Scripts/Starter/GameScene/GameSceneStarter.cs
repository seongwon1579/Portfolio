using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneStarter : MonoBehaviour
{
    private GameTimer gameTimer;
    private SignalBus signalBus;

    [Inject]
    private void Construct(GameTimer gameTimer, SignalBus signalBus)
    {
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
        signalBus.Subscribe<GameOverSignal>(GameOver);        
    }

    private void GameOver()
    {
        
    }

}
