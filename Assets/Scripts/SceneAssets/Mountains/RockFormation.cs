using Assets.Scripts.PlayerStorage;
using UnityEngine;

namespace Assets.Scripts.SceneAssets.Mountains
{
    public class RockFormation : ResourcePoint
    {
        private void Awake()
        {
            _resources = new PlayerResources { Stone = Random.Range(5, 11) };
        }
        protected override void OnMouseDown()
        {
            ShowPopup(_resources.Stone);
            base.OnMouseDown();
        }
    }
}
