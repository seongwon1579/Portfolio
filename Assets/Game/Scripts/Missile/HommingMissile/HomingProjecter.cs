using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HomingProjecter : ProjectablePooler
{
    private HomingMissile missile;

    [Inject]
    private void Construct(HomingMissile missile)
    {
        this.missile = missile;
    }

    private void Set()
    {
        transform.position = setting.StartPoint;       
    }

    public void Project()
    {
        if (setting == null)
            return;

        Set();
        missile.Project(setting, transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHeatable heatable))
            heatable.Heat(10);

        Dispose();
    }

    public class HomingProjecterFactroy : PlaceholderFactory<ProjectableSetting, HomingProjecter>
    {

    }
}
