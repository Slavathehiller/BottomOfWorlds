using System;

namespace Assets.Scripts.PlayerStorage
{
    public class PlayerStorage
    {
        public event Action<PlayerResources> OnPlayerResourcesChanged;
        public PlayerResources Resources { get; set; } = new();

        public void AddResources(PlayerResources resources)
        {
            Resources += resources;
            OnPlayerResourcesChanged?.Invoke(Resources);
        }

        public void RemoveResources(PlayerResources resources)
        {   
            Resources -= resources; 
            OnPlayerResourcesChanged?.Invoke(Resources);
        }
    }
}
