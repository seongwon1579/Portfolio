using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;
using System.Threading;


public class UIController : MonoBehaviour
{
    public static UIController uIController;

    [SerializeField]
    private Image recordImage;
    [SerializeField]
    private TextMeshProUGUI recordText;

    private CancellationTokenSource source;

    private float elapsedTime = 0;

    private void Awake()
    {
        uIController = this;
    }

    private void OnEnable()
    {
        source = new CancellationTokenSource();
        TimerAsync().Forget();
    }

    public string GetRecord()
    {
        source.Cancel();
        return recordText.text;
    }

    public void ApplyRealtimeHp(float curHp, float maxHp)
    {  
        recordImage.fillAmount = Mathf.Lerp(0, 1, curHp/maxHp);
    }

    private async UniTaskVoid TimerAsync()
    {
        while(!source.IsCancellationRequested)
        {
            elapsedTime += Time.deltaTime;
            recordText.text = elapsedTime.ToString("0.00");
            await UniTask.Yield(cancellationToken: source.Token);
        }
    }
}
