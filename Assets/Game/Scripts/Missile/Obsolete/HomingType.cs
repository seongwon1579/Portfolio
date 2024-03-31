using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using System.Threading;
using Zenject;

namespace Missile
{
    public class HomingType : MissileType
    {
        [SerializeField]
        private float missileRotationSpeed;
       
        [SerializeField, Range(0, 10)]
        private float missileSpeed;

        private Transform target;

        private CancellationTokenSource source;

        private void SetTarget()
        {
           
            

            //if(TryGetComponent(out Projectable projectable))
            //{
            //    return projectable.GetTarget();
            //}
            //return null;
        }

        private void Update()
        {
            transform.forward = Vector3.right * Time.deltaTime * 0.05f; 
        }

        protected override void OnEnable()
        {
            //source = new CancellationTokenSource();
            //SetTarget();
            //Shoot().Forget();
        }

        protected override void OnDisable()
        {
            //source.Cancel();  
        }

        private async UniTaskVoid Shoot()
        {
            while (!source.IsCancellationRequested)
            {
                //if (TempController.tempController.curPlayer == null)
                //    return;

                //target = TempController.tempController.curPlayer.transform;
                if (!target)
                    return;

                transform.Translate(Vector3.forward * Time.deltaTime * missileSpeed);
                Vector3 targetDir = (target.position + Vector3.up * 2f) - transform.position;
                targetDir.Normalize();
                Quaternion rotation = Quaternion.LookRotation(targetDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, missileRotationSpeed * Time.deltaTime);
                await UniTask.Yield(cancellationToken: source.Token);       
            }
        }      
    }
}




