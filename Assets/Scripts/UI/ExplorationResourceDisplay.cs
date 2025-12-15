using Assets.Scripts.Factories.Interfaces;
using Assets.Scripts.PlayerStorage;
using UnityEngine;
using Zenject;

public class ExplorationResourceDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject _resourceDisplayHolder;

    private ResourcesDisplayController _resourceDisplayController;

    [Inject]
    private IUIAssetFactory _assetFactory;

    private void Awake()
    {
        _resourceDisplayController = _assetFactory.CreateAsset<ResourcesDisplayController>(_resourceDisplayHolder);
    }
    public void DisplayResource(PlayerResources resource)
    {
        _resourceDisplayController.DisplayResource(resource);
    }
}
