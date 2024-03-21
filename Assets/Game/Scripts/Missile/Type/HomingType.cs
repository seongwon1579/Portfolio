using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Missile
{
    public class HomingType : MissileType
    {   
        [SerializeField]
        private float missileRotationSpeed;
       
        [SerializeField, Range(0, 10)]
        private float missileSpeed;

        private Transform targetPos;

        private CancellationTokenSource source;

        protected override void OnEnable()
        {
            source = new CancellationTokenSource();
            Shoot().Forget();
        }

        protected override void OnDisable()
        {
            source.Cancel();  
        }

        private async UniTaskVoid Shoot()
        {
            while (!source.IsCancellationRequested)
            {
                if (TempController.tempController.curPlayer == null)
                    return;

                targetPos = TempController.tempController.curPlayer.transform;
                if (!targetPos)
                    return;

                transform.Translate(Vector3.forward * Time.deltaTime * missileSpeed);
                Vector3 targetDir = (targetPos.position + Vector3.up * 2f) - transform.position;
                targetDir.Normalize();
                Quaternion rotation = Quaternion.LookRotation(targetDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, missileRotationSpeed * Time.deltaTime);
                await UniTask.Yield(cancellationToken: source.Token);       
            }
        }      
    }
}




