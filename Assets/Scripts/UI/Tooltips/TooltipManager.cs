using Assets.Scripts.Factories.Interfaces;
using Assets.Scripts.UI.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

public class TooltipManager : ITooltipManager
{
    private UITooltip _currentUITooltip;
    private SceneTooltip _currentSceneTooltip;
    private TextMeshProUGUI _UITextComponent;
    private TextMeshProUGUI _sceneTextComponent;

    [Inject]
    private IUIAssetFactory _assetFactory;

    public void ShowUITooltip(string text, Vector2 screenPosition, GameObject parent)
    {

        if (_currentUITooltip == null)
        {
            _currentUITooltip = _assetFactory.CreateAsset<UITooltip>(parent);
            _UITextComponent = _currentUITooltip.GetComponentInChildren<TextMeshProUGUI>();
        }
        else
            _currentUITooltip.transform.SetParent(parent.transform);

        _UITextComponent.text = text;
        _currentUITooltip.gameObject.SetActive(true);

        var size = _currentUITooltip.GetComponent<RectTransform>().rect.size;
        var clampedPos = new Vector2(
            Mathf.Clamp(screenPosition.x, 0, Screen.width - size.x),
            Mathf.Clamp(screenPosition.y, size.y, Screen.height)
        );


        _currentUITooltip.transform.position = clampedPos;
    }

    public void ShowSceneTooltip(string text, Vector2 screenPosition)
    {
        if (_currentSceneTooltip == null)
        {
            _currentSceneTooltip = _assetFactory.CreateAsset<SceneTooltip>(null);
            _sceneTextComponent = _currentSceneTooltip.GetComponentInChildren<TextMeshProUGUI>();
        }

        _sceneTextComponent.text = text;
        _currentSceneTooltip.gameObject.SetActive(true);

        var rectTransform = _currentSceneTooltip.GetComponent<RectTransform>();

        Canvas.ForceUpdateCanvases();
        rectTransform.position = screenPosition;

    }


    public void Hide()                                      //Тултип не уничтожается, а просто скрывается, типа кеширование
    {
        if (_currentUITooltip != null)
            _currentUITooltip.gameObject.SetActive(false);
        if (_currentSceneTooltip != null)
            _currentSceneTooltip.gameObject.SetActive(false);
    }

}
