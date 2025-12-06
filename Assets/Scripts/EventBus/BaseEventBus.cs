using System.Collections.Generic;
using Assets.Scripts.Interfaces;
using UnityEngine.Events;

namespace Assets.Scripts.EventBus
{
    public class BaseEventBus
    {
        protected ILogger _logger;
        public BaseEventBus(ILogger logger)
        {
            _logger = logger;
        }
        protected void Subscribe<T>(Dictionary<object, UnityAction<T>> collection, object key, UnityAction<T> value)
        {
            if (!collection.ContainsKey(key))
            {
                collection.Add(key, value);
            }
            else
                _logger.LogWarning($"Trying to subscribe twice {key.GetType()}.{value}");
        }

        protected void UnSubscribe<T>(Dictionary<object, UnityAction<T>> collection, object key)
        {
            if (collection.ContainsKey(key))
            {
                collection.Remove(key);
            }
            else
                _logger.LogWarning($"Trying to unsubscribe when not subscribed {key.GetType()}");
        }

        protected void Raise<T>(Dictionary<object, UnityAction<T>> collection, T value)
        {
            foreach (var subscriber in collection)
                subscriber.Value.Invoke(value);
        }
    }
}
