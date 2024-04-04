using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;
using System.Threading;
using Zenject;

public class GameTimer : MonoBehaviour
{
    private SignalBus signalBus;

    [Inject]
    private void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }

    [SerializeField]
    private TextMeshProUGUI timerText;
    public string TimerText
    {
        get => timerText.text;
        private set
        {
            timerText.text = value;
        }
    }

    private CancellationTokenSource source;

    //private void OnEnable()
    //{
    //    source = new CancellationTokenSource();
    //    TimerAsync().Forget();
    //}

    private void Awake()
    {
        SetEvents();
    }

    private void SetEvents()
    {
        signalBus.Subscribe<GameOverSignal>(StopTimer);
    }

    public void StartTimer()
    {
        source = new CancellationTokenSource();
        TimerAsync().Forget();
    }

    private void StopTimer()
    {
        source.Cancel();
    }

    private async UniTaskVoid TimerAsync()
    {
        float elapsedTime = 0;

        while(!source.IsCancellationRequested)
        {
            elapsedTime += Time.deltaTime;
            timerText.text = elapsedTime.ToString("0.00");
            await UniTask.Yield(cancellationToken: source.Token);
        }
    }
}
