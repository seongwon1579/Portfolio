using UnityEngine;
using Zenject;

public class StartSceneInstaller : MonoInstaller
{
    [SerializeField]
    private StartSceneStarter starter;

    public override void InstallBindings()
    {
        Container.BindInstance(starter).AsSingle();
    }
}