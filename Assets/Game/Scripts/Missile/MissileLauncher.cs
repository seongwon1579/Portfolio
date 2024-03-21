using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace Missile
{
    public class MissileLauncher : MonoBehaviour
    {
        [SerializeField]
        private Projectable[] missiles;

        private CancellationTokenSource source;

        private void Awake()
        {
            MissileController.LaunchMissileAction += LaunchMissile;
        }

        private void LaunchMissile()
        {
            source = new CancellationTokenSource();
            LaunchAsyn().Forget();
        }

        private async UniTaskVoid LaunchAsyn()
        {
            while (!source.IsCancellationRequested)
            {
                foreach (var item in missiles)
                {
                    MissileController.missilePoolDic[item.gameObject.name].Dequeue(transform.position + (Vector3.up * 2f), transform.rotation);
                }
                await UniTask.Delay(TimeSpan.FromSeconds(2f), cancellationToken: source.Token);
            }
        }

        private void OnDestroy()
        {
            source.Cancel();
            MissileController.LaunchMissileAction -= LaunchMissile;
        }
    }
}
