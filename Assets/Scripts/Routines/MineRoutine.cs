using Assets.Scripts.Routines;
using Assets.Scripts.SceneAssets.Mountains;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineRoutine : ExplorationRoutine
{
    protected override void Init()
    {
        SpawnResourcesPoints<RockFormationWithIronOre>();
        SpawnResourcesPoints<RockFormationWithCoal>();
    }

    public void GetOutButtonClick()
    {
        SceneManager.LoadScene(Scenes.MOUNTAINS_SCENE);
    }
}
