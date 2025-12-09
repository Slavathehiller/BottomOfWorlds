using Assets.Scripts.EventBus.Interfaces;
using Assets.Scripts.Interfaces;
using Assets.Scripts.PlayerStorage;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Assets.Scripts.EventBus
{
    public class MainEventBus : BaseEventBus, IMainEventBus
    {
        private Dictionary<object, UnityAction<PlayerResources>> _changeResourceSubscribers = new();

        public MainEventBus(ILogger logger) : base(logger)
        {
            
        }

        public void SubscribeToChangeResource(object subscriber, UnityAction<PlayerResources> subscription) => Subscribe(_changeResourceSubscribers, subscriber, subscription);
        public void UnsubscribeFromChangeResource(object subscriber) => UnSubscribe(_changeResourceSubscribers, subscriber);
        public void OnChangeResource(PlayerResources resources) => Raise(_changeResourceSubscribers, resources);

        public void UnsubscribeAll()
        {
            _changeResourceSubscribers.Clear();
        }

    }
}
