using UnityEngine;
using Zenject;

public class GameOverSignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<GameOverSignal>();
    }
}

public class GameOverSignal
{

}