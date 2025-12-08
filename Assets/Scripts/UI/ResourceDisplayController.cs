using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using PlayerResources = Assets.Scripts.PlayerStorage.PlayerResources;

public class ResourceDisplayController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _woodAmount;

    private void DisplayResource(TMP_Text res, int amount)
    {
        res.text = amount.ToString();
        res.gameObject.SetActive(amount > 0);
    }

    public void DisplayResource(PlayerResources resource)
    {
        DisplayResource(_woodAmount, resource.Wood);
    }
}
