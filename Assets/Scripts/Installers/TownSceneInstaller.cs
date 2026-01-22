using Assets.Scripts.EventBus;
using Assets.Scripts.EventBus.Interfaces;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class TownSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITownEventBus>().To<TownEventBus>().AsSingle();
        }
    }
}
