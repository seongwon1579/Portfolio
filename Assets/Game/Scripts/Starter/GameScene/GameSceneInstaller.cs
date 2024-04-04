using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField]
    private GameTimer gameTimer;

    public override void InstallBindings()
    {
        Container.BindInstance(gameTimer).AsSingle();
    }
}