using Assets.Scripts.Interfaces;
using Assets.Scripts.PlayerStorage;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class TreesGroup : MonoBehaviour
{
    [SerializeField]
    private Sprite _resourceIcon;
    private PlayerResources _resources;

    public event UnityAction<PlayerResources> Harvest;   

    [Inject]
    private ISceneAssetFactory _assetFactory;
    private void Awake()
    {
        _resources = new PlayerResources { Wood = Random.Range(5, 11) };
    }
    private void OnMouseDown()
    {
        var popup = _assetFactory.CreateAsset<PopupText>();
        popup.Show(transform.position, _resources.Wood.ToString(), _resourceIcon);
        Harvest?.Invoke(_resources);        
        Destroy(gameObject);
    }
}
