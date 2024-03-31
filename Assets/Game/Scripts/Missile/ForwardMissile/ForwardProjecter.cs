using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ForwardProjecter : ProjectablePooler
{
    private ForwardMissile missile;
    private bool isPreSet = false;

    private Rigidbody rigidbody;

    [Inject]
    private void Constuct(ForwardMissile missile)
    {
        this.missile = missile;     
    }

    private void Set()
    {
        if(!isPreSet)
        {
            isPreSet = true;
            rigidbody = TryGetComponent(out rigidbody) ? rigidbody : null;
        }

        transform.position = setting.StartPoint + Vector3.up * 2f;
    }

    public void Project()
    {
        if (setting == null)
            return;

        Set();
        missile.Project(transform, rigidbody);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHeatable heatable))
            heatable.Heat(10);

        Dispose();
    }

    public class ForwardProjecterFactory : PlaceholderFactory<ProjectableSetting, ForwardProjecter>
    {

    }
}
