using Assets.Scripts.PlayerStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.EventBus.Interfaces
{
    public interface IMainEventBus
    {
        public void SubscribeToChangeResource(object subscriber, UnityAction<PlayerResources> subscription);
        public void UnsubscribeFromChangeResource(object subscriber);
        public void OnChangeResource(PlayerResources resources);

        public void UnsubscribeAll();
    }
}
