using Assets.Localization.Interfaces;
using Assets.Scripts.UI.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

[RequireComponent(typeof(RectTransform))]
public class UITooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private string _localizationKey;

    [SerializeField]
    private float _delay = 0.3f;

    [SerializeField]
    private GameObject _preferredParent;

    [SerializeField]
    private Vector3 _offset = Vector3.zero;

    private bool _isPointerInside;
    private float _enterTime;

    [Inject]
    private ILocalizationManager _localizationManager;

    [Inject]
    private ITooltipManager _tooltipManager;

    private GameObject Parent
    {
        get
        {
            if (_preferredParent == null)
                return this.gameObject;
            return _preferredParent;
        }
    } 

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isPointerInside = true;
        _enterTime = Time.time;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isPointerInside = false;
        _tooltipManager.Hide();
    }

    void Update()
    {
        if (_isPointerInside && Time.time - _enterTime >= _delay)
        {
            string text = _localizationManager.Get(_localizationKey);
            _tooltipManager.ShowUITooltip(text, Input.mousePosition + _offset, Parent);
        }
    }
}
