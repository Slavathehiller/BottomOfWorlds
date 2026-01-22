using Assets.Scripts.EventBus.Interfaces;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.EventBus
{
    public class TownEventBus : MainEventBus, ITownEventBus
    {
        public TownEventBus(ILogger logger) : base(logger)
        {
        }
    }
}
