using UnityEngine;
using Zenject;

public class GameManagerInstaller : MonoInstaller
{
    [SerializeField]
    GameManager gameManager;

    public override void InstallBindings()
    {
        Container.BindInstance(gameManager).AsSingle();
    }
}