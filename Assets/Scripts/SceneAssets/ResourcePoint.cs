using Assets.Scripts.Interfaces;
using Assets.Scripts.PlayerStorage;
using Assets.Scripts.SceneAssets.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts.SceneAssets
{
    public abstract class ResourcePoint : DestroyableAsset
    {
        [SerializeField]
        protected Sprite _resourceIcon;

        [SerializeField]
        protected List<Sprite> _images;

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

        private void Awake()
        {
            Init();
            GenerateResources();
        }

        protected virtual void Init()
        {
            var imageIndex = Random.Range(0, _images.Count);
            var renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = _images[imageIndex];
        }

        protected abstract void GenerateResources();


        protected void ShowPopup(int amount)
        {
            var popup = _assetFactory.CreateAsset<PopupText>();
            popup.Show(transform.position, amount.ToString(), _resourceIcon);
        }
    }
}
