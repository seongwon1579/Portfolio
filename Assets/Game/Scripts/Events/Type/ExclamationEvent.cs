using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class ExclamationEvent : Events
{
    [SerializeField]
    private GameObject targetMark;

    private CancellationTokenSource source = new CancellationTokenSource();

    [SerializeField]
    private bool isOn;
    private bool IsOn
    {
        set
        {
            isOn = value;
            targetMark.SetActive(isOn);

            if (!isOn)
            {
                source.Cancel();
                return;
            }
            
            source = new CancellationTokenSource();
            RotateAsync().Forget();
        }       
    }
    
    private void Start()
    {
        if (!targetMark)
            return;

        IsOn = isOn;
    }

    private async UniTaskVoid RotateAsync()
    {
        while (!source.Token.IsCancellationRequested)
        {
            targetMark.transform.Rotate(0, 2, 0);
            await UniTask.Yield(cancellationToken: source.Token);
        }
    }

    private void OnDestroy()
    {
        source.Cancel();
    }

    public override void DoEvent(bool isOn)
    {
        IsOn = isOn;
    }
}
