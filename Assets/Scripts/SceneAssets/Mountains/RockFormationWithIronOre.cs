using Assets.Scripts.PlayerStorage;
using UnityEngine;

namespace Assets.Scripts.SceneAssets.Mountains
{
    public class RockFormationWithIronOre : ResourcePoint
    {
        protected override void GenerateResources()
        {
            _resources = new PlayerResources { IronOre = Random.Range(3, 7) };
        }

        protected override void OnMouseDown()
        {
            ShowPopup(_resources.IronOre);
            base.OnMouseDown();
        }
    }
}
