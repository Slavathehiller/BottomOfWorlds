using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MainRoutine : MonoBehaviour
{
    [Inject]
    private IGlobalEventBus _eventBus;
    [Inject]
    private ICharacterSocial _character;

    [SerializeField]
    private ReturningFromExplorationWindow _returnFromExplorationWindow;
    [SerializeField]
    private ResourceDisplayController _resourcesDisplay;

    private void Awake()
    {
        _returnFromExplorationWindow.gameObject.SetActive(false);
    }

    private void Start()
    {
        if (_character.State == PlayerState.ReturningFromExploration)
        {
            _returnFromExplorationWindow.gameObject.SetActive(true);
            _returnFromExplorationWindow.DisplayResources(_character.Cart.Resources);
        }
        _resourcesDisplay.DisplayResource(_character.Storage.Resources);
    }

    public void GoToForestButtonClick()
    {
        SceneManager.LoadScene(Scenes.FOREST_SCENE);
    }

    public void UnloadCartClickButton()
    {
        _character.Storage.Resources += _character.Cart.Resources;
        _character.Cart.Resources = new();
        _resourcesDisplay.DisplayResource(_character.Storage.Resources);
        _returnFromExplorationWindow.gameObject.SetActive(false);
    }
}
