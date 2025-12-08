using Assets.Scripts.EventBus;
using Assets.Scripts.Interfaces;
using Assets.Scripts.PlayerStorage;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using ILogger = Assets.Scripts.Interfaces.ILogger;

public class ForestRoutine : MonoBehaviour
{
    private int _numberOfTrees = 20;
    private float _minX = -7f;
    private float _maxX = 7f;
    private float _minY = -2f;
    private float _maxY = 3f;

    [Inject]
    private ISceneAssetFactory _assetFactory;
    [Inject]
    private ILogger _logger;
    [Inject]
    private ICharacter _character;

    [SerializeField]
    private ResourceDisplayController _resourcesDisplay;

    private ForestEventBus _eventBus;
    void Awake()
    {
        _eventBus = new(_logger);
        for (var i = 1; i <= _numberOfTrees; i++)
        {
            TreesGroup trees = _assetFactory.CreateAsset<TreesGroup>();
            var x = Random.Range(_minX, _maxX + 1);
            var y = Random.Range(_minY, _maxY + 1);
            trees.transform.position = new Vector3(x, y, 0);
            trees.Harvest += _eventBus.OnHarvestResource;
        }
        _eventBus.SubscribeToHarvestResource(this, ShowTreeHarvest);
        _resourcesDisplay.DisplayResource(_character.Cart.Resources);
    }

    private void ShowTreeHarvest(PlayerResources resources)
    {
        _character.Cart.Resources = _character.Cart.Resources + resources;
        _resourcesDisplay.DisplayResource(_character.Cart.Resources);
    }

    public void ToTownButtonClick()
    {
        _character.State = PlayerState.ReturningFromExploration;
        SceneManager.LoadScene(Scenes.MAIN_SCENE);
    }


    private void OnDestroy()
    {
        _eventBus.UnsubscribeAll();
    }
}
