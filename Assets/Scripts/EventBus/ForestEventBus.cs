using Assets.Scripts.Interfaces;
using Assets.Scripts.PlayerStorage;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Assets.Scripts.EventBus
{
    public class ForestEventBus : BaseEventBus
    {        
        private Dictionary<object, UnityAction<PlayerResources>> _harvestResourceSubscribers = new();

        public ForestEventBus(ILogger logger) : base(logger) { }

        public void SubscribeToHarvestResource(object subscriber, UnityAction<PlayerResources> subscription)
        {
            Subscribe(_harvestResourceSubscribers, subscriber, subscription);
        }

        public void UnSubscribeFromHarvestResource(object subscriber)
        {
            UnSubscribe(_harvestResourceSubscribers, subscriber);
        }

        public void OnHarvestResource(PlayerResources resources)
        {
            Raise(_harvestResourceSubscribers, resources);
        }

        public void UnsubscribeAll()
        {
            _harvestResourceSubscribers.Clear();
        }
    }
}
