using UnityEngine;
using Zenject;

public class MissileInstaller : MonoInstaller
{
    public GameObject HommingProjecter;
    public GameObject ForwardProjecter;
    public PlayerController target;
    public GameObject starter;

    public override void InstallBindings()
    {
        Container.BindFactory<ProjectableSetting, HomingProjecter, HomingProjecter.HomingProjecterFactroy>().FromPoolableMemoryPool(pool =>
        pool
            .FromSubContainerResolve()
            .ByNewContextPrefab(HommingProjecter)
            .UnderTransformGroup("Pool"));

        Container.BindFactory<ProjectableSetting, ForwardProjecter, ForwardProjecter.ForwardProjecterFactory>().FromPoolableMemoryPool(pool =>
        pool
            .FromSubContainerResolve()
            .ByNewContextPrefab(ForwardProjecter)
            .UnderTransformGroup("Pool"));

        Container.BindInstance(target).AsSingle();
        Container.BindInstance(starter).AsSingle();
    }
}