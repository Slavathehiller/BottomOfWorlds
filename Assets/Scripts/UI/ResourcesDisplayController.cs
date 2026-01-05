using Assets.Scripts.UI.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using PlayerResources = Assets.Scripts.PlayerStorage.PlayerResources;

public class ResourcesDisplayController : MonoBehaviour
{
    [SerializeField]
    private GameObject _woodAmount;
    [SerializeField]
    private GameObject _stoneAmount;
    [SerializeField]
    private GameObject _ironOreAmount;
    [SerializeField]
    private GameObject _coalAmount;

    private void DisplayResource(GameObject res, int amount)
    {
        var textAmount = res.GetComponentInChildren<TMP_Text>();
        textAmount.text = amount.To4SymbString();
        res.SetActive(amount > 0);
    }

    public void DisplayResource(PlayerResources resource)
    {
        DisplayResource(_woodAmount, resource.Wood);
        DisplayResource(_stoneAmount, resource.Stone);
        DisplayResource(_ironOreAmount, resource.IronOre);
        DisplayResource(_coalAmount, resource.Coal);
    }
}
