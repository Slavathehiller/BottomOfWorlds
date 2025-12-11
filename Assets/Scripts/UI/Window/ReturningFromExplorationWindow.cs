using Assets.Scripts.PlayerStorage;
using Assets.Scripts.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturningFromExplorationWindow : ModalWindow
{
    [SerializeField]
    private ExplorationResourceDisplay _resourceDisplay;

    public void Show(PlayerResources resources)
    {
        base.Show();
        DisplayResources(resources);
    }
    private void DisplayResources(PlayerResources resources)
    {
        _resourceDisplay.DisplayResource(resources);
    }
}
