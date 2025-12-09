using Assets.Scripts.Interfaces;
using Assets.Scripts.PlayerStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Scripts.SceneAssets
{
    public class ResourcePoint : MonoBehaviour
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
            Destroy(gameObject);
        }

        protected void ShowPopup(int amount)
        {
            var popup = _assetFactory.CreateAsset<PopupText>();
            popup.Show(transform.position, amount.ToString(), _resourceIcon);
        }
    }
}
