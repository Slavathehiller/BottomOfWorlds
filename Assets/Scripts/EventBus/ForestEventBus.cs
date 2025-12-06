using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Assets.Scripts.EventBus
{
    public class ForestEventBus : BaseEventBus
    {        
        private Dictionary<object, UnityAction<int>> _harvestTreeSubscribers = new();

        public ForestEventBus(ILogger logger) : base(logger) { }

        public void SubscribeToHarvestTree(object subscriber, UnityAction<int> subscription)
        {
            Subscribe(_harvestTreeSubscribers, subscriber, subscription);
        }

        public void UnSubscribeFromHarvestTree(object subscriber)
        {
            UnSubscribe(_harvestTreeSubscribers, subscriber);
        }

        public void OnHarvestTree(int amount)
        {
            Raise(_harvestTreeSubscribers, amount);
        }

        public void UnsubscribeAll()
        {
            _harvestTreeSubscribers.Clear();
        }
    }
}
