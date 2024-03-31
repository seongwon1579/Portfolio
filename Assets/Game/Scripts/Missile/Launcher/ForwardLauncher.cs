using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ForwardLauncher : MonoBehaviour
{
    private ForwardProjecter.ForwardProjecterFactory forwardProjecter;

    [SerializeField]
    private Transform LaunchTransform;

    [Inject]
    private void Construct(ForwardProjecter.ForwardProjecterFactory forwardProjecter)
    {
        this.forwardProjecter = forwardProjecter;
    }

    private void Start()
    {
        ProjectableSetting setting = new ProjectableSetting();
        setting.StartPoint = LaunchTransform.position;

        var missile = forwardProjecter.Create(setting);
        missile.Project();
       
    }

}
