using Assets.Scripts.PlayerStorage;
using UnityEngine;

namespace Assets.Scripts.SceneAssets.Mountains
{
    public class RockFormationWithCoal : ResourcePoint
    {
        protected override void GenerateResources()
        {
            _resources = new PlayerResources { Coal = Random.Range(4, 8) };
        }

        protected override void OnMouseDown()
        {
            ShowPopup(_resources.Coal);
            base.OnMouseDown();
        }
    }
}
