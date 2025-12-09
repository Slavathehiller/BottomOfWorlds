using Assets.Scripts.PlayerStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.EventBus.Interfaces
{
    public interface IExplorationEventBus
    {
        public void SubscribeToHarvestResource(object subscriber, UnityAction<PlayerResources> subscription);
        public void UnSubscribeFromHarvestResource(object subscriber);
        public void OnHarvestResource(PlayerResources resources);

        public void UnsubscribeAll();
    }
}
