using Assets.Scripts;
using Assets.Scripts.Factories;
using Assets.Scripts.Interfaces;
using Zenject;

public class GlobalSettingsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IGlobalEventBus>().To<GlobalEventBus>().AsSingle();
        Container.BindInterfacesTo<SceneAssetFactory>().AsTransient();
        Container.Bind<ILogger>().To<Logger>().AsCached();
    }
}

