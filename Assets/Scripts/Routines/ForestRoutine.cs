using Assets.Scripts.EventBus;
using Assets.Scripts.Interfaces;
using UnityEngine;
using Zenject;
using ILogger = Assets.Scripts.Interfaces.ILogger;

public class ForestRoutine : MonoBehaviour
{
    private int _numberOfTrees = 20;
    private float _minX = -7f;
    private float _maxX = 7f;
    private float _minY = -3f;
    private float _maxY = 3f;

    [Inject]
    private ISceneAssetFactory _assetFactory;
    [Inject]
    private ILogger _logger;

    private ForestEventBus _eventBus;
    void Awake()
    {
        TreesGroup trees;
        _eventBus = new(_logger);
        for (var i = 1; i <= _numberOfTrees; i++)
        {
            trees = _assetFactory.CreateAssetNotCached<TreesGroup>();
            var x = Random.Range(_minX, _maxX + 1);
            var y = Random.Range(_minY, _maxY + 1);
            trees.transform.position = new Vector3(x, y, 0);
            trees.Harvest += _eventBus.OnHarvestTree;
        }

        _eventBus.SubscribeToHarvestTree(this, ShowTreeHarvest);
    }

    private void ShowTreeHarvest(int amount)
    {
        _logger.LogInfo($"Harvested {amount} wood.");
    }

    private void OnDestroy()
    {
        _eventBus.UnsubscribeAll();
    }
}
