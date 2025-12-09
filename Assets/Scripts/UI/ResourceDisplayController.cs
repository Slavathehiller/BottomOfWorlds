using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using PlayerResources = Assets.Scripts.PlayerStorage.PlayerResources;

public class ResourceDisplayController : MonoBehaviour
{
    [SerializeField]
    private GameObject _woodAmount;
    [SerializeField]
    private GameObject _stoneAmount;

    private void DisplayResource(GameObject res, int amount)
    {
        var textAmount = res.GetComponentInChildren<TMP_Text>();
        textAmount.text = amount.ToString();
        res.SetActive(amount > 0);
    }

    public void DisplayResource(PlayerResources resource)
    {
        DisplayResource(_woodAmount, resource.Wood);
        DisplayResource(_stoneAmount, resource.Stone);
    }
}
