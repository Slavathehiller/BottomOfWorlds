using Assets.Scripts.EventBus;
using Assets.Scripts.EventBus.Interfaces;
using Assets.Scripts.Interfaces;
using Assets.Scripts.PlayerStorage;
using Assets.Scripts.Routines;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class ForestRoutine : ExplorationRoutine
{
    protected override void Init()
    {
        SpawnResourcesPoints<TreesGroup>();
    }

}
