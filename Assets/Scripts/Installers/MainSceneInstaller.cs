using Assets.Scripts.EventBus;
using Assets.Scripts.EventBus.Interfaces;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMainEventBus>().To<MainEventBus>().AsSingle();
    }
}

