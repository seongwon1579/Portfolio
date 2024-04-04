using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private HPBar hPBar;
    
    public override void InstallBindings()
    {
        Container.BindInstance(hPBar).AsSingle();

    }
}