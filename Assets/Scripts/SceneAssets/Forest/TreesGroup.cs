using UnityEngine;
using UnityEngine.Events;

public class TreesGroup : MonoBehaviour
{
    public event UnityAction<int> Harvest;
    private int _resourceAmount;
    private void Awake()
    {
        _resourceAmount = Random.Range(5, 11);
    }
    private void OnMouseDown()
    {
        Harvest?.Invoke(_resourceAmount);
        Destroy(gameObject);
    }
}
