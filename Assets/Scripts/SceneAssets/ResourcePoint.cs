using Assets.Scripts.Interfaces;
using Assets.Scripts.PlayerStorage;
using Assets.Scripts.SceneAssets.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts.SceneAssets
{
    public class ResourcePoint : DestroyableAsset
    {
        [SerializeField]
        protected Sprite _resourceIcon;
        protected PlayerResources _resources;

        public event UnityAction<PlayerResources> Harvest;

        [Inject]
        protected ISceneAssetFactory _assetFactory;

        protected virtual void OnMouseDown()
        {
            Harvest?.Invoke(_resources);
            RaiseDestroyed();
            Destroy(gameObject);
        }

        protected void ShowPopup(int amount)
        {
            var popup = _assetFactory.CreateAsset<PopupText>();
            popup.Show(transform.position, amount.ToString(), _resourceIcon);
        }
    }
}
