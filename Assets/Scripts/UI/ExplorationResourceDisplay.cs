using Assets.Scripts.PlayerStorage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationResourceDisplay : MonoBehaviour
{
    [SerializeField]
    private ResourceDisplayController _resourceDisplayController;

    public void DisplayResource(PlayerResources resource)
    {
        _resourceDisplayController.DisplayResource(resource);
    }
}
