using Assets.Scripts.EventBus.Interfaces;
using Assets.Scripts.Factories.Interfaces;
using Assets.Scripts.PlayerStorage;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using ILogger = Assets.Scripts.Interfaces.ILogger;

public class TownRoutine : MonoBehaviour
{
    [Inject]
    private ILogger _logger;
    [Inject]
    private ICharacterSocial _character;
    [Inject]
    private ITownEventBus _eventBus;
    [Inject]
    protected IUIAssetFactory _assetFactory;

    [SerializeField]
    private GameObject _resourcesDisplayHolder;

    private ResourcesDisplayController _resourceDisplayController;

    public void ReturnButtonClick()
    {
        SceneManager.LoadScene(Scenes.MAIN_SCENE);
    }

    private void Start()
    {
        _character.Storage.OnPlayerResourcesChanged += _eventBus.OnChangeResource;

        _eventBus.SubscribeToChangeResource(this, OnResourceChanged);

        _resourceDisplayController = _assetFactory.CreateAsset<ResourcesDisplayController>(_resourcesDisplayHolder);
        _resourceDisplayController.DisplayResource(_character.Storage.Resources);
    }

    private void OnResourceChanged(PlayerResources resources)
    {
        _resourceDisplayController.DisplayResource(resources);
    }

    private void OnDestroy()
    {
        _character.Storage.OnPlayerResourcesChanged -= _eventBus.OnChangeResource;
        _eventBus.UnsubscribeAll();
    }
   
}
