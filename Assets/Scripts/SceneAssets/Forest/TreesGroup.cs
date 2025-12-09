using Assets.Scripts.PlayerStorage;
using Assets.Scripts.SceneAssets;
using UnityEngine;

public class TreesGroup : ResourcePoint
{
    private void Awake()
    {
        _resources = new PlayerResources { Wood = Random.Range(5, 11) };
    }
    protected override void OnMouseDown()
    {
        ShowPopup(_resources.Wood);
        base.OnMouseDown();
    }
}
