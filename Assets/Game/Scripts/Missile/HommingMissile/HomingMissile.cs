using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class HomingMissile : MonoBehaviour
{
    private CancellationTokenSource source;
    private ProjectableSetting setting;
    private Transform missileTransform;

    private void Set(ProjectableSetting setting, Transform transform)
    {
        this.setting = setting;
        missileTransform = transform;
        source = new CancellationTokenSource();
    }

    public void Project(ProjectableSetting setting, Transform transform)
    {
        Set(setting, transform);
        HommingAsync().Forget();
    }

    private async UniTaskVoid HommingAsync()
    {
        while (!source.IsCancellationRequested)
        {
            if (missileTransform == null)
                return;
            if (setting.PlayerController == null)
                source.Cancel();

            missileTransform.Translate(Vector3.forward * Time.deltaTime * setting.Speed);
            Vector3 targetDir = (setting.PlayerController.transform.position- missileTransform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(targetDir);
            missileTransform.rotation = Quaternion.Slerp(missileTransform.rotation, rotation, setting.RoateSpeed * Time.deltaTime);
            await UniTask.Yield(cancellationToken: source.Token);
        }
    }
}
