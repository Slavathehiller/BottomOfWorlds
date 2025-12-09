using Assets.Scripts.EventBus;
using Assets.Scripts.EventBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class ForestSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IExplorationEventBus>().To<ExplorationEventBus>().AsSingle();
        }
    }
}
