using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

public class EntitiesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<Character>().AsSingle();
    }
}

