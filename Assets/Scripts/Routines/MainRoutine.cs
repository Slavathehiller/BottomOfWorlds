using Assets.Scripts.EventBus;
using Assets.Scripts.EventBus.Interfaces;
using Assets.Scripts.Factories;
using Assets.Scripts.Factories.Interfaces;
using Assets.Scripts.PlayerStorage;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using ILogger = Assets.Scripts.Interfaces.ILogger;

public class MainRoutine : MonoBehaviour
{
    [Inject]
    private ILogger _logger;
    [Inject]
    private ICharacterSocial _character;
    [Inject]
    private IMainEventBus _eventBus;
    [Inject]
    protected IUIAssetFactory _assetFactory;

    [SerializeField]
    private ReturningFromExplorationWindow _returnFromExplorationWindow;
    [SerializeField]
    private ResourceDisplayController _resourcesDisplay;
    [SerializeField]
    private GameObject _UIcanvas;

    private void Awake()
    {
        _returnFromExplorationWindow.gameObject.SetActive(false);
    }

    private void Start()
    {
        _character.Storage.OnPlayerResourcesChanged += _eventBus.OnChangeResource;

        _eventBus.SubscribeToChangeResource(this, OnResourceChanged);

        if (_character.State == PlayerState.ReturningFromExploration)
        {
            _returnFromExplorationWindow.Show(_character.Cart.Resources);
        }
        _resourcesDisplay.DisplayResource(_character.Storage.Resources);
    }

    public void GoToForestButtonClick()
    {
        SceneManager.LoadScene(Scenes.FOREST_SCENE);
    }

    public void GoToMountainsButtonClick()
    {
        SceneManager.LoadScene(Scenes.MOUNTAINS_SCENE);
    }

    private void OnResourceChanged(PlayerResources resources)
    {
        _resourcesDisplay.DisplayResource(resources);
    }

    public void UnloadCartClickButton()
    {
        _character.Storage.AddResources(_character.Cart.Resources);
        _character.Cart.Resources = new();

        _returnFromExplorationWindow.Hide();
        _character.State = PlayerState.StandingInTown;
    }

    public void SettingsButtonClick()
    {
        var settingsWindow = _assetFactory.CreateAsset<SettingsWindow>(_UIcanvas);
        settingsWindow.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _eventBus.UnsubscribeAll();
    }
}
