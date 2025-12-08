using Assets.Scripts.PlayerStorage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturningFromExplorationWindow : MonoBehaviour
{
    [SerializeField]
    private ResourceDisplayController _resourceDisplay;

    public void DisplayResources(PlayerResources resources)
    {
        _resourceDisplay.DisplayResource(resources);
    }
}
