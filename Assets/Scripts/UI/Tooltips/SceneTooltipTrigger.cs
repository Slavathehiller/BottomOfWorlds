using Assets.Localization.Interfaces;
using Assets.Scripts.SceneAssets.Interfaces;
using Assets.Scripts.UI.Interfaces;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Tooltips
{
    [RequireComponent(typeof(Collider2D))]
    public class SceneTooltipTrigger : MonoBehaviour
    {
        [SerializeField] private string _localizationKey;
        [SerializeField] private float _delay = 0.4f;

        [Inject]
        private ITooltipManager _tooltipManager;
        [Inject]
        private ILocalizationManager _localizationManager;

        private DestroyableAsset _parentDestroyable;

        private Vector3 _offset = new Vector3(0, 0.5f, 0);

        private void Awake()
        {
            var _parentDestroyable = GetComponent<DestroyableAsset>();
            if (_parentDestroyable != null)
            {
                _parentDestroyable.OnDestroy += Hide;
            }
        }

        private void UnsubscribeEvents()
        {
            if (_parentDestroyable != null)
                _parentDestroyable.OnDestroy -= Hide;
        }

        private void Hide()
        {
            UnsubscribeEvents();
            _tooltipManager.Hide();
        }

        private void OnMouseEnter()
        {
            var text = _localizationManager.Get(_localizationKey);
            _tooltipManager.ShowSceneTooltip(text, transform.position + _offset);
        }

        private void OnMouseExit()
        {
            Hide();
        }

        private void OnDestroy()
        {
            Hide();
        }

    }
}
